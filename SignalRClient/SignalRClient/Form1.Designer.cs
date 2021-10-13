
namespace SignalRClient
{
    partial class Form1
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
            this.UP = new System.Windows.Forms.Button();
            this.DOWN = new System.Windows.Forms.Button();
            this.LEFT = new System.Windows.Forms.Button();
            this.RIGHT = new System.Windows.Forms.Button();
            this.messagesList = new System.Windows.Forms.ListBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // UP
            // 
            this.UP.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.UP.Location = new System.Drawing.Point(1034, 502);
            this.UP.Name = "UP";
            this.UP.Size = new System.Drawing.Size(128, 44);
            this.UP.TabIndex = 9;
            this.UP.Text = "UP";
            this.UP.UseVisualStyleBackColor = true;
            this.UP.Click += new System.EventHandler(this.UP_Click);
            // 
            // DOWN
            // 
            this.DOWN.Location = new System.Drawing.Point(1179, 502);
            this.DOWN.Name = "DOWN";
            this.DOWN.Size = new System.Drawing.Size(128, 44);
            this.DOWN.TabIndex = 10;
            this.DOWN.Text = "DOWN";
            this.DOWN.UseVisualStyleBackColor = true;
            this.DOWN.Click += new System.EventHandler(this.DOWN_Click);
            // 
            // LEFT
            // 
            this.LEFT.Location = new System.Drawing.Point(1034, 552);
            this.LEFT.Name = "LEFT";
            this.LEFT.Size = new System.Drawing.Size(128, 44);
            this.LEFT.TabIndex = 11;
            this.LEFT.Text = "LEFT";
            this.LEFT.UseVisualStyleBackColor = true;
            this.LEFT.Click += new System.EventHandler(this.LEFT_Click);
            // 
            // RIGHT
            // 
            this.RIGHT.Location = new System.Drawing.Point(1179, 552);
            this.RIGHT.Name = "RIGHT";
            this.RIGHT.Size = new System.Drawing.Size(128, 44);
            this.RIGHT.TabIndex = 12;
            this.RIGHT.Text = "RIGHT";
            this.RIGHT.UseVisualStyleBackColor = true;
            this.RIGHT.Click += new System.EventHandler(this.RIGHT_Click);
            // 
            // messagesList
            // 
            this.messagesList.FormattingEnabled = true;
            this.messagesList.Location = new System.Drawing.Point(1034, 12);
            this.messagesList.Name = "messagesList";
            this.messagesList.Size = new System.Drawing.Size(270, 472);
            this.messagesList.TabIndex = 15;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox2.Image = global::SignalRClient.Properties.Resources.enemy;
            this.pictureBox2.Location = new System.Drawing.Point(480, 320);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.pictureBox1.Image = global::SignalRClient.Properties.Resources.player;
            this.pictureBox1.Location = new System.Drawing.Point(480, 320);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1000, 640);
            this.picCanvas.TabIndex = 14;
            this.picCanvas.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 669);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.messagesList);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.RIGHT);
            this.Controls.Add(this.LEFT);
            this.Controls.Add(this.DOWN);
            this.Controls.Add(this.UP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button UP;
        private System.Windows.Forms.Button DOWN;
        private System.Windows.Forms.Button LEFT;
        private System.Windows.Forms.Button RIGHT;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.ListBox messagesList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

