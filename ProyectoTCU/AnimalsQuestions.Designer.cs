namespace ProyectoTCU
{
    partial class AnimalsQuestions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnimalsQuestions));
            this.labelQuestion = new System.Windows.Forms.Label();
            this.button1Answer = new System.Windows.Forms.Button();
            this.button2Answer = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.pictureBoxRespuesta = new System.Windows.Forms.PictureBox();
            this.backB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRespuesta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelQuestion
            // 
            this.labelQuestion.AutoSize = true;
            this.labelQuestion.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestion.Location = new System.Drawing.Point(143, 272);
            this.labelQuestion.Name = "labelQuestion";
            this.labelQuestion.Size = new System.Drawing.Size(241, 24);
            this.labelQuestion.TabIndex = 0;
            this.labelQuestion.Text = "Choose the correct answer.";
            this.labelQuestion.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1Answer
            // 
            this.button1Answer.BackColor = System.Drawing.Color.Gold;
            this.button1Answer.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button1Answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Answer.Location = new System.Drawing.Point(132, 349);
            this.button1Answer.Name = "button1Answer";
            this.button1Answer.Size = new System.Drawing.Size(162, 36);
            this.button1Answer.TabIndex = 2;
            this.button1Answer.Text = "button1Answer";
            this.button1Answer.UseVisualStyleBackColor = false;
            this.button1Answer.Click += new System.EventHandler(this.button1Answer_Click);
            // 
            // button2Answer
            // 
            this.button2Answer.BackColor = System.Drawing.Color.Gold;
            this.button2Answer.FlatAppearance.BorderColor = System.Drawing.Color.Yellow;
            this.button2Answer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2Answer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Answer.Location = new System.Drawing.Point(316, 349);
            this.button2Answer.Name = "button2Answer";
            this.button2Answer.Size = new System.Drawing.Size(162, 36);
            this.button2Answer.TabIndex = 3;
            this.button2Answer.Text = "button2";
            this.button2Answer.UseVisualStyleBackColor = false;
            this.button2Answer.Click += new System.EventHandler(this.button1Answer_Click);
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.playButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.ForeColor = System.Drawing.Color.White;
            this.playButton.Location = new System.Drawing.Point(535, 38);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(86, 42);
            this.playButton.TabIndex = 20;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // pictureBoxRespuesta
            // 
            this.pictureBoxRespuesta.Location = new System.Drawing.Point(531, 251);
            this.pictureBoxRespuesta.Name = "pictureBoxRespuesta";
            this.pictureBoxRespuesta.Size = new System.Drawing.Size(91, 65);
            this.pictureBoxRespuesta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRespuesta.TabIndex = 19;
            this.pictureBoxRespuesta.TabStop = false;
            // 
            // backB
            // 
            this.backB.BackColor = System.Drawing.Color.LightCyan;
            this.backB.BackgroundImage = global::ProyectoTCU.Properties.Resources.back_arrow__1_;
            this.backB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.backB.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.backB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backB.Location = new System.Drawing.Point(12, 12);
            this.backB.Name = "backB";
            this.backB.Size = new System.Drawing.Size(70, 60);
            this.backB.TabIndex = 5;
            this.backB.UseVisualStyleBackColor = false;
            this.backB.Click += new System.EventHandler(this.backB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(132, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(346, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // AnimalsQuestions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(687, 428);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pictureBoxRespuesta);
            this.Controls.Add(this.backB);
            this.Controls.Add(this.button2Answer);
            this.Controls.Add(this.button1Answer);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelQuestion);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AnimalsQuestions";
            this.Text = "TCU-501 UCR";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRespuesta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuestion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1Answer;
        private System.Windows.Forms.Button button2Answer;
        private System.Windows.Forms.Button backB;
        private System.Windows.Forms.PictureBox pictureBoxRespuesta;
        private System.Windows.Forms.Button playButton;
    }
}