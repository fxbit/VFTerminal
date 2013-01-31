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
        public bool isConnected = false;

        public string UserName;
        public string Password;
        public string Host;
        public WalburySoftware.ConnectionMethod Method = WalburySoftware.ConnectionMethod.SSH2;



        public VFTerminalControl()
            : base()
        {
            InitializeComponent();
        }


        public Task<bool> Connect()
        {
            terminalControl1.UserName = UserName;
            terminalControl1.Password = Password;
            terminalControl1.Host = Host;
            terminalControl1.Method = Method;

            //start connection
            return Task.Run<bool>(
                () =>
                {
                    //invoke connect (cross-thread operations)
                    this.Invoke((MethodInvoker)(() => terminalControl1.Connect()));

                    if (terminalControl1.TerminalPane.ConnectionTag == null)
                    {
                        isConnected = false;
                        return false;
                    }
                    else
                    {
                        isConnected = true;
                        try 
                        { 
                            terminalControl1.SetPaneColors(Color.FromArgb(255, 100, 255, 100), Color.Black);                            
                        }
                        catch { }
                        return true;
                    }
                }
            );
        }

        private void terminalControl1_MouseDown(object sender, MouseEventArgs e)
        {
            MessageBox.Show("hi");
        }
    }
}
