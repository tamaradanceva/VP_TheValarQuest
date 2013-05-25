namespace The_Valar_Quest
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            this.characterpic = new System.Windows.Forms.PictureBox();
            this.life3 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.life1 = new System.Windows.Forms.PictureBox();
            this.life2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.asset4 = new System.Windows.Forms.PictureBox();
            this.asset3 = new System.Windows.Forms.PictureBox();
            this.asset2 = new System.Windows.Forms.PictureBox();
            this.asset1 = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.time_left = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button1 = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.assetInUse = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.characterpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.life1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.asset4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset1)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetInUse)).BeginInit();
            this.SuspendLayout();
            // 
            // characterpic
            // 
            this.characterpic.Location = new System.Drawing.Point(12, 12);
            this.characterpic.Name = "characterpic";
            this.characterpic.Size = new System.Drawing.Size(170, 141);
            this.characterpic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.characterpic.TabIndex = 0;
            this.characterpic.TabStop = false;
            // 
            // life3
            // 
            this.life3.Location = new System.Drawing.Point(181, 28);
            this.life3.Name = "life3";
            this.life3.Size = new System.Drawing.Size(72, 51);
            this.life3.TabIndex = 3;
            this.life3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.life1);
            this.groupBox1.Controls.Add(this.life2);
            this.groupBox1.Controls.Add(this.life3);
            this.groupBox1.Font = new System.Drawing.Font("Script MT Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(197, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lifes";
            // 
            // life1
            // 
            this.life1.Location = new System.Drawing.Point(25, 29);
            this.life1.Name = "life1";
            this.life1.Size = new System.Drawing.Size(72, 51);
            this.life1.TabIndex = 5;
            this.life1.TabStop = false;
            // 
            // life2
            // 
            this.life2.Location = new System.Drawing.Point(103, 28);
            this.life2.Name = "life2";
            this.life2.Size = new System.Drawing.Size(72, 51);
            this.life2.TabIndex = 4;
            this.life2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.asset4);
            this.groupBox2.Controls.Add(this.asset3);
            this.groupBox2.Controls.Add(this.asset2);
            this.groupBox2.Controls.Add(this.asset1);
            this.groupBox2.Font = new System.Drawing.Font("Script MT Bold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(471, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(343, 94);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Assets";
            // 
            // asset4
            // 
            this.asset4.Location = new System.Drawing.Point(240, 28);
            this.asset4.Name = "asset4";
            this.asset4.Size = new System.Drawing.Size(72, 57);
            this.asset4.TabIndex = 9;
            this.asset4.TabStop = false;
            this.asset4.Click += new System.EventHandler(this.asset4_Click);
            // 
            // asset3
            // 
            this.asset3.Location = new System.Drawing.Point(162, 29);
            this.asset3.Name = "asset3";
            this.asset3.Size = new System.Drawing.Size(72, 56);
            this.asset3.TabIndex = 8;
            this.asset3.TabStop = false;
            this.asset3.Click += new System.EventHandler(this.asset3_Click);
            // 
            // asset2
            // 
            this.asset2.Location = new System.Drawing.Point(84, 28);
            this.asset2.Name = "asset2";
            this.asset2.Size = new System.Drawing.Size(72, 57);
            this.asset2.TabIndex = 7;
            this.asset2.TabStop = false;
            this.asset2.Click += new System.EventHandler(this.asset2_Click);
            // 
            // asset1
            // 
            this.asset1.Location = new System.Drawing.Point(6, 28);
            this.asset1.Name = "asset1";
            this.asset1.Size = new System.Drawing.Size(72, 57);
            this.asset1.TabIndex = 6;
            this.asset1.TabStop = false;
            this.asset1.Click += new System.EventHandler(this.asset1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.time_left);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(211, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(574, 61);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Time";
            // 
            // time_left
            // 
            this.time_left.AutoSize = true;
            this.time_left.Location = new System.Drawing.Point(523, 23);
            this.time_left.Name = "time_left";
            this.time_left.Size = new System.Drawing.Size(45, 19);
            this.time_left.TabIndex = 2;
            this.time_left.Text = "00:00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(450, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time left";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(18, 19);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(421, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(695, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 33);
            this.button1.TabIndex = 11;
            this.button1.Text = "Pause";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(695, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 89);
            this.button2.TabIndex = 13;
            this.button2.Text = "Quit Game";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Script MT Bold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1049, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Asset in use";
            // 
            // assetInUse
            // 
            this.assetInUse.Location = new System.Drawing.Point(706, 417);
            this.assetInUse.Name = "assetInUse";
            this.assetInUse.Size = new System.Drawing.Size(73, 75);
            this.assetInUse.TabIndex = 15;
            this.assetInUse.TabStop = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Font = new System.Drawing.Font("Script MT Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(695, 558);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 81);
            this.button3.TabIndex = 16;
            this.button3.Text = "Next Level";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Script MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(701, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 19);
            this.label3.TabIndex = 17;
            this.label3.Text = "Asset in use";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 712);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.assetInUse);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.characterpic);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Game";
            this.Text = "Game";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Game_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.characterpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.life1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.life2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.asset4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.asset1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.assetInUse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox characterpic;
        private System.Windows.Forms.PictureBox life3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label time_left;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox life1;
        private System.Windows.Forms.PictureBox life2;
        private System.Windows.Forms.PictureBox asset4;
        private System.Windows.Forms.PictureBox asset3;
        private System.Windows.Forms.PictureBox asset2;
        private System.Windows.Forms.PictureBox asset1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox assetInUse;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;

    }
}