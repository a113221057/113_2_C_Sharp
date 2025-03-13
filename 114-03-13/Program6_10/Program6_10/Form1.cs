using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program6_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random rand = new Random();
        string compChoice, myChoice, winner;

        private void Form1_Load(object sender, EventArgs e)
        {
            getCompChoice();
        }

        private void getCompChoice()
        {
            
        }

        private void showWinner()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myChoice = "Rock";
            showWinner();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myChoice = "Paper";
            showWinner();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myChoice = "Scissors";
            showWinner();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            getCompChoice();
        }


    }
}
