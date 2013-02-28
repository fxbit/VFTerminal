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

            //register stupid poderosa msges..
            terminalControl1.TerminalPane.OnMouseDownAction = terminalControl1_MouseDown;
            terminalControl1.TerminalPane.OnOnKeyDownAction = terminalControl1_KeyDown;
        }


        public void ConnectAsync(Action OnConnectionFinish = null, Action OnConnectionSuccessfull = null, Action OnConnectionFailed = null)
        {
            terminalControl1.UserName = UserName;
            terminalControl1.Password = Password;
            terminalControl1.Host = Host;
            terminalControl1.Method = Method;

            label1.Visible = true;
            //start connection
            Task.Run(
                () =>
                {
                    try
                    {
                        //connect
                        terminalControl1.Connect(this);
                        this.Invoke((MethodInvoker)(() => label1.Visible = false));


                        //run callback
                        if (OnConnectionFinish != null)
                            OnConnectionFinish();

                        //check results
                        if (terminalControl1.TerminalPane.ConnectionTag == null)
                        {
                            isConnected = false;
                            if (OnConnectionFailed != null)
                                OnConnectionFailed();
                        }
                        else
                        {
                            isConnected = true;
                            try
                            {
                                terminalControl1.SetPaneColors(Color.FromArgb(255, 100, 255, 100), Color.Black);
                            }
                            catch { }
                            if (OnConnectionSuccessfull != null)
                                OnConnectionSuccessfull();
                        }
                    }
                    catch (Exception ex) { 
                        MessageBox.Show(ex.Message); 
                        // TODO: send failed cb to upper layer 
                    }
                    
                }
            );
        }

        private void terminalControl1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Middle)
                terminalControl1.PasteTextFromClipboard();
        }

        private void terminalControl1_KeyDown(object sender, KeyEventArgs e)
        {
            //..
        }
    }
}
