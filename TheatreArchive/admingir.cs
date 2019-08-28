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
    public partial class admingir : Form
    {
        public admingir()
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
                OleDbDataReader dr;
                komut.Connection = conn;
                komut.CommandText = "SELECT * FROM admin where id='" + textBox1.Text + "' AND sifre='" + textBox2.Text + "'";
                dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    Form2 ara = new Form2();
                    ara.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
                }

                conn.Close();
            }
        }

        private void admingir_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();
            this.Hide();
        }
    }
}
