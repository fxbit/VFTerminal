
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
            public LoginDialog.Profile LoginProfile;
        }

        SaveLoadDescriptor Descriptor = new SaveLoadDescriptor()
        {
            isValid = true,
            LoginProfile = new LoginDialog.Profile()
            {
                isValid=false,
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
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //stop..
            timer1.Enabled = false;

            if (Descriptor.LoginProfile.isValid == false)
            {
                //ask..
                var frm = new LoginDialog(Descriptor.LoginProfile);
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Descriptor.LoginProfile = frm.SelectedProfile;
                else
                {
                    this.Close();
                    return;
                }
            }

            //attempt connection
            this.vfTerminalControl1.UserName = Descriptor.LoginProfile.Username;
            this.vfTerminalControl1.Password = Descriptor.LoginProfile.Password;
            this.vfTerminalControl1.Host = Descriptor.LoginProfile.Server;
            this.vfTerminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;

            this.vfTerminalControl1.Connect();

            this.vfTerminalControl1.Focus();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
