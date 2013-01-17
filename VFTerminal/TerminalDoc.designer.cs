
namespace VFTerminal
{
    partial class TerminalDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalDoc));
            this.vfTerminalControl1 = new VFTerminal.TerminalControl.VFTerminalControl();
            this.SuspendLayout();
            // 
            // vfTerminalControl1
            // 
            this.vfTerminalControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vfTerminalControl1.Location = new System.Drawing.Point(0, 4);
            this.vfTerminalControl1.Name = "vfTerminalControl1";
            this.vfTerminalControl1.Size = new System.Drawing.Size(883, 515);
            this.vfTerminalControl1.TabIndex = 0;
            // 
            // TerminalDoc
            // 
            this.ClientSize = new System.Drawing.Size(883, 519);
            this.Controls.Add(this.vfTerminalControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TerminalDoc";
            this.Text = "Terminal Session";
            this.ResumeLayout(false);

		}
		#endregion

        private TerminalControl.VFTerminalControl vfTerminalControl1;

    }
}
