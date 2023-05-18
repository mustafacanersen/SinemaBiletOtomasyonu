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

namespace SinemaBiletUygulaması2
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
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

        private void Form4_Load(object sender, EventArgs e)
        {
            filmGoster();
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
    
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            seansGoster();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select sum(fiyat) as 'hasılat' from biletSatis where filmAdi='"+comboBox1.SelectedItem+"' and seans = '"+comboBox2.SelectedItem+"' and tarih='"+dateTimePicker1.Text+"'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                        label4.Text = "Hasılat: " + sqlDr["hasılat"].ToString() + " TL";
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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                SqlCommand komut = new SqlCommand("select sum(fiyat) as 'hasılat' from biletSatis", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    label4.Text = "Hasılat: "+ sqlDr["hasılat"].ToString() + " TL";
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                string tarih = Convert.ToString(dateTimePicker1.Text);
                SqlCommand komut = new SqlCommand("select sum(fiyat) as 'hasılat' from biletSatis where tarih LIKE '___"+ tarih.Substring(3,3)+"%'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    label4.Text = "Hasılat: " + sqlDr["hasılat"].ToString() + " TL";
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

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = null;
            try
            {
                baglanti = new SqlConnection(@"Data Source = localhost\sqlexpress; Initial Catalog = SinemaBiletUygulaması; Integrated Security = True");
                baglanti.Open();
                string tarih = Convert.ToString(dateTimePicker1.Text);
                SqlCommand komut = new SqlCommand("select sum(fiyat) as 'hasılat' from biletSatis where tarih LIKE '___" + tarih.Substring(3, 3) + "%' and filmAdi='"+comboBox1.SelectedItem+"'", baglanti);
                SqlDataReader sqlDr = komut.ExecuteReader();
                while (sqlDr.Read())
                {
                    label4.Text = "Hasılat: " + sqlDr["hasılat"].ToString() + " TL";
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
