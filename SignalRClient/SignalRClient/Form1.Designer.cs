
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
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.UNDO = new System.Windows.Forms.Button();
            this.ENDTURN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // UP
            // 
            this.UP.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.UP.Enabled = false;
            this.UP.Location = new System.Drawing.Point(1103, 502);
            this.UP.Name = "UP";
            this.UP.Size = new System.Drawing.Size(128, 44);
            this.UP.TabIndex = 9;
            this.UP.Text = "UP";
            this.UP.UseVisualStyleBackColor = true;
            this.UP.Click += new System.EventHandler(this.UP_Click);
            // 
            // DOWN
            // 
            this.DOWN.Enabled = false;
            this.DOWN.Location = new System.Drawing.Point(1103, 602);
            this.DOWN.Name = "DOWN";
            this.DOWN.Size = new System.Drawing.Size(128, 44);
            this.DOWN.TabIndex = 10;
            this.DOWN.Text = "DOWN";
            this.DOWN.UseVisualStyleBackColor = true;
            this.DOWN.Click += new System.EventHandler(this.DOWN_Click);
            // 
            // LEFT
            // 
            this.LEFT.Enabled = false;
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
            this.RIGHT.Enabled = false;
            this.RIGHT.Location = new System.Drawing.Point(1168, 552);
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
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.picCanvas.Location = new System.Drawing.Point(12, 12);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(1000, 640);
            this.picCanvas.TabIndex = 14;
            this.picCanvas.TabStop = false;
            // 
            // UNDO
            // 
            this.UNDO.Enabled = false;
            this.UNDO.Location = new System.Drawing.Point(1237, 634);
            this.UNDO.Name = "UNDO";
            this.UNDO.Size = new System.Drawing.Size(75, 23);
            this.UNDO.TabIndex = 16;
            this.UNDO.Text = "UNDO";
            this.UNDO.UseVisualStyleBackColor = true;
            this.UNDO.Click += new System.EventHandler(this.UNDO_Click);
            // 
            // ENDTURN
            // 
            this.ENDTURN.Enabled = false;
            this.ENDTURN.Location = new System.Drawing.Point(1022, 634);
            this.ENDTURN.Name = "ENDTURN";
            this.ENDTURN.Size = new System.Drawing.Size(75, 23);
            this.ENDTURN.TabIndex = 17;
            this.ENDTURN.Text = "END TURN";
            this.ENDTURN.UseVisualStyleBackColor = true;
            this.ENDTURN.Click += new System.EventHandler(this.ENDTURN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1316, 669);
            this.Controls.Add(this.ENDTURN);
            this.Controls.Add(this.UNDO);
            this.Controls.Add(this.messagesList);
            this.Controls.Add(this.picCanvas);
            this.Controls.Add(this.RIGHT);
            this.Controls.Add(this.LEFT);
            this.Controls.Add(this.DOWN);
            this.Controls.Add(this.UP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.Button UNDO;
        private System.Windows.Forms.Button ENDTURN;
    }
}

