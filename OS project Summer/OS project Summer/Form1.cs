using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace OS_project_Summer
{
    

    public partial class Form1 : Form
    {
        static List<Button> Box = new List<Button>();
        static int count = 0;
       


        public Form1()
        {
            InitializeComponent();
            foreach (Button i in this.PlayingSpace.Controls)
            {
                Box.Add(i);
            }
           
          
           
        }


        int movesNumber = 0, labelIndex = 0;

        private void shuffleButtons()
        {
            List<int> labelList = new List<int>();
            Random rand = new Random();           

            foreach (Button i in this.PlayingSpace.Controls)
            {
                while (labelList.Contains(labelIndex))
                    labelIndex = rand.Next(16);

                i.Text = (labelIndex == 0) ? "" : labelIndex + "";
                i.BackColor = (i.Text == "") ? Color.White : Color.FromKnownColor(KnownColor.ControlLightLight);
                labelList.Add(labelIndex);
            }

            movesNumber = 0;
            label1.Text = "Number Of moves : " + movesNumber;
        }

        //This Method has the threads
        private void swapLabel(Object sender, EventArgs e)
        {
            int r=0;
            List<string> s = new List<string>();
            Button btn = (Button)sender;
            if (btn.Text == "")
                return;
            Button whiteBtn = null;
            foreach (Button bt in this.PlayingSpace.Controls)
                if (bt.Text == "")
                {
                    whiteBtn = bt;
                    break;
                }

            if (btn.TabIndex == (whiteBtn.TabIndex - 1) ||
                btn.TabIndex == (whiteBtn.TabIndex - 4) ||
                btn.TabIndex == (whiteBtn.TabIndex + 1) ||
                btn.TabIndex == (whiteBtn.TabIndex + 4))
            {
                whiteBtn.BackColor = Color.FromKnownColor(KnownColor.ControlLight);
                btn.BackColor = Color.White;
                whiteBtn.Text = btn.Text;
                btn.Text = "";
                movesNumber++;
                label1.Text = $"Numver of moves : {movesNumber}";
            }

          
            Thread t1 = new Thread(CheckRow1);
            Thread t2 = new Thread(CheckRow2);
            Thread t3 = new Thread(CheckRow3);
            Thread t4 = new Thread(CheckRow4);
            Thread[] all={t1,t2,t3,t4};
            Stopwatch stp = new Stopwatch();
            TimeSpan Total;

            stp.Start();
            t1.Start();
            stp.Stop();
            TimeSpan ts = stp.Elapsed;
            label4.Text = ts.ToString();
            Total = ts;

            stp.Start();
            t2.Start();
            stp.Stop();
            ts = stp.Elapsed;
            label5.Text = ts.ToString();
            Total += ts;
            
            stp.Start();
            t3.Start();
            stp.Stop();
            ts = stp.Elapsed;
            label6.Text = ts.ToString();
            Total += ts;

            stp.Start();
            t4.Start();
            stp.Stop();
            ts = stp.Elapsed;
            label7.Text = ts.ToString();
            Total += ts;

            label13.Text = Total.ToString();

            Join(ref all);
            if (count == 15)
            {
                MessageBox.Show($"Congratulations!\nYou did it in {movesNumber} moves");
                s = Program.Read();
                for (int i = 0; i < s.Count; i++)
                    if (s[i].Equals(label3.Text))
                    {
                        r = int.Parse(s[i + 1]);
                        break;
                    }

                if (r > movesNumber)
                {
                    Program.Replace(label3.Text, $"{movesNumber}");
                    label2.Text = $"Best score: {movesNumber}";
                }
                
                shuffleButtons();
            }
            count = 0;
        }

        void Join(ref Thread[] t) 
        {
            t[0].Join();
            t[1].Join();
            t[2].Join();
            t[3].Join();          
        }

        private static void CheckRow1()
        {
        
            int n = 1,c=0;

            for (int i = 15; i > 11; i--)
                if (Box[i].Text.Equals($"{n++}"))
                    c++;
            count += c;        
        }
        
        private static void CheckRow2()
        {
    
            int n = 5,c=0;

            for (int i = 11; i > 7; i--)
                if (Box[i].Text.Equals($"{n++}"))
                    c++;
            count += c;           
        }

        private static void CheckRow3()
        {
       
            int n = 9, c = 0;

            for (int i = 7; i > 3; i--)
                if (Box[i].Text.Equals($"{n++}"))
                    c++;
            count+= c;
        }
        
        private static void CheckRow4()
        {
     
            int n = 13, c = 0;

            for (int i = 3; i > 0; i--)
                if (Box[i].Text.Equals($"{n++}"))
                    c++;
            count += c;
        }




        private void Form1_Load(object sender, EventArgs e)
        {

            shuffleButtons();
            PlayingSpace.BackColor = Color.FromArgb(100, 0, 0, 0);
            label3.Text = Form2.name;
            List<string> s = new List<string>();
            s = Program.Read();

            for (int i = 0; i < s.Count; i++)
                if (s[i].Equals(label3.Text))
                {
                    label2.Text += s[i + 1];
                    break;
                }
          
        }



        private void PlayingSpace_Paint(object sender, PaintEventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            shuffleButtons();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //Application.OpenForms[0].Show();
            System.Windows.Forms.Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}