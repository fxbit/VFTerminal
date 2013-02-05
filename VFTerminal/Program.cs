using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VFTerminal
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(params string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            //get filename from args
            string workspace_filename = "";
            if ( args.Length > 0)
            {
                workspace_filename = args[0];
            }

            //run
            Application.Run(new MainFrm(workspace_filename));
        }
    }
}
