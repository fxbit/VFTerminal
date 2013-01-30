
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
            public bool isValid;
            public LoginDialog.Descriptor LoginDescriptor;
        }

        SaveLoadDescriptor Descriptor = new SaveLoadDescriptor()
        {
            isValid = true,
            LoginDescriptor = new LoginDialog.Descriptor()
            {

                Server = "",
                Username = "",
                Password = "",
            }
        };
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
        public TerminalDoc(MainFrm GameEditorFrm, SaveLoadDescriptor Descriptor)
            : base(GameEditorFrm)
        {
            InitializeComponent();
            //get proper descriptor
            this.Descriptor = Descriptor;
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion



        #region Functions
        //-------------------------------------------------------------------------------------------------------------------------------

        public override object GetSaveLoadDescriptor()
        {
            return Descriptor;
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void TerminalDoc_Load(object sender, EventArgs e)
        {
            if (!Descriptor.LoginDescriptor.RememberPassword
                ||
                !Descriptor.LoginDescriptor.RememberServer
                ||
                !Descriptor.LoginDescriptor.RememberUsername
                )
            {
                //ask..
                var frm = new LoginDialog(Descriptor.LoginDescriptor);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Descriptor.LoginDescriptor = frm.getDescritor();//update descriptor
                else
                    return;
            }

            //attempt connection
            this.vfTerminalControl1.UserName = Descriptor.LoginDescriptor.Username;
            this.vfTerminalControl1.Password = Descriptor.LoginDescriptor.Password;
            this.vfTerminalControl1.Host = Descriptor.LoginDescriptor.Server;
            this.vfTerminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;

            this.vfTerminalControl1.Connect();

            this.vfTerminalControl1.Focus();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
