using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_Ziks4
{
    public partial class FormQuestion : Form
    {
        public FormQuestion()
        {
            InitializeComponent();
            Properties.Settings.Default.lokced1 = false;
            Properties.Settings.Default.lokced2 = false;
            Properties.Settings.Default.lokced3 = false;
            Properties.Settings.Default.lokced4 = false;
            Properties.Settings.Default.lokced11 = false;
            Properties.Settings.Default.lokced12 = false;
            Properties.Settings.Default.lokced13 = false;
            Properties.Settings.Default.lokced14 = false;
            Properties.Settings.Default.Save();
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
            checkBox4.Visible = false;
            button2.Visible = false;
        }

        private void FormQuestion_Load(object sender, EventArgs e)
        {
            
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox4.Visible = true;
            button1.Enabled = false;
            
            string[] lines = File.ReadAllLines(path: "C:/Users/Dmytro/Desktop/Quest.txt");
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            Random rnd4 = new Random();
            int rbd1 = rnd1.Next(0, 3);
            int rbd2 = rnd2.Next(3, 7);
            int rbd3 = rnd3.Next(7, 10);
            int rbd4 = rnd4.Next(10, 12);
            for (int i = 0; i < lines.Length; i++)
            {
                label1.Text = lines[rbd1];
                label2.Text = lines[rbd2];
                label3.Text = lines[rbd3];
                label4.Text = lines[rbd4];
            }
            //0
            if(rbd1 ==0)
            {
                Properties.Settings.Default.lokced1 = true;
                Properties.Settings.Default.Save();
            }
            //1-2
            if((rbd1 ==1)|(rbd1==2))
            {
                Properties.Settings.Default.lokced1 = false;
                Properties.Settings.Default.Save();
            }
            //3,5-6
            if ((rbd2 == 3) | (rbd2 == 5)|(rbd2==6))
            {
                Properties.Settings.Default.lokced2 = true;
                Properties.Settings.Default.Save();
            }
            //4
            if (rbd2 == 4)
            {
                Properties.Settings.Default.lokced2 = false;
                Properties.Settings.Default.Save();
            }
            //7,9
            if ((rbd3 == 7) | (rbd3 == 9))
            {
                Properties.Settings.Default.lokced3 = true;
                Properties.Settings.Default.Save();
            }
            //8
            if (rbd3 == 8)
            {
                Properties.Settings.Default.lokced3 = false;
                Properties.Settings.Default.Save();
            }
            //10-11
            if ((rbd4 == 10) | (rbd4 == 11))
            {
                Properties.Settings.Default.lokced4 = true;
                Properties.Settings.Default.Save();
            }

            Properties.Settings.Default.Save();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == false)
            {

                switch (checkBox1.Checked == Properties.Settings.Default.lokced1)
                {
                    case true:
                        Properties.Settings.Default.lokced11 = true;
                        Properties.Settings.Default.Save();
                        break;
                    case false:
                        Properties.Settings.Default.lokced11 = false;
                        Properties.Settings.Default.Save();
                        break;
                }
                switch (checkBox2.Checked == Properties.Settings.Default.lokced2)
                {
                    case true:
                        Properties.Settings.Default.lokced12 = true;
                        Properties.Settings.Default.Save();
                        break;
                    case false:
                        Properties.Settings.Default.lokced12 = false;
                        Properties.Settings.Default.Save();
                        break;
                }
                switch (checkBox3.Checked == Properties.Settings.Default.lokced3)
                {
                    case true:
                        Properties.Settings.Default.lokced13 = true;
                        Properties.Settings.Default.Save();
                        break;
                    case false:
                        Properties.Settings.Default.lokced13 = false;
                        Properties.Settings.Default.Save();
                        break;
                }
                
                switch (checkBox4.Checked == Properties.Settings.Default.lokced4)
                {
                    case true:
                        
                        Properties.Settings.Default.lokced14 = true;
                        Properties.Settings.Default.Save();
                       
                        break;
                    case false:
                        Properties.Settings.Default.lokced14 = false;
                        Properties.Settings.Default.Save();
                      
                        break;
                }
                if ((Properties.Settings.Default.lokced14 == true) &&
                    (Properties.Settings.Default.lokced13 == true) &&
                    (Properties.Settings.Default.lokced12 == true) &&
                    (Properties.Settings.Default.lokced11 == true))
                {
                    label5.Visible = true;
                    Properties.Settings.Default.Working_hours = false;
                    Properties.Settings.Default.Save();

                }
                else
                {
                    label5.ForeColor = Color.Red;
                    label5.Text = "Тест не пройдений";
                    label5.Visible = true;
                }
            }
        }
    }
}
