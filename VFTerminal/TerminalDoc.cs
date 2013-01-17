
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;

namespace VFTerminal
{
    public partial class TerminalDoc : BaseDoc
    {
        #region Variables
        //-------------------------------------------------------------------------------------------------------------------------------

        [Serializable]
        public struct SaveLoadDescriptor
        {
            public string test1;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion



        #region Constructor
#if DEBUG
        //-------------------------------------------------------------------------------------------------------------------------------
        //Used only for designer!
        protected TerminalDoc()
        {
            InitializeComponent();
        }
#endif
        //-------------------------------------------------------------------------------------------------------------------------------
        public TerminalDoc(MainFrm GameEditorFrm)
            : base(GameEditorFrm)
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        public TerminalDoc(MainFrm GameEditorFrm, object Descriptor)
            : base(GameEditorFrm)
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion



        #region Functions
        //-------------------------------------------------------------------------------------------------------------------------------

        public override object GetSaveLoadDescriptor()
        {
            return new SaveLoadDescriptor()
            {
            };
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void TerminalDoc_Load(object sender, EventArgs e)
        {
            var frm = new LoginDialog();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.vfTerminalControl1.UserName = frm.usertextBox3.Text;
                this.vfTerminalControl1.Password = frm.passtextBox2.Text;
                this.vfTerminalControl1.Host = frm.servertextBox1.Text;
                this.vfTerminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;

                this.vfTerminalControl1.Connect();

                this.vfTerminalControl1.Focus();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
