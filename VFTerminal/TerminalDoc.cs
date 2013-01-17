
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
        #endregion

    }
}
