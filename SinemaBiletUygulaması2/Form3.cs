using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SinemaBiletUygulaması2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into seanslar (film,salon,seans) Values (@film,@salon,@seans)", conn);
                    cmd.Parameters.AddWithValue("@film", comboBox2.Text.ToString());
                    cmd.Parameters.AddWithValue("@salon", comboBox1.Text.ToString());
                    string seans = "";
                    if (radioButton1.Checked)
                        seans = radioButton1.Text.ToString();
                    else if (radioButton2.Checked)
                        seans = radioButton2.Text.ToString();
                    else if (radioButton3.Checked)
                        seans = radioButton3.Text.ToString();
                    else
                        seans = radioButton4.Text.ToString();
                    cmd.Parameters.AddWithValue("@seans", seans);
                    cmd.ExecuteNonQuery();
                    comboBox1.Items.Clear();
                    comboBox2.Items.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn != null)
                        conn.Close();
                }
            }
            else
            {
                MessageBox.Show("eksik bilgi girdiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from filmler", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    comboBox2.Items.Add(sqlDr["filmAdi"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally 
            {
                if (baglanti != null)
                    baglanti.Close();
            }


        }
    }
}
