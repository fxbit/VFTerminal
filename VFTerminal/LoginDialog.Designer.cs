namespace VFTerminal
{
    partial class LoginDialog
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.usertextBox3 = new System.Windows.Forms.TextBox();
            this.passtextBox2 = new System.Windows.Forms.TextBox();
            this.servertextBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "SSH Server";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "UserName";
            // 
            // usertextBox3
            // 
            this.usertextBox3.Location = new System.Drawing.Point(15, 67);
            this.usertextBox3.Name = "usertextBox3";
            this.usertextBox3.Size = new System.Drawing.Size(178, 20);
            this.usertextBox3.TabIndex = 9;
            // 
            // passtextBox2
            // 
            this.passtextBox2.Location = new System.Drawing.Point(15, 106);
            this.passtextBox2.Name = "passtextBox2";
            this.passtextBox2.PasswordChar = '*';
            this.passtextBox2.Size = new System.Drawing.Size(178, 20);
            this.passtextBox2.TabIndex = 11;
            this.passtextBox2.UseSystemPasswordChar = true;
            // 
            // servertextBox1
            // 
            this.servertextBox1.Location = new System.Drawing.Point(15, 28);
            this.servertextBox1.Name = "servertextBox1";
            this.servertextBox1.Size = new System.Drawing.Size(178, 20);
            this.servertextBox1.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 145);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 180);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.usertextBox3);
            this.Controls.Add(this.passtextBox2);
            this.Controls.Add(this.servertextBox1);
            this.Controls.Add(this.button1);
            this.Name = "LoginDialog";
            this.Text = "LoginDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox usertextBox3;
        public System.Windows.Forms.TextBox passtextBox2;
        public System.Windows.Forms.TextBox servertextBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;

    }
}