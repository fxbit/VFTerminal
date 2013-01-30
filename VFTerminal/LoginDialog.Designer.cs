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
            this.txt_username = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_server = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chk_remeber_username = new System.Windows.Forms.CheckBox();
            this.chk_remember_pass = new System.Windows.Forms.CheckBox();
            this.chk_remember_server = new System.Windows.Forms.CheckBox();
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
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "UserName";
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(15, 78);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(178, 20);
            this.txt_username.TabIndex = 9;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(15, 126);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(178, 20);
            this.txt_pass.TabIndex = 11;
            this.txt_pass.UseSystemPasswordChar = true;
            // 
            // txt_server
            // 
            this.txt_server.Location = new System.Drawing.Point(15, 28);
            this.txt_server.Name = "txt_server";
            this.txt_server.Size = new System.Drawing.Size(178, 20);
            this.txt_server.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(118, 165);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(14, 165);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // chk_remeber_username
            // 
            this.chk_remeber_username.AutoSize = true;
            this.chk_remeber_username.Checked = true;
            this.chk_remeber_username.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_remeber_username.ForeColor = System.Drawing.Color.Gray;
            this.chk_remeber_username.Location = new System.Drawing.Point(116, 61);
            this.chk_remeber_username.Name = "chk_remeber_username";
            this.chk_remeber_username.Size = new System.Drawing.Size(77, 17);
            this.chk_remeber_username.TabIndex = 16;
            this.chk_remeber_username.Text = "Remember";
            this.chk_remeber_username.UseVisualStyleBackColor = true;
            // 
            // chk_remember_pass
            // 
            this.chk_remember_pass.AutoSize = true;
            this.chk_remember_pass.ForeColor = System.Drawing.Color.Gray;
            this.chk_remember_pass.Location = new System.Drawing.Point(116, 109);
            this.chk_remember_pass.Name = "chk_remember_pass";
            this.chk_remember_pass.Size = new System.Drawing.Size(77, 17);
            this.chk_remember_pass.TabIndex = 17;
            this.chk_remember_pass.Text = "Remember";
            this.chk_remember_pass.UseVisualStyleBackColor = true;
            // 
            // chk_remember_server
            // 
            this.chk_remember_server.AutoSize = true;
            this.chk_remember_server.Checked = true;
            this.chk_remember_server.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_remember_server.ForeColor = System.Drawing.Color.Gray;
            this.chk_remember_server.Location = new System.Drawing.Point(116, 13);
            this.chk_remember_server.Name = "chk_remember_server";
            this.chk_remember_server.Size = new System.Drawing.Size(77, 17);
            this.chk_remember_server.TabIndex = 18;
            this.chk_remember_server.Text = "Remember";
            this.chk_remember_server.UseVisualStyleBackColor = true;
            // 
            // LoginDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 200);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.txt_server);
            this.Controls.Add(this.chk_remember_server);
            this.Controls.Add(this.chk_remember_pass);
            this.Controls.Add(this.chk_remeber_username);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "LoginDialog";
            this.Text = "LoginDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txt_username;
        public System.Windows.Forms.TextBox txt_pass;
        public System.Windows.Forms.TextBox txt_server;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chk_remeber_username;
        private System.Windows.Forms.CheckBox chk_remember_pass;
        private System.Windows.Forms.CheckBox chk_remember_server;

    }
}