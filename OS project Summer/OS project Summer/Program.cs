using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_project_Summer
{
   
    static class Program
    {
        public static bool ac=true;
        public static List<string>Read()
        {
            List<string> s = new List<string>();


            DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            String temp = dirInfo.Parent.Parent.FullName;
            String path = Path.Combine(temp, "Resorsess", "data.txt");

            s=File.ReadAllLines(path).ToList();


            return s;
        }


        public static void Write(string s)
        {
            List<string> sum = new List<string>();
            sum = Read();

            for (int i = 0; i < sum.Count; i+=2) 
                if(sum[i].Equals(s))
                {
                    MessageBox.Show("this user name is already exist,please Try another one");
                    ac = false;
                    return;
                }



                sum.Add(s);

            DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            String temp = dirInfo.Parent.Parent.FullName;
            String path = Path.Combine(temp, "Resorsess", "data.txt");

            

            File.WriteAllLines(path,sum);


        }

        

        public static void Replace(string s,string n)
        {
            List<string> sum = new List<string>();
            sum = Read();


            for (int i = 0; i < sum.Count; i++)
            {
                if (sum[i].Equals(s))
                    sum[i + 1] = n;
                break;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(Directory.GetCurrentDirectory());
            String temp = dirInfo.Parent.Parent.FullName;
            String path = Path.Combine(temp, "Resorsess", "data.txt");

            

            File.WriteAllLines(path,sum);


        }





        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
