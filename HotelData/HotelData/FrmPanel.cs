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

namespace HotelData
{
    public partial class FrmPanel : Form
    {
        public FrmPanel()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection("Data Source = SERKANKAYA ; Initial Catalog = hotelData ; Integrated Security = True");



        private void showDb()
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *from visitors",connect);
            SqlDataReader read = command.ExecuteReader();
            while(read.Read()) 
            {
                ListViewItem add = new ListViewItem();
                add.Text = read["ID"].ToString();
                add.SubItems.Add(read["Ad"].ToString());
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Oda"].ToString());
                add.SubItems.Add(read["Giris"].ToString());
                add.SubItems.Add(read["TCNo"].ToString());
                add.SubItems.Add(read["TelefonNo"].ToString());
                add.SubItems.Add(read["Cikis"].ToString());
                add.SubItems.Add(read["Tutar"].ToString());

                listView1.Items.Add(add);
            }
            connect.Close();
        }

        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enabledOff();
            listView1.Visible = false;
            button6.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox8.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            button7.Visible = false;

            connect.Open();
            SqlCommand command = new SqlCommand("Select *from BosOdalar",connect);
            SqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                comboBox1.Items.Add(read[0].ToString());
            }
            connect.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button6.Visible = true;
            button5.Visible = false;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox8.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
            pictureBox5.Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            button6.Visible = false;
            button5.Visible = true;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox8.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView1.Visible = true;
            showDb();
            enabledOn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand addData = new SqlCommand("Insert into visitors (ID,Ad,Soyad,Oda,Giris,TCNo,TelefonNo,Cikis,Tutar) values ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + dateTimePicker1.Text.ToString() + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','" + textBox9.Text.ToString() + "')", connect);
            addData.ExecuteNonQuery();

            addData.CommandText = "insert into DoluOdalar(DoluYerler) values ('" + comboBox1.Text + "')";
            addData.ExecuteNonQuery();

            addData.CommandText = "delete from BosOdalar where BosYerler = '" + comboBox1.Text + "'";
            addData.ExecuteNonQuery();
            
            connect.Close();
            comboBox1.Text = "Müsait Odalar";
            button4.Visible = false;
            button7.Visible = true;
            
            showDb();
            temizle();
        }

        private void enabledOff()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox9.Enabled = false;
            comboBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            checkBox1.Enabled = false;
            label15.Visible = true;
        }

        private void enabledOn()
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox9.Enabled = true;
            comboBox1.Enabled = true;
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            checkBox1.Enabled = true;
            label15.Visible = false;
        }


        int id = 0;
       private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand delete = new SqlCommand("Delete from visitors where ID = ("+id+")",connect);
            delete.ExecuteNonQuery();

            delete.CommandText = "insert into BosOdalar(BosYerler) values ('" + comboBox1.Text + "')";
            delete.ExecuteNonQuery();

            delete.CommandText = "Delete from DoluOdalar where DoluYerler = '"+comboBox1.Text+"'";
            delete.ExecuteNonQuery();

            

            connect.Close();
            
            showDb();
            temizle();
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            connect.Open();
            SqlCommand update = new SqlCommand("Update visitors set ID='" + textBox1.Text.ToString() + "',Ad='" + textBox2.Text.ToString() + "',Soyad='" + textBox3.Text.ToString() + "',Oda='" + comboBox1.Text.ToString() + "',Giris='" + dateTimePicker1.Text.ToString() + "',TCNo='" + textBox6.Text.ToString() + "',TelefonNo='" + textBox7.Text.ToString() + "',Cikis='" + dateTimePicker2.Text.ToString() + "',Tutar='" + textBox9.Text.ToString() + "' where ID = " + id+ " ", connect);
            update.ExecuteNonQuery();
            connect.Close();
            showDb();
            temizle();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            dateTimePicker1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[5].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[6].Text;
            dateTimePicker2.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *from visitors where ID like '%" + textBox4.Text + "%' ", connect);
            SqlDataReader read = command.ExecuteReader();
            while(read.Read())
            {
                ListViewItem add = new ListViewItem();

                add.Text = read["ID"].ToString();
                add.SubItems.Add(read["Ad"].ToString());
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Oda"].ToString());
                add.SubItems.Add(read["Giris"].ToString());
                add.SubItems.Add(read["TCNo"].ToString());
                add.SubItems.Add(read["TelefonNo"].ToString());
                add.SubItems.Add(read["Cikis"].ToString());
                add.SubItems.Add(read["Tutar"].ToString());

                listView1.Items.Add(add);
            }
            connect.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *from visitors where Ad like '%" + textBox5.Text + "%' ", connect);
            SqlDataReader read = command.ExecuteReader();
            while(read.Read())
            {
                ListViewItem add = new ListViewItem();

                add.Text = read["ID"].ToString();
                add.SubItems.Add(read["Ad"].ToString());
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Oda"].ToString());
                add.SubItems.Add(read["Giris"].ToString());
                add.SubItems.Add(read["TCNo"].ToString());
                add.SubItems.Add(read["TelefonNo"].ToString());
                add.SubItems.Add(read["Cikis"].ToString());
                add.SubItems.Add(read["Tutar"].ToString());

                listView1.Items.Add(add);

            }
            connect.Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            connect.Open();
            SqlCommand command = new SqlCommand("Select *from visitors where Soyad like '%" + textBox8.Text + "%'", connect);
            SqlDataReader read = command.ExecuteReader();
            while(read.Read())
            {
                ListViewItem add = new ListViewItem();

                add.Text = read["ID"].ToString();
                add.SubItems.Add(read["Ad"].ToString());
                add.SubItems.Add(read["Soyad"].ToString());
                add.SubItems.Add(read["Oda"].ToString());
                add.SubItems.Add(read["Giris"].ToString());
                add.SubItems.Add(read["TCNo"].ToString());
                add.SubItems.Add(read["TelefonNo"].ToString());
                add.SubItems.Add(read["Cikis"].ToString());
                add.SubItems.Add(read["Tutar"].ToString());

                listView1.Items.Add(add);
            }
            connect.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Text = "Müsait Odalar";
            connect.Open();
            SqlCommand komut = new SqlCommand("Select *from BosOdalar", connect);
            SqlDataReader oda = komut.ExecuteReader();
            while (oda.Read())
            {
                comboBox1.Items.Add(oda[0].ToString());
            }
            connect.Close();
            button4.Visible = true;
            button7.Visible = false;
            comboBox1.Enabled = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
