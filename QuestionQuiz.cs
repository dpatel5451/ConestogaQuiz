/*
* Filename		:	QuestionQuiz.cs
* Project		:	RDB - Assignment 04 
* Programmer	:	Deep Patel & Dhruvanshi Ghiya
* First Version	:	10/12/2021
* Description	:	This form contains all the methodes required to play the quiz
*                   Retreives Questions, Options and the correct answer
*                   Checks users current score and updates it to the leaderboard
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
using System.Windows;
using MySql.Data.MySqlClient;

/*
* Title : .Net Connector C#
* Author : Darryl Poworoznyk
* Date : 2021-12-10
* Version : 1.1.26
* Availability : https://conestoga.desire2learn.com/d2l/le/content/483721/Home
*/

namespace A04_Quiz
{
    /* 
     * Name      : QuestionQuiz
     * Purpose   : The purpose of this class is to set up an actively running quiz. 
     *             This form is responsible the page where user actually takes the quiz.
     *             It is interconnected to login page. 
     *             Also counts final score 
     */
    public partial class QuestionQuiz : Form
    {
        // This integer variable keeps track of the 
        // remaining time.
        private int timeLeft;

        // Tracks the current question
        private int currentQuestion;

        // Tracks the current score
        private int score;

        // Tracks the entered username
        private string testTakerName;

        // Tracks the entered UserID
        private string databaseUserID;

        // Verifies the entered password
        private string databasePassword;

        // Checks the entered server
        private string databaseServer;

        // Tracks userRecord
        private string userRecord;

        // Stores the selected option
        private string choosenOption;

        // Saves all the SQL Data for easy access
        private string sqlData;

        // String split wikt ","
        private string[] sqlDataSplit;

        /*  -- Method Header Comment
         * Name	    :	QuestionQuiz --CONSTRUCTOR
         * Purpose   :	It will initializes all the members of QuestionQuiz class.
         *               It will also store sqlData entered.
         * Inputs	:	userName     -   string
         * Outputs	:	NONE
         * Returns	:	currentQuestion
         */
        public QuestionQuiz(string userName)
        {
            // Get data from text file
            sqlData = System.IO.File.ReadAllText("0SqlData.txt");

            // Split data into server, userID and password
            sqlDataSplit = sqlData.Split(',');
            databaseServer = sqlDataSplit[0];
            databaseUserID = sqlDataSplit[1];
            databasePassword = sqlDataSplit[2];

            //Store entered userName
            testTakerName = userName;

            // Intializations
            score = 0;
            timeLeft = 0;
            currentQuestion = 1;
            userRecord = "";
            choosenOption = "";
            InitializeComponent();

            //Turn userName warning off at the moment
            Warning.Visible = false;

            // Load the current question
            QuestionQuiz_FormLoad(currentQuestion);
        }


       /*  -- Method Header Comment
        * Name	:	QuestionQuiz_FormLoad 
        * Purpose :	The purpose of this method is to start the timer, retreive questions and its options
        * Inputs	:	questionNumber --INT
        * Returns	:	string          -      Question/ message (depends if exception occurs)
        */
        private void QuestionQuiz_FormLoad(int questionNumber)
        {
            try
            {
                // Calls method to retreive Questions
                string question = retreiveQuestion(questionNumber);

                // Format for the question
                label2.Text = "Question " + questionNumber + " : " + question;

                // Turn warning visibility off
                Warning.Visible = false;

                // Call method to rtetreive Options
                string allOption = retreiveOptions(questionNumber);

                // Split options appropriately
                string[] options = allOption.Split(',');

                // Ensure none of the options are clicked beforehand
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;

                // Assigning each radioButton to a option
                radioButton1.Text = options[0];
                radioButton2.Text = options[1];
                radioButton3.Text = options[2];
                radioButton4.Text = options[3];

                // Start the timer.
                timeLeft = 20;
                timeLabel.Text = "20 seconds";
                timer1.Start();
            }
            catch (Exception ex)
            {
                // Warning if exception occurs
                MessageBox.Show(ex.Message);
            }
            
        }

        /*  -- Method Header Comment
        * Name	    :	CheckAnswer 
        * Purpose   :	The purpose of this method is to check the right answer per question
        * Inputs	:	questionNumber --INT
        * Returns	:	string          -      Score/ message (depends if exception occurs)
        */
        private bool CheckAnswer(int questionNumber)
        {

            //Initializations
            bool buttonChecked;

            // Call method to check the answer
            string answer = retreiveAnswer(questionNumber);

            // Calculate score depending on how fast user answered
            string timeScore = timeLabel.Text.Substring(0, 2);

            //Create iserRecord
            userRecord = userRecord + "," + Convert.ToInt32(timeScore);
            answer = answer.Replace("\r\n", string.Empty);

            // Calcultion if user attempted the question
            if (radioButton1.Checked)   /*Checks if radio button 1 is pressed.*/
            {
                // Retreive option selected
                choosenOption = choosenOption + "," + radioButton1.Text;
                buttonChecked = true;

                // If anwered correctly
                if (radioButton1.Text == answer)
                {
                    // Calculate score
                    score += Convert.ToInt32(timeScore);
                }
                else
                {
                    // Assign 0
                    score += 0;
                }
            }
            else if (radioButton2.Checked)      /*Checks if radio button 2 is pressed.*/
            {
                // Retreive option selected
                choosenOption = choosenOption + "," + radioButton2.Text;
                buttonChecked = true;

                // If anwered correctly
                if (radioButton2.Text == answer)
                {
                    // Calculate score
                    score += Convert.ToInt32(timeScore);
                }
                else
                {
                    // Assign 0
                    score += 0;
                }
            }
            else if (radioButton3.Checked)          /*Checks if radio button 3 is pressed.*/
            {
                // Retreive option selected
                choosenOption = choosenOption + "," + radioButton3.Text;
                buttonChecked = true;

                // If anwered correctly
                if (radioButton3.Text == answer)
                {
                    // Calculate score
                    score += Convert.ToInt32(timeScore);
                }
                else
                {
                    // Assign 0
                    score += 0;
                }
            }
            else if (radioButton4.Checked)              /*Checks if radio button 4 is pressed.*/
            {
                // Retreive option selected
                choosenOption = choosenOption + "," + radioButton4.Text;
                buttonChecked = true;

                // If anwered correctly
                if (radioButton4.Text == answer)
                {
                    // Calculate score
                    score += Convert.ToInt32(timeScore);
                }
                else
                {
                    // Assign 0
                    score += 0;
                }
            }
            else                              /*If not a single button is pressed, it will show error.*/
            {
                // Generate warning if user did not attempt
                string warning = "-You must select any one option from above.";

                // Enable warning appearance
                Warning.Visible = true;

                // Ensure warning appears in red
                Warning.ForeColor = Color.Red;
                Warning.Text = warning;

                // Ensure no option is checked
                buttonChecked = false;
            }
            return buttonChecked;
        }

        /*  -- Method Header Comment
         * Name	    :	retreiveQuestion 
         * Purpose   :	The purpose of this method is to retreive questions appropriately
         * Inputs	:	QuestionID --INT
         * Returns	:	string          -      question/ message (depends if exception occurs)
         */
        private string retreiveQuestion(int QuestionID)
        {
            // Initialization
            string question = "";
            try
            {
                // Connect to server
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";
                using (var connection = new MySqlConnection(connectionStr))
                {
                    // Open connection
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        // SQL command to generate requird data
                        command.CommandText = "SELECT QuestionName FROM QuizA4 WHERE QuestionID=" + QuestionID;
                        using (var reader = command.ExecuteReader())
                        {
                            // Advances to read the next record
                            while (reader.Read())
                            {
                                // Verify fieldCount
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    // Retreives all the questions
                                    question += reader[i].ToString() + Environment.NewLine;
                                }
                            }
                        }
                    }
                    // Disconnect to the database
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Warning if exception occurs
                MessageBox.Show(ex.Message);
                // Close it
                this.Close();
            }
            
            // Returns the question
            return question;
        }
        /*  -- Method Header Comment
         * Name	    :	retreiveOptions 
         * Purpose   :	The purpose of this method is to retreive options appropriately
         * Inputs	:	QuestionID --INT
         * Returns	:	string          -      option/ message (depends if exception occurs)
         */
        private string retreiveOptions(int QuestionID)
        {
            // Initialization
            string option = "";
            try
            {
                // Connect to server
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";
                using (var connection = new MySqlConnection(connectionStr))
                {
                    // Open connection
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        // SQL command to generate requird data
                        command.CommandText = "SELECT Options FROM QuizA4 WHERE QuestionID=" + QuestionID;
                        using (var reader = command.ExecuteReader())
                        {
                            // Advances to read the next record
                            while (reader.Read())
                            {
                                // Verify fieldCount
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    // Retreives all the options
                                    option += reader[i].ToString() + Environment.NewLine;
                                }
                            }
                        }
                    }
                    // Disconnect to the database
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                // Warning if exception occurs
                MessageBox.Show(ex.Message);
                // Close it
                this.Close();
            }

            // Returns the option
            return option;
        }

        /*  -- Method Header Comment
         * Name	    :	retreiveAnswer 
         * Purpose   :	The purpose of this method is to retreive answers appropriately
         * Inputs	:	QuestionID --INT
         * Returns	:	string          -      answer/ message (depends if exception occurs)
         */
        private string retreiveAnswer(int QuestionID)
        {
            // Initialization
            string answer = "";
            try
            {
                // Connect to server
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";
                using (var connection = new MySqlConnection(connectionStr))
                {
                    // Open connection
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        // SQL command to generate requird data
                        command.CommandText = "SELECT Answers FROM QuizA4 WHERE QuestionID=" + QuestionID;
                        using (var reader = command.ExecuteReader())
                        {
                            // Advances to read the next record
                            while (reader.Read())
                            {
                                // Verify fieldCount
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    // Retreives all the answers
                                    answer += reader[i].ToString() + Environment.NewLine;
                                }
                            }
                        }
                    }
                    // Disconnect to the database
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                // Warning if exception occurs
                MessageBox.Show(ex.Message);
                // Close it
                this.Close();
            }

            // Returns the answer
            return answer;
        }
        /*  -- Method Header Comment
         * Name	    :	insertintoLeaderboard 
         * Purpose   :	The purpose of this method is to insert scire into Leaderboard appropriately
         * Inputs	:	score --INT
         *              userName --string
         * Returns	:	string          -      score/ message (depends if exception occurs)
         */
        private void insertintoLeaderboard(string userName, int score)
        {
            try
            {

                //Connection String that will connect to SQL database.
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";

                //Connects to SQL database
                using (var conn = new MySqlConnection(connectionStr))
                {

                    //Opens the database.
                    conn.Open();

                    //Creates command associated with SQL connection.
                    using (var cmd = conn.CreateCommand())
                    {

                        //SQL insert command text.
                        cmd.CommandText = "INSERT into Leaderboard (UserName, Score) values ('" + userName + "', '" + score + "' )";

                        //Executes the command 'cmd'
                        cmd.ExecuteNonQuery();

                    }

                    //Closes the database.
                    conn.Close();

                }

            }
            catch (Exception ex)
            {

                //Catches all exception and will print Error in console.
                MessageBox.Show(ex.Message);
                this.Close();

            }
        }

        /*  -- Method Header Comment
         * Name	    :	insertUserRecord 
         * Purpose   :	The purpose of this method is to insert UserRecord appropriately
         * Inputs	:	userRecord --string
         *              choosenOption --string
         *              userName --string
         * Returns	:	string          -      message (depends if exception occurs)
         */
        private void insertUserRecord(string userName, string userRecord, string choosenOption)
        {
            try
            {

                //Connection String that will connect to SQL database.
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";

                //Connects to SQL database
                using (var conn = new MySqlConnection(connectionStr))
                {

                    //Opens the database.
                    conn.Open();

                    //Creates command associated with SQL connection.
                    using (var cmd = conn.CreateCommand())
                    {

                        //SQL insert command text.
                        cmd.CommandText = "INSERT into UserRecord (UserName,EnteredInput,TimeTaken) values ('"+userName+"','"+choosenOption+"','"+userRecord+"')"; 

                        //Executes the command 'cmd'
                        cmd.ExecuteNonQuery();

                    }

                    //Closes the database.
                    conn.Close();

                }

            }
            catch (Exception ex)
            {

                //Catches all exception and will print Error in console.
                MessageBox.Show(ex.Message);
                this.Close();

            }
        }


        /*  -- Method Header Comment
         * Name	    :	timer1_Tick 
         * Purpose   :	The purpose of this method is to insert a timer  appropriately
         * Inputs	:	sender - Object
         *              e      - EventArgs
         * Returns	:	string          -      score/ message (depends if exception occurs)
         */
        private void timer1_Tick(object sender, EventArgs e)
        {
            
            if (timeLeft > 0)
            {
                // Display the new time left
                // by updating the Time Left label.
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show
                // a MessageBox, and fill in the answers.
                timer1.Stop();
                timeLabel.Text = "0 seconds";
            }
        }

        /*  -- Method Header Comment
         * Name	    :	NextQuestion_Click 
         * Purpose   :	The purpose of this method is see what happens if that button is clicked
         * Inputs	:	sender - Object
         *              e      - EventArgs
         * Returns	:	string          -      score/ message (depends if exception occurs)
         */
        private void NextQuestion_Click(object sender, EventArgs e)
        {
            //Initializations
            const string message = "Are you sure you want to go to next question? You cannot come back to this question!";
            const string caption = "Next Question";

            // Warning messageboz display
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user selects NO
            if (result == DialogResult.No)
            {
                //Keeps the form open
            }
            // If user selects yES
            else if (result == DialogResult.Yes)
            {
                bool buttonPressed = CheckAnswer(currentQuestion);
                //Verify is option is selected
                if (buttonPressed == true)
                {
                    if (currentQuestion == 9)
                    {
                        currentQuestion += 1;

                        // Ensure timer stops
                        timer1.Stop();

                        //LOad current question
                        QuestionQuiz_FormLoad(currentQuestion);
                        button1.Visible = false;
                    }
                    else
                    {
                        currentQuestion += 1;

                        // Ensure timer stops
                        timer1.Stop();

                        //LOad current question
                        QuestionQuiz_FormLoad(currentQuestion);
                    }
                }
                else
                {
                    //Keeps the form open
                }

            }
            else
            {
                //Keeps the form open
            }
        }

        /*  -- Method Header Comment
         * Name	    :	SubmitQuiz_Click 
         * Purpose   :	The purpose of this method is see what happens if that button is clicked
         * Inputs	:	sender - Object
         *              e      - EventArgs
         * Returns	:	string          -      score/ message (depends if exception occurs)
         */
        private void SubmitQuiz_Click(object sender, EventArgs e)
        {
            //Initializes message box string and its header.
            const string message = "Are you sure you want to submit the quiz? Unanswered questions will not be saved!";
            const string caption = "Submit Quiz";

            //Messagebox display
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user selects NO
            if (result == DialogResult.No)
            {
                //Keeps the form open
            }

            // If user selects YES
            else if (result == DialogResult.Yes)
            {
                // Verifies answer
                CheckAnswer(currentQuestion);

                // Inserts updated score to leaderboard
                insertintoLeaderboard(testTakerName, score);

                // RE-established userRecord
                insertUserRecord(testTakerName, userRecord, choosenOption);

                // Ensures quiz is finished
                QuizFinished quizPage = new QuizFinished(score, testTakerName);

                // Jump to next page
                quizPage.Show();
                this.Close();
            }
            else
            {
                //Keeps the form open
            }
        }

    }
}
