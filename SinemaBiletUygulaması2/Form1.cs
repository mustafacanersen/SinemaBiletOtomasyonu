using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace SinemaBiletUygulaması2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button52_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void button55_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button53_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }

        private void button54_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            filmGoster();
            int sayac = 1;
            for (int i = 0; i < 7; i++)
            {
                
                for (int j = 0; j < 9; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(30, 30);
                    btn.Location = new Point(j * 30+30, i * 30 + 100);
                    btn.BackColor = Color.Lime;
                    btn.Name = sayac.ToString();
                    btn.Text = sayac.ToString();
                    if(j == 4)
                    {
                        continue;
                    }
                    btn.Click += Btn_Click;
                    sayac++;
                    this.groupBox1.Controls.Add(btn);

                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackColor == Color.Lime)
            {
                textBox1.Text = btn.Text;
            }
            
        }
        private void doluKoltuklar()
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from biletSatis where filmAdi='"+comboBox1.SelectedItem+"' and seans='"+comboBox2.SelectedItem+"' and tarih='"+dateTimePicker1.Text+"'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    foreach(Control item in groupBox1.Controls)
                    {
                        if(item is Button)
                        {
                            if (sqlDr["koltuk"].ToString()==item.Text)
                            item.BackColor = Color.Red;
                        }
                    }
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
        private void iptalEdilebilecekKoltuklar()
        {
            comboBox4.Items.Clear();
            comboBox4.Text = "";
            foreach (Control item in groupBox1.Controls)
            {
                if( item is Button)
                {
                    if(item.BackColor == Color.Red)
                    {
                        comboBox4.Items.Add(item.Text);
                    }
                }
            }
        }
        private void filmBilgileriGoster()
        {

            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from filmler where filmAdi='"+comboBox1.SelectedItem+"'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    label11.Text = "Film Adı:   " + sqlDr["filmAdi"].ToString();
                    label12.Text = "Yönetmen:   " + sqlDr["yönetmen"].ToString();
                    label13.Text = "Tür:   " + sqlDr["tür"].ToString();
                    label14.Text = "Süre:   " + sqlDr["süre"].ToString();
                    richTextBox1.Text = sqlDr["oyuncular"].ToString();
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
        private void seansGoster()
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                comboBox2.Items.Clear();
                SqlCommand seans = new SqlCommand("select * from seanslar where filmAdi ='" + comboBox1.SelectedItem + "' ", baglanti);
                SqlDataReader dr = seans.ExecuteReader();
                while (dr.Read())
                {
                    comboBox2.Items.Add(dr["seans"]);
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
        private void salonGoster()
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                comboBox5.Items.Clear();
                SqlCommand seans = new SqlCommand("select * from seanslar where filmAdi ='" + comboBox1.SelectedItem + "' and seans='"+comboBox2.SelectedItem+"' ", baglanti);
                SqlDataReader dr = seans.ExecuteReader();
                while (dr.Read())
                {
                    comboBox5.Items.Add(dr["salon"]);
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
        private void filmGoster()
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
                    comboBox1.Items.Add(sqlDr["filmAdi"]);
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
        private void groupBox2_Enter(object sender, EventArgs e)
        {

         
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            filmBilgileriGoster();
            seansGoster();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            salonGoster();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Tam")
            {
                label7.Text = "70 TL";
            }
            else if (comboBox3.Text == "Öğrenci")
            {
                label7.Text = "50 TL";
            }
        }

        private void button49_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox5.Text != "" && textBox1.Text != "")
            {
                SqlConnection conn = null;
                try
                {
                    conn = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("Insert into biletSatis (filmAdi,seans,salon,koltuk,biletTürü,fiyat,tarih) Values ('" + comboBox1.SelectedItem + "','" + comboBox2.SelectedItem + "','" + comboBox5.SelectedItem + "','" + textBox1.Text + "','" + comboBox3.SelectedItem + "','" + Convert.ToInt32(label7.Text.Substring(0, 2)) + "','" + dateTimePicker1.Text + "')", conn);
                    cmd.ExecuteNonQuery();


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
                MessageBox.Show(dateTimePicker1.Text + "\n" + comboBox1.Text + "\n" + "seans: " + comboBox2.Text + "\n" + comboBox5.Text + "\n" + "koltuk: " + textBox1.Text + "\n" + comboBox3.Text + "\n" + "Fiyat: " + label7.Text);
                textBox1.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
                comboBox5.Text = "";
                comboBox3.Text = "";
                label7.Text = "0 TL";
            }
            else
            {
                MessageBox.Show("eksik bilgi girdiniz");
            }
            groupBox1.Visible = false;
            foreach (Control item in groupBox1.Controls)
            {
                if (item is Button)
                    item.BackColor = Color.Lime;

            }

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            doluKoltuklar();
            groupBox1.Visible = true;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select * from biletSatis where koltuk='"+comboBox4.SelectedItem+"'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    label10.Text = sqlDr["fiyat"].ToString() + " TL";
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {
            iptalEdilebilecekKoltuklar();
        }

        private void button51_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from biletSatis where koltuk = '"+comboBox4.SelectedItem+"'",baglanti);
                komut.ExecuteNonQuery();
                comboBox4.Text = "";
                doluKoltuklar();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
            label10.Text = "";
            MessageBox.Show("Biletiniz iptal edilmiştir");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox5.Text = "";
            comboBox3.Text = "";
            groupBox1.Visible = false;
            foreach (Control item in groupBox1.Controls)
            {
                if (item is Button)                 
                item.BackColor = Color.Lime;
                
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
