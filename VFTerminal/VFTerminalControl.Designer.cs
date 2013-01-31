namespace VFTerminal.TerminalControl
{
    partial class VFTerminalControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.terminalControl1 = new WalburySoftware.TerminalControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // terminalControl1
            // 
            this.terminalControl1.AuthType = Poderosa.ConnectionParam.AuthType.Password;
            this.terminalControl1.BackColor = System.Drawing.SystemColors.Control;
            this.terminalControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalControl1.Host = "";
            this.terminalControl1.IdentifyFile = "";
            this.terminalControl1.Location = new System.Drawing.Point(0, 0);
            this.terminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;
            this.terminalControl1.Name = "terminalControl1";
            this.terminalControl1.Password = "";
            this.terminalControl1.Size = new System.Drawing.Size(537, 464);
            this.terminalControl1.TabIndex = 0;
            this.terminalControl1.Text = "terminalControl1";
            this.terminalControl1.UserName = "";
            this.terminalControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.terminalControl1_KeyDown);
            this.terminalControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.terminalControl1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Connecting...";
            this.label1.Visible = false;
            // 
            // VFTerminalControl
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.terminalControl1);
            this.Name = "VFTerminalControl";
            this.Size = new System.Drawing.Size(537, 464);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WalburySoftware.TerminalControl terminalControl1;
        private System.Windows.Forms.Label label1;

    }
}
