using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {

        bool turn = true;
        int count = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Harpriya", "About Game");

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button(object sender, EventArgs e)
        {
            Button press = (Button)sender;
            if (turn)
                press.Text = "X";
            else
                press.Text = "O";
            turn = !turn;
            press.Enabled = false;
            count++;

            check_for_winner();
        }

    // Checking For Winner
        private void check_for_winner()
        {
            // horizontal checks
            bool winner_present = false;

            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (A1.Enabled == false))
                winner_present = true;
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (B1.Enabled == false)) 
                winner_present = true;
            else if((C1.Text == C2.Text) && (C2.Text == C3.Text) && (C1.Enabled == false))
                winner_present = true;

            // vertical checks
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (A1.Enabled == false))
                winner_present = true;
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (A2.Enabled == false))
                winner_present = true;
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (A3.Enabled == false))
                winner_present = true;

            // diagonal checks
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (A1.Enabled == false))
                winner_present = true;
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (A3.Enabled == false))
                winner_present = true;


    // Winner Declaration
            if (winner_present == true)
            {
                disableButtons();
                String winner = "";
                if (turn == true)
                    winner = "O ";
                else
                    winner = "X ";

                MessageBox.Show(winner + "Wins!", "Congratulations!");
            } //end Winner Declaration

            else if (count == 9)
                MessageBox.Show("It's a Draw!", "Try again!");
            
        } // end Checking For Winner

      
        
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button press = (Button)c;
                    press.Enabled = false;
                }
            }
            catch { }
           
        }



        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button press = (Button)c;
                    press.Enabled = true;
                    press.Text = "";
                }
            }
            catch { }
        }
    }
}
