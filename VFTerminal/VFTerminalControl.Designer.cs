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
            this.SuspendLayout();
            // 
            // terminalControl1
            // 
            this.terminalControl1.AuthType = Poderosa.ConnectionParam.AuthType.Password;
            this.terminalControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.terminalControl1.Host = "";
            this.terminalControl1.IdentifyFile = "";
            this.terminalControl1.Location = new System.Drawing.Point(0, 0);
            this.terminalControl1.Method = WalburySoftware.ConnectionMethod.Telnet;
            this.terminalControl1.Name = "terminalControl1";
            this.terminalControl1.Password = "";
            this.terminalControl1.Size = new System.Drawing.Size(537, 464);
            this.terminalControl1.TabIndex = 0;
            this.terminalControl1.Text = "terminalControl1";
            this.terminalControl1.UserName = "";
            // 
            // VFTerminalControl
            // 
            this.Controls.Add(this.terminalControl1);
            this.Name = "VFTerminalControl";
            this.Size = new System.Drawing.Size(537, 464);
            this.ResumeLayout(false);

        }

        #endregion

        private WalburySoftware.TerminalControl terminalControl1;

    }
}
