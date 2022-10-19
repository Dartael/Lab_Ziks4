using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_Ziks4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Properties.Settings.Default.Working_hours = true;
            timer1.Interval = 10;
            button1.Text = "Пройти тест";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        int s = 0;
        int m = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            
            switch (Properties.Settings.Default.Working_hours)
            {
                case true:
                    button1.Text = "Почати роботу";
                    bool isOpen = false;
                    foreach (Form read in Application.OpenForms)
                    {
                        if (read.Text == "FormQuestion")
                        {
                            isOpen = true;
                            read.Focus();
                            read.WindowState = FormWindowState.Normal;
                            break;
                        }
                    }
                    if (isOpen == false)
                    {

                        FormQuestion reader = new FormQuestion();
                        reader.Show();
                        reader.WindowState = FormWindowState.Normal;
                    }
                    break;
                case false:
                    timer1.Enabled = true;
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (s < 59)
            {
                s++;
                if (s < 10)
                {
                    label3.Text = "0" + s.ToString();
                }
                else
                {
                    label3.Text = s.ToString();
                }
            }
            else
            {
                if (m < 59)
                {
                    m++;
                    if (m < 10)
                    {
                        labeltims.Text = "0" + m.ToString();
                        s = 0;
                        label3.Text = "00";
                        if (m == 5)
                        {
                            timer1.Enabled = false;
                            m = 0;
                            s = 0;
                            label3.Text = "00";
                            labeltims.Text = "00";
                            button1.Text = "Пройти тест";
                            Properties.Settings.Default.Working_hours = true;
                            bool isOpen = false;
                            foreach (Form read in Application.OpenForms)
                            {
                                if (read.Text == "FormQuestion")
                                {
                                    button1.Text = "Почати роботу";
                                    isOpen = true;
                                    read.Focus();
                                    read.WindowState = FormWindowState.Normal;
                                    break;
                                }
                            }
                            if (isOpen == false)
                            {

                                FormQuestion reader = new FormQuestion();
                                reader.Show();
                                reader.WindowState = FormWindowState.Normal;
                            }
                        }
                    }
                    else
                    {
                        labeltims.Text = m.ToString();

                    }

                }
            }
        }
    }
}
