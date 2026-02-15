using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sinav
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
       
        private void Form2_Load(object sender, EventArgs e)
        {
            label8.Text=Form1.odano.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();
            
            MySqlCommand kaydet = new MySqlCommand();
            kaydet.CommandText = "insert into musteri values(@tc,@ad,@soyad,@tel,@cinsiyet,@odano,@yatakno)";
            kaydet.Connection = baglan;
            kaydet.Parameters.Add("@tc",textBox2.Text);//tc, ad,soyad,tel,cinsiyet,odano,yatakno
            kaydet.Parameters.Add("@ad", textBox3.Text);
            kaydet.Parameters.Add("@soyad", textBox4.Text);
            kaydet.Parameters.Add("@tel", textBox5.Text);
            kaydet.Parameters.Add("@odano",Form1.odano);
            if (radioButton1.Checked == true)
            {
                kaydet.Parameters.Add("@cinsiyet",radioButton1.Text);
            }
            else
            {
                kaydet.Parameters.Add("@cinsiyet",radioButton2.Text);
            }
            kaydet.Parameters.Add("@yatakno",int.Parse(textBox1.Text));
            if (kaydet.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Kayıt başarıyla kaydedildi.");
            }
            else
            {
                MessageBox.Show("başarısız");
            }

            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();

            MySqlCommand ara = new MySqlCommand();
            ara.CommandText = "select * from musteri where yatakno=@1 and odano=@2";
            ara.Connection = baglan;
            ara.Parameters.Add("@1",textBox1.Text);
            ara.Parameters.Add("@2",Form1.odano);
            MySqlDataReader oku;
            oku = ara.ExecuteReader();
            if (oku.HasRows == true)
            {
                
                MessageBox.Show("kayıt var");
                button2.Enabled = false;
            }
            else
            {
                MessageBox.Show("BOŞ");
            }

            baglan.Close();
        }
    }
}
