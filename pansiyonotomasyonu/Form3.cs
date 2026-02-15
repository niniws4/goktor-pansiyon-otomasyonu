using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sinav
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();

            MySqlCommand listele = new MySqlCommand();
            listele.CommandText = "select * from musteri";
            listele.Connection = baglan;
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(listele);
            adp.Fill(ds,"musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];


            label3.Text = "";
            baglan.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int secilensatir = dataGridView1.CurrentRow.Index;
            
            textBox1.Text = dataGridView1.Rows[secilensatir].Cells["tckimlik"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilensatir].Cells["ad"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilensatir].Cells["soyad"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilensatir].Cells["tel"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[secilensatir].Cells["cinsiyet"].Value.ToString();
            textBox6.Text = dataGridView1.Rows[secilensatir].Cells["odano"].Value.ToString();
            textBox7.Text = dataGridView1.Rows[secilensatir].Cells["yatakno"].Value.ToString();
            label3.Text = textBox1.Text;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();

            MySqlCommand guncelle = new MySqlCommand();
            guncelle.CommandText = "update musteri set ad=@2,soyad=@3,tel=@4,cinsiyet=@5,odano=@6,yatakno=@7 where tckimlik=@1";
            guncelle.Connection = baglan;

            guncelle.Parameters.Add("@1",textBox1.Text);
            guncelle.Parameters.Add("@2",textBox2.Text);
            guncelle.Parameters.Add("@3",textBox3.Text);
            guncelle.Parameters.Add("@4", textBox4.Text);
            guncelle.Parameters.Add("@5", textBox5.Text);
            guncelle.Parameters.Add("@6", textBox6.Text);
            guncelle.Parameters.Add("@7", textBox7.Text);
            if (guncelle.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Başarıyla düzeltildi.");
            }
            else
            {
                MessageBox.Show("başarısız");
            }

            baglan.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();

            MySqlCommand listele = new MySqlCommand();
            listele.CommandText = "select * from musteri";
            listele.Connection = baglan;
            DataSet ds = new DataSet();
            MySqlDataAdapter adp = new MySqlDataAdapter(listele);
            adp.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];


            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlConnection baglan = new MySqlConnection();
            baglan.ConnectionString = "server=localhost;user=root;password='';database=pansiyon";
            baglan.Open();

            MySqlCommand sil = new MySqlCommand();
            sil.CommandText = "delete from musteri where tckimlik=@1";
            sil.Connection = baglan;
            sil.Parameters.Add("@1",textBox1.Text);
            if (sil.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Başarıyla silindi.");
            }
            else
            {
                MessageBox.Show("başarısız.");
            }
            baglan.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
