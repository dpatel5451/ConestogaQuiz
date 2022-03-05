
namespace A04_Quiz
{
    partial class EntryPage
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
            this.StartButton = new System.Windows.Forms.Button();
            this.TriviaLabel = new System.Windows.Forms.Label();
            this.EnterNameLabel = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.TestGKLabel = new System.Windows.Forms.Label();
            this.usernameWarningLabel = new System.Windows.Forms.Label();
            this.instructions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(295, 416);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(137, 31);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start Quiz";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartQuiz_Click);
            // 
            // TriviaLabel
            // 
            this.TriviaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TriviaLabel.Location = new System.Drawing.Point(235, 38);
            this.TriviaLabel.Name = "TriviaLabel";
            this.TriviaLabel.Size = new System.Drawing.Size(272, 54);
            this.TriviaLabel.TabIndex = 0;
            this.TriviaLabel.Text = "Indian Trivia Quiz";
            this.TriviaLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // EnterNameLabel
            // 
            this.EnterNameLabel.AutoSize = true;
            this.EnterNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterNameLabel.Location = new System.Drawing.Point(209, 289);
            this.EnterNameLabel.Name = "EnterNameLabel";
            this.EnterNameLabel.Size = new System.Drawing.Size(118, 24);
            this.EnterNameLabel.TabIndex = 1;
            this.EnterNameLabel.Text = "Enter name :";
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameTextBox.Location = new System.Drawing.Point(345, 285);
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(221, 28);
            this.UserNameTextBox.TabIndex = 2;
            // 
            // TestGKLabel
            // 
            this.TestGKLabel.AutoSize = true;
            this.TestGKLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TestGKLabel.Location = new System.Drawing.Point(287, 81);
            this.TestGKLabel.Name = "TestGKLabel";
            this.TestGKLabel.Size = new System.Drawing.Size(159, 29);
            this.TestGKLabel.TabIndex = 3;
            this.TestGKLabel.Text = "Test your GK!";
            // 
            // usernameWarningLabel
            // 
            this.usernameWarningLabel.AutoSize = true;
            this.usernameWarningLabel.ForeColor = System.Drawing.Color.Red;
            this.usernameWarningLabel.Location = new System.Drawing.Point(342, 327);
            this.usernameWarningLabel.Name = "usernameWarningLabel";
            this.usernameWarningLabel.Size = new System.Drawing.Size(96, 17);
            this.usernameWarningLabel.TabIndex = 4;
            this.usernameWarningLabel.Text = "WarningLabel";
            // 
            // instructions
            // 
            this.instructions.AutoSize = true;
            this.instructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructions.Location = new System.Drawing.Point(12, 146);
            this.instructions.Name = "instructions";
            this.instructions.Size = new System.Drawing.Size(96, 20);
            this.instructions.TabIndex = 5;
            this.instructions.Text = "Instructions";
            // 
            // EntryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(734, 536);
            this.Controls.Add(this.instructions);
            this.Controls.Add(this.usernameWarningLabel);
            this.Controls.Add(this.TestGKLabel);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.EnterNameLabel);
            this.Controls.Add(this.TriviaLabel);
            this.Controls.Add(this.StartButton);
            this.Name = "EntryPage";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TriviaLabel;
        private System.Windows.Forms.Label EnterNameLabel;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.Label TestGKLabel;
        private System.Windows.Forms.Label usernameWarningLabel;
        private System.Windows.Forms.Label instructions;
    }
}

