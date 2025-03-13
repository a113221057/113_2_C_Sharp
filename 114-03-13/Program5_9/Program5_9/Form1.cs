using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program5_9
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            int n1 = rand.Next(1, 7);
            int n2 = rand.Next(1,7);
            switch (n1) //顯示第一個圖片框圖片
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.Die1;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources.Die2;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources.Die3;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources.Die4;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources.Die5;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources.Die6;
                    break;
            }
            switch (n2)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources.Die1;
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources.Die2;
                    break;
                    case 3:
                    pictureBox2.Image = Properties.Resources.Die3;
                    break;
                case 4:
                  pictureBox2.Image = Properties.Resources.Die4;
                    break;
                case 5:
                    pictureBox2.Image = Properties.Resources.Die5;
                    break;
                case 6:
                    pictureBox2.Image = Properties.Resources.Die6;
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
