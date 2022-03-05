/*
* Filename		:	EntryPage.cs
* Project		:	RDB - Assignment 04 
* Programmer	:	Deep Patel & Dhruvanshi Ghiya
* First Version	:	10/12/2021
* Description	:	This form acts as the login page of the application
*                   Contains methods to get userName and jumps to start the quiz
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace A04_Quiz
{
    /* 
     * Name      : EntryPage
     * Purpose   : The purpose of this class is to set up an actively running quiz. 
     *             This form is responsible the page where user inserts its login information
     *             It verifies details entered and jumps to start the quiz
     */
    public partial class EntryPage : Form
    {
        // Initializations
        private string EnteredUserName;

        /*  -- Method Header Comment
	    * Name	    :	EntryPage -- CONSTRUCTOR
	    * Purpose   :	It will initializes all the members of EntryPage class.
	    *               It will also act as entry page to to the quiz and get login info from user
	    * Inputs	:	NONE
	    * Outputs	:	NONE
	    * Returns	:	Nothing
        */
        public EntryPage()
        {
            InitializeComponent();

            // Instructions to keep in mind whilst entering details
            instructions.Text = "1. You must enter your name in the box below.\n2. Timer is set to 20 seconds. Each second wasted drops the point value by 1.\n";
            instructions.Text += "3. You can't comeback to the last question after going to the next page.\n4. At the end of quiz, Leaderboard will display 5 users of quiz with the highest score.";
            
            // Warning disabled
            usernameWarningLabel.Visible = false;
            EnteredUserName = "";
        }

        /* 
         * Name      : QuestionQuiz
         * Purpose   : The purpose of this class is to set up an actively running quiz. 
         *             This form is responsible the page where user actually enters its userDetails previos to starting the quiz
         *             It is termed the login page.
         *             Also jumps to where user can actually play the quiz if details entered are correct.
         */
        private void StartQuiz_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserNameTextBox.Text != "")
                {
                    // Store username in the text box
                    EnteredUserName = UserNameTextBox.Text;

                    // Instantialte a new QuestionQuiz page
                    QuestionQuiz page = new QuestionQuiz(EnteredUserName);

                    // Ensure instantiated page is visible
                    page.Show();

                }
                else
                {
                    // Enable warning
                    usernameWarningLabel.Visible = true;

                    // Ensure warning appears in red
                    usernameWarningLabel.ForeColor = Color.Red;

                    // Warning text
                    const string message = "- You need to enter something to play the quiz.";
                    usernameWarningLabel.Text = message;
                }
            }
            catch (Exception ex)
            {
                // Error message if exception occurs
                MessageBox.Show(ex.Message);
                this.Close();
            }
            
            
        }
    }
}
