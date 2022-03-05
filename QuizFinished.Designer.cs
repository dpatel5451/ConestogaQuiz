namespace A04_Quiz
{
    partial class QuizFinished
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TotalScore = new System.Windows.Forms.Label();
            this.TriviaLabel = new System.Windows.Forms.Label();
            this.TestGKLabel = new System.Windows.Forms.Label();
            this.leaderboard = new System.Windows.Forms.Label();
            this.leaderboardScores = new System.Windows.Forms.Label();
            this.Number = new System.Windows.Forms.Label();
            this.exitForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TotalScore
            // 
            this.TotalScore.AutoSize = true;
            this.TotalScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalScore.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.TotalScore.Location = new System.Drawing.Point(141, 123);
            this.TotalScore.Name = "TotalScore";
            this.TotalScore.Size = new System.Drawing.Size(60, 24);
            this.TotalScore.TabIndex = 0;
            this.TotalScore.Text = "Score";
            // 
            // TriviaLabel
            // 
            this.TriviaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TriviaLabel.Location = new System.Drawing.Point(264, 44);
            this.TriviaLabel.Name = "TriviaLabel";
            this.TriviaLabel.Size = new System.Drawing.Size(272, 54);
            this.TriviaLabel.TabIndex = 1;
            this.TriviaLabel.Text = "Indian Trivia Quiz";
            this.TriviaLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TestGKLabel
            // 
            this.TestGKLabel.AutoSize = true;
            this.TestGKLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestGKLabel.Location = new System.Drawing.Point(304, 177);
            this.TestGKLabel.Name = "TestGKLabel";
            this.TestGKLabel.Size = new System.Drawing.Size(191, 29);
            this.TestGKLabel.TabIndex = 4;
            this.TestGKLabel.Text = "LEADERBOARD";
            // 
            // leaderboard
            // 
            this.leaderboard.AutoSize = true;
            this.leaderboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboard.Location = new System.Drawing.Point(218, 227);
            this.leaderboard.Name = "leaderboard";
            this.leaderboard.Size = new System.Drawing.Size(208, 20);
            this.leaderboard.TabIndex = 5;
            this.leaderboard.Text = "Top 5 Person Leaderboard";
            // 
            // leaderboardScores
            // 
            this.leaderboardScores.AutoSize = true;
            this.leaderboardScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leaderboardScores.Location = new System.Drawing.Point(432, 227);
            this.leaderboardScores.Name = "leaderboardScores";
            this.leaderboardScores.Size = new System.Drawing.Size(208, 20);
            this.leaderboardScores.TabIndex = 6;
            this.leaderboardScores.Text = "Top 5 Person Leaderboard";
            // 
            // Number
            // 
            this.Number.AutoSize = true;
            this.Number.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number.Location = new System.Drawing.Point(153, 227);
            this.Number.Name = "Number";
            this.Number.Size = new System.Drawing.Size(77, 20);
            this.Number.TabIndex = 7;
            this.Number.Text = "Numbers";
            // 
            // exitForm
            // 
            this.exitForm.Location = new System.Drawing.Point(365, 391);
            this.exitForm.Name = "exitForm";
            this.exitForm.Size = new System.Drawing.Size(61, 35);
            this.exitForm.TabIndex = 8;
            this.exitForm.Text = "Exit";
            this.exitForm.UseVisualStyleBackColor = true;
            this.exitForm.Click += new System.EventHandler(this.exitForm_Click);
            // 
            // QuizFinished
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.exitForm);
            this.Controls.Add(this.Number);
            this.Controls.Add(this.leaderboardScores);
            this.Controls.Add(this.leaderboard);
            this.Controls.Add(this.TestGKLabel);
            this.Controls.Add(this.TriviaLabel);
            this.Controls.Add(this.TotalScore);
            this.Name = "QuizFinished";
            this.Text = "QuizFinished";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TotalScore;
        private System.Windows.Forms.Label TriviaLabel;
        private System.Windows.Forms.Label TestGKLabel;
        private System.Windows.Forms.Label leaderboard;
        private System.Windows.Forms.Label leaderboardScores;
        private System.Windows.Forms.Label Number;
        private System.Windows.Forms.Button exitForm;
    }
}