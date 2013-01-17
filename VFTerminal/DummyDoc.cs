
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
    public partial class DummyDoc : BaseDoc
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
        protected DummyDoc()
        {
            InitializeComponent();
        }
#endif
        //-------------------------------------------------------------------------------------------------------------------------------
        public DummyDoc(MainFrm GameEditorFrm)
            : base(GameEditorFrm)
        {
            InitializeComponent();
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        public DummyDoc(MainFrm GameEditorFrm, object Descriptor)
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
