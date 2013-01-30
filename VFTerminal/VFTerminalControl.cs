using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFTerminal.TerminalControl
{
    public partial class VFTerminalControl : UserControl
    {
        public string UserName;
        public string Password;
        public string Host;
        public WalburySoftware.ConnectionMethod Method = WalburySoftware.ConnectionMethod.SSH2;



        public VFTerminalControl()
            : base()
        {
            InitializeComponent();
        }



        public bool Connect()
        {
            terminalControl1.UserName = UserName;
            terminalControl1.Password = Password;
            terminalControl1.Host = Host;
            terminalControl1.Method = Method;
            //start task
            //return Task<bool>.Run(() =>
            //{
                //try connection
                terminalControl1.Connect();

                if (terminalControl1.TerminalPane.ConnectionTag == null)
                    return false;
                else
                    try { terminalControl1.SetPaneColors(Color.Green, Color.Black); }
                    catch
                    {
                    }
                return true;
           // });
        }
    }
}
