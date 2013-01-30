using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFTerminal
{
    public partial class LoginDialog : Form
    {
        [Serializable]
        public struct Descriptor
        {
            public bool RememberServer;
            public bool RememberUsername;
            public bool RememberPassword;
            public string Server;
            public string Username;
            public string Password;
        }

        public LoginDialog(Descriptor desc)
        {
            InitializeComponent();
            //setup items from descriptor
            txt_server.Text = desc.Server;
            txt_username.Text = desc.Username;
            txt_server.Text = desc.Password;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public Descriptor getDescritor() 
        {
            return new Descriptor()
            {
                RememberServer = chk_remember_server.Checked,
                RememberUsername = chk_remeber_username.Checked,
                RememberPassword = chk_remember_pass.Checked,
                Server = txt_server.Text,
                Username = txt_username.Text,
                Password = txt_pass.Text,
            };
        }
    }
}
