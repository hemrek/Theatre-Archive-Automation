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
using System.Data.OleDb;

namespace TheatreArchive
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            listView1.FullRowSelect = true;
            listView1.MultiSelect = false;

            listeleme();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = veritabani.baglanti();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            komut = new OleDbCommand("SELECT Count(*) FROM tiyatroo WHERE oyunadi='" + textBox1.Text + "';", conn);
            int oyunsayisi = Convert.ToInt32(komut.ExecuteScalar());
            if (oyunsayisi == 0)
            {
                komut.CommandText = "insert into tiyatroo(oyunadi,yazar,oyuncusayisi,erkeksayisi,kadinsayisi,dekor,bolum,oyunturu) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.Text + "')";
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı...");
            }
            else
            {
                MessageBox.Show("Bu Kayıt Mevcut...");
            }
            listeleme();
            conn.Close();
        }

        private void listeleme()
        {
            listView1.Items.Clear();
            OleDbConnection conn = veritabani.baglanti();
            OleDbCommand komut = new OleDbCommand();
            OleDbDataReader dr;
            komut.Connection = conn;
            if (comboBox1.Text == "SEÇİM YOK") { comboBox1.Text = ""; }
            komut = new OleDbCommand("select * from tiyatroo ", conn);
            dr = komut.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem item = new ListViewItem(dr["Kimlik"].ToString());
                item.SubItems.Add(dr["oyunadi"].ToString());
                item.SubItems.Add(dr["yazar"].ToString());
                item.SubItems.Add(dr["oyuncusayisi"].ToString());
                item.SubItems.Add(dr["erkeksayisi"].ToString());
                item.SubItems.Add(dr["kadinsayisi"].ToString());
                item.SubItems.Add(dr["dekor"].ToString());
                item.SubItems.Add(dr["bolum"].ToString());
                item.SubItems.Add(dr["oyunturu"].ToString());
                listView1.Items.Add(item);
            }
            conn.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            listeleme();
        }

        private void temizle(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminekle ara = new adminekle();
            ara.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = veritabani.baglanti();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = conn;
            if (listView1.SelectedIndices.Count > 0)
            {
                komut.CommandText = "Delete from tiyatroo where Kimlik=" + listView1.SelectedItems[0].Text + "";
                komut.ExecuteNonQuery();
            }
            else MessageBox.Show("Seçili bir alan yok.");
            conn.Close();
            listeleme();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 geri = new Form1();
            geri.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
