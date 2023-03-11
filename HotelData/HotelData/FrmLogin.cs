using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelData
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == "admin" && textBox2.Text == "12345")
            {
                FrmPanel panel = new FrmPanel();
                panel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen tekrar deneyiniz.");
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            if (textBox3.Text == "")
            {
                textBox3.Text = "kullanıcı adınızı giriniz";
                textBox1.Focus();
            }
        }

        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.Text = "";
            if (textBox2.Text == "")
            {
                textBox2.Text = "kullanıcı adınızı giriniz";
                textBox1.Focus();
            }

        }

        private void FrmLogin_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "kullanıcı adınızı giriniz";
                textBox1.Focus();
            }
            if (textBox2.Text == "")
            {
                textBox2.Text = "şifrenizi giriniz";
                textBox1.Focus();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState =  FormWindowState.Minimized;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen servisimizi arayarak iletişime geçiniz.");
        }
    }
}
