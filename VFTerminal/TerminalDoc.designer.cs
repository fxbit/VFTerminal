
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TerminalDoc));
            this.vfTerminalControl1 = new VFTerminal.TerminalControl.VFTerminalControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(343, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Connecting...";
            this.label1.Visible = false;
            // 
            // TerminalDoc
            // 
            this.ClientSize = new System.Drawing.Size(883, 519);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vfTerminalControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TerminalDoc";
            this.Text = "Terminal Session";
            this.Load += new System.EventHandler(this.TerminalDoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private TerminalControl.VFTerminalControl vfTerminalControl1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;

    }
}
