
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using System.Threading.Tasks;

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
            public string LoginProfile;
        }

        SaveLoadDescriptor Descriptor = new SaveLoadDescriptor()
        {
            isValid = true,
            LoginProfile = "",
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

            if (Descriptor.LoginProfile == "" || LoginDialog.Profiles.ContainsKey(Descriptor.LoginProfile) == false)
            {
                //ask..
                var frm = new LoginDialog();
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    Descriptor.LoginProfile = frm.SelectedProfile;
                else
                {
                    this.Close();
                    return;
                }
            }

            //attempt connection
            var profile = LoginDialog.Profiles[Descriptor.LoginProfile];
            this.vfTerminalControl1.UserName = profile.Username;
            this.vfTerminalControl1.Password = profile.Password;
            this.vfTerminalControl1.Host = profile.Server;
            this.vfTerminalControl1.Method = WalburySoftware.ConnectionMethod.SSH2;
                        
            this.vfTerminalControl1.ConnectAsync();
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
