using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheatreArchive
{
    public partial class adminekle : Form
    {
        public adminekle()
        {
            InitializeComponent();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                OleDbConnection conn = veritabani.baglanti();
                OleDbCommand komut = new OleDbCommand();
                komut.Connection = conn;
                if (textBox2.Text == textBox3.Text)
                {
                    komut.CommandText = "insert into admin(id,sifre) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarılı...");
                    Form2 ara = new Form2();
                    ara.Show();
                    this.Hide();
                }
                else
                {
                MessageBox.Show("Şifreler Uyuşmuyor...");
                }
                conn.Close();
            }
        }

        private void admingir_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 geri = new Form2();
            geri.Show();
            this.Hide();
        }
    }
}
