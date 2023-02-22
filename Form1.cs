using System;
using System.Windows.Forms;
using System.Media;

namespace demonstrationProject
{
    public partial class Form1 : Form
    {
        /*Purpose: create a memorization game that gives random numbers which the user must input in the form of buttons
         * Input: Button presses
         * Output: Win or Loss
         */

        //creating variables and timer
        string correctAnswer, userInput, pBoxName;
        int btnPresses, count;
        System.Windows.Forms.Timer timer1;

        //creates sound player
        SoundPlayer funneeeBoom = new SoundPlayer("vine-boom.wav");

        public Form1()
        {
            InitializeComponent();
        }

        public void onButtonPress()//happens every time a game button is pressed after start, adds to a counter and if 5 buttons are pressed, ends and resets game
        {
            btnPresses += 1;
            if (btnPresses >= Convert.ToInt16(cmbDifficultySelect.SelectedItem))//occurs when the user presses number of buttons determined by difficulty
            {
                timer1.Dispose();//deletes timer after game is played to reduce memory usage

                //disables all game buttons, enables the start button and difficulty select for next attempt
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;
                button8.Enabled = false;
                button9.Enabled = false;
                btnStart.Enabled = true;
                cmbDifficultySelect.Enabled = true;

                if (userInput == correctAnswer)//shows message box based on whether or not the user was correct
                {
                    MessageBox.Show("Correct Answer");//correct answer
                }
                else
                {
                    MessageBox.Show("Incorrect Answer");//incorrect answer
                }
            }
        }
        private void btnStart_Click(object sender, EventArgs e)//user presses start
        {
            //resets variables
            correctAnswer = "";
            userInput = "";
            pBoxName = "";
            count = 0;
            btnPresses = 0;

            if (cmbDifficultySelect.SelectedIndex == -1)//checks for blank combo box
            {
                MessageBox.Show("Please Select a Difficulty");
            }
            else//runs program if difficulty is selected
            {
                //disables start and combo box
                btnStart.Enabled = false;
                cmbDifficultySelect.Enabled = false;

                //creates the order for that attempt
                Random rnd = new Random();
                for (int i = 0; i < Convert.ToInt16(cmbDifficultySelect.SelectedItem); ++i)
                {
                    int num = rnd.Next(1, 10);
                    correctAnswer += num;
                }

                //enables timer to show correct buttons
                timer1 = new System.Windows.Forms.Timer();
                timer1.Interval = 1000;
                timer1.Enabled = true;
                timer1.Tick += new System.EventHandler(OnTimerEvent);
            }
        }
        private void OnTimerEvent(object sender, EventArgs e)//happens every half second after start is pressed
        {
            if (count == correctAnswer.Length)//if all images have been shown, enable game
            {
                timer1.Enabled = false;
                this.Controls[pBoxName].Visible = false;

                //enables all game buttons
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
            else//continue to show pictures if not all have been shown
            {
                for (int i = 1; i < 10; ++i)
                {
                    pBoxName = "pBox" + i.ToString();
                    this.Controls[pBoxName].Visible = false;
                }

                pBoxName = "pBox" + correctAnswer[count].ToString();
                this.Controls[pBoxName].Visible = true;
                funneeeBoom.Play();
                count++;
            }

        }
        //buttons 1-9, adds to user input string which is checked against the correct answer and adds to a variable which ends the game at 5
        private void button1_Click(object sender, EventArgs e)
        {
            userInput += "1";
            onButtonPress();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userInput += "2";
            onButtonPress();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userInput += "3";
            onButtonPress();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            userInput += "4";
            onButtonPress();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            userInput += "5";
            onButtonPress();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            userInput += "6";
            onButtonPress();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            userInput += "7";
            onButtonPress();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            userInput += "8";
            onButtonPress();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            userInput += "9";
            onButtonPress();
        }
    }
}