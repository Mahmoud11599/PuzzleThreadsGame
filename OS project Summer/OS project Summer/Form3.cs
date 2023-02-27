using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_project_Summer
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            
            this.Close();
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Equals(null) && !textBox1.Text.Equals(""))
            {
                Program.Write(textBox1.Text);
                if (Program.ac)
                {
                    Program.Write("0");
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();
                }
                else if (!Program.ac) { Program.ac = true; }
            }           
            else MessageBox.Show("Please tybe something first");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
