using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPS_WFA
{
    public partial class Form1 : Form
    {
        //declaring the variables for this game
        public int rounds = 3; // 3 rounds per game
        public int timePerRound = 6; // 5 seconds per rounds
        string[] AIchoice = { "rock", "paper", "scissors", "rock", "scissors", "paper" }; //enemy choice options stored inside an array for easy access
        public int randomNumber;
        string command;
        Random rnd = new Random();
        string playerChoice;
        int playerWins = 0;
        int AIwins = 0;
        // end of declaring variables

        public Form1()
        {
            InitializeComponent();
            String input = Microsoft.VisualBasic.Interaction.InputBox("Enter Your Name", "Rock - Paper - Scissors Game", "..", 0, 0);
            label2.Text = input;
            timer1.Enabled = true;
            playerChoice = "none";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = Convert.ToString(rounds);
            timePerRound--; // reduce the time by 1
            label4.Text = Convert.ToString(timePerRound); // show the time on the screen
            if (timePerRound < 1) // if the time is less then one second
            {
                timer1.Enabled = false; // we disable the timer if less then one second left
                timePerRound = 6; // set the timer back to 6 seconds
                randomNumber = rnd.Next(0, 5); // randomize the number again
                command = AIchoice[randomNumber]; // we set up the AI choice according to the random number
                
                // the switch statement below will show the AI choice and change the picture box images
                switch (command)
                {
                    case "rock":
                        pictureBox2.Image = Properties.Resources.Rock;
                        break;
                    case "paper":
                        pictureBox2.Image = Properties.Resources.Paper1;
                        break;
                    case "scissors":
                        pictureBox2.Image = Properties.Resources.Paper;
                        break;
                    default:
                        break;
                }
                // if we have more rounds to the play then we run the check game function
                if (rounds > 1)
                {
                    checkGame();
                }
                // if we dont have any more rounds to play then we go to the final decision engine
                else
                {
                    decisionEngine();
                }
            }
        }

        private void nextRound()
        {
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.UNK;
            timer1.Enabled = true;
            pictureBox2.Image = Properties.Resources.UNK;
        }

        private void ROCK_Click(object sender, EventArgs e)
        {
            playerChoice = "rock";
            pictureBox1.Image = Properties.Resources.Rock;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            playerChoice = "paper";
            pictureBox1.Image = Properties.Resources.Paper1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            playerChoice = "scissors";
            pictureBox1.Image = Properties.Resources.Paper;
        }

        private void checkGame()
        {
            if (playerChoice == "rock" && command == "paper")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "rock")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "paper" && command == "scissors")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissors" && command == "paper")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "scissors" && command == "rock")
            {
                MessageBox.Show("AI Wins");
                AIwins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "rock" && command == "scissors")
            {
                MessageBox.Show("player Wins");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show(label2.Text + " Make a choice");
                nextRound();
            }
            else
            {
                MessageBox.Show("Draw");
                nextRound();
            }
        }

             

        private void label3_Click(object sender, EventArgs e)
        {
            return;
        }

        

        

        private void decisionEngine()
        {
            if (playerWins > AIwins)
            {
                label3.Text = label2.Text + "Wins the game";
            }
            else
            {
                label3.Text = "AI Wins the game";
            }
        }
    }

}
