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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listeleme();
        }
        private void listeleme()
        {
            listView1.Items.Clear();
            OleDbConnection conn = veritabani.baglanti();
            OleDbCommand komut = new OleDbCommand();
            OleDbDataReader dr;
            komut.Connection = conn;
            if (comboBox1.Text == "SEÇİM YOK") { comboBox1.Text = ""; }
            komut = new OleDbCommand("select * from tiyatroo WHERE (((tiyatroo.[oyunadi]) Like '" + textBox1.Text + "%') AND ((tiyatroo.yazar) Like '" + textBox2.Text + "%') AND ((tiyatroo.oyuncusayisi) Like '" + textBox3.Text + "%') AND ((tiyatroo.erkeksayisi) Like '" + textBox4.Text + "%') AND ((tiyatroo.kadinsayisi) Like '" + textBox5.Text + "%') AND ((tiyatroo.dekor) Like '" + textBox6.Text + "%') AND ((tiyatroo.bolum) Like '" + textBox7.Text + "%') AND ((tiyatroo.oyunturu) Like '" + comboBox1.Text + "%'))", conn);
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
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            admingir goster = new admingir();
            goster.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            listeleme();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            listeleme();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listeleme();
        }
    }
}
