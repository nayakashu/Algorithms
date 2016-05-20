namespace TimeLoggerWindows
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
            this.components = new System.ComponentModel.Container();
            this.btnLogTime = new System.Windows.Forms.Button();
            this.tmrLogTime = new System.Windows.Forms.Timer(this.components);
            this.lblLastTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogTime
            // 
            this.btnLogTime.Location = new System.Drawing.Point(242, 99);
            this.btnLogTime.Name = "btnLogTime";
            this.btnLogTime.Size = new System.Drawing.Size(176, 45);
            this.btnLogTime.TabIndex = 0;
            this.btnLogTime.Text = "Start Logging";
            this.btnLogTime.UseVisualStyleBackColor = true;
            this.btnLogTime.Click += new System.EventHandler(this.btnLogTime_Click);
            // 
            // tmrLogTime
            // 
            this.tmrLogTime.Interval = 60000;
            this.tmrLogTime.Tick += new System.EventHandler(this.tmrLogTime_Tick);
            // 
            // lblLastTime
            // 
            this.lblLastTime.AutoSize = true;
            this.lblLastTime.Location = new System.Drawing.Point(28, 130);
            this.lblLastTime.Name = "lblLastTime";
            this.lblLastTime.Size = new System.Drawing.Size(0, 13);
            this.lblLastTime.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 156);
            this.Controls.Add(this.lblLastTime);
            this.Controls.Add(this.btnLogTime);
            this.Name = "Form1";
            this.Text = "Time Logger";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogTime;
        private System.Windows.Forms.Timer tmrLogTime;
        private System.Windows.Forms.Label lblLastTime;
    }
}

