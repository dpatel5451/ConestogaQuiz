/*
* Filename		:	QuizFinished.cs
* Project		:	RDB - Assignment 04 
* Programmer	:	Deep Patel & Dhruvanshi Ghiya
* First Version	:	10/12/2021
* Description	:	This form acts as the final page of the application
*                   Contains methods to display leaderboard and calculate final score
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
using MySql.Data.MySqlClient;

namespace A04_Quiz
{
    /* 
     * Name      : QuizFinished
     * Purpose   : The purpose of this class is to set up an actively running quiz. 
     *             This form is responsible the page where user can see their final score and where they stand in the leaderboard
     *             It also acts as way to exit the quiz.
     */
    public partial class QuizFinished : Form
    {
        // Initializations
        private string databaseUserID;
        private string databasePassword;
        private string databaseServer;
        private string leaderboardNames;
        private string leaderboardScore;
        private string sqlData;
        private string[] sqlDataSplit;

        /*  -- Method Header Comment
	    * Name	    :	QuizFinished -- CONSTRUCTOR
	    * Purpose   :	It will initializes all the members of QuizFinished class.
	    *               It will also act as exit page to to the quiz and displays leaderboard and final score for the  user
	    * Inputs	:	NONE
	    * Outputs	:	NONE
	    * Returns	:	Nothing
        */
        public QuizFinished(int score, string userName)
        {
            //Get the SQL data from text file
            sqlData = System.IO.File.ReadAllText("0SqlData.txt");

            // Split info using ","
            sqlDataSplit = sqlData.Split(',');

            //Store this information
            databaseServer = sqlDataSplit[0];
            databaseUserID = sqlDataSplit[1];
            databasePassword = sqlDataSplit[2];
            InitializeComponent();
            
            //Display final score
            TotalScore.Text = userName + ", You have successfully completed the quiz with " + score.ToString() + " score.";
            leaderboardNames = getLeaderboardNames();
            leaderboardScore = getLeaderboardScores();
                
            // Show them from highest rank in a decreasing format
            Number.Text = "1.\n2.\n3.\n4.\n5.\n";
            leaderboard.Text = leaderboardNames;
            leaderboardScores.Text = leaderboardScore;
        }

        /*  -- Method Header Comment
            Name	:	getLeaderboardNames 
            Purpose :	The purpose of this method is to return userNames from the database and access it to display on leaderboard
            Inputs	:	NONE
            Returns	:	string          -       userName
        */
        private string getLeaderboardNames()
        {
            //Initializations
            int top5 = 5;
            string names = "";
            try
            {
                // Connect to server
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";
                using (var connection = new MySqlConnection(connectionStr))
                {
                    // Start connection
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        // Comand to extract required information
                        command.CommandText = "SELECT UserName FROM Leaderboard ORDER BY Score DESC LIMIT " + top5;
                        using (var reader = command.ExecuteReader())
                        {
                            // Advance to next record
                            while (reader.Read())
                            {
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    // Get userName
                                    names += reader[i].ToString() + Environment.NewLine;
                                }
                            }
                        }
                    }
                    // Close connection
                    connection.Close();
                }
            }
            catch (Exception ex)
            { 
                // Warning message if exception occurs
                MessageBox.Show(ex.Message);
                this.Close();
            }
            

            return names;
        }

        /*  -- Method Header Comment
            Name	:	getLeaderboardScores 
            Purpose :	The purpose of this method is to return total score from the database and access it to display on leaderboard
            Inputs	:	NONE
            Returns	:	int          -       score
        */
        private string getLeaderboardScores()
        {
            int top5 = 5;
            string scores = "";

            try
            {
                // Connect to server
                string connectionStr = "Server=" + databaseServer + ";UID=" + databaseUserID + ";PWD=" + databasePassword + ";Database=ConestogaQuiz";
                using (var connection = new MySqlConnection(connectionStr))
                {
                    // Start connection
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        // Comand to extract required information
                        command.CommandText = "SELECT Score FROM Leaderboard ORDER BY Score DESC LIMIT " + top5;
                        using (var reader = command.ExecuteReader())
                        {
                            // Advance to next record
                            while (reader.Read())
                            {
                                var ii = reader.FieldCount;
                                for (int i = 0; i < ii; i++)
                                {
                                    // Get scores
                                    scores += reader[i].ToString() + Environment.NewLine;
                                }
                            }
                        }
                    }
                    // Close connection
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                // Close connection
                MessageBox.Show(ex.Message);
                this.Close();
            }
            

            return scores;
        }



        /*  -- Method Header Comment
            Name	:	exitForm_Click 
            Purpose :	The purpose of this method is to close the form when user clicks exit button.
            Inputs	:	sender - Object
                        e      - EventArgs
            Returns	:	NOTHING 
        */
        private void exitForm_Click(object sender, EventArgs e)
        {

            //Closes the form.
            this.Close();
        }
    }
}
