using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace OS_project_Summer
{
    public partial class Form2 : Form
    {
        public static string name;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            List<string> s = new List<string>();
            s = Program.Read();
            for (int i = 0; i < s.Count; i += 2)
                comboBox1.Items.Add(s[i]);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 200, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (comboBox1.Text != "Please choose one...")
            {
                name = comboBox1.Text;
                this.Hide();
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            else if (comboBox1.Text == "Please choose one...")
                MessageBox.Show("Please sellect user name first");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
