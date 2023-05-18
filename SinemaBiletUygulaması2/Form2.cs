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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Form1 form1 = new Form1();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && richTextBox1.Text != "")
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into filmler (filmAdi,yönetmen,tür,süre,oyuncular) Values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "','" + richTextBox1.Text.ToString() + "')", conn);
                    cmd.ExecuteNonQuery();
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    richTextBox1.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
            form1.Show();
            this.Close();
        }
    }
}
