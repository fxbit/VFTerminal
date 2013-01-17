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
#if DEBUG
    public partial class BaseDoc : DockContent
#else
    public abstract partial class BaseDoc : DockContent
#endif
    {
        public readonly MainFrm GameEditorFrm;


#if DEBUG
        //Used only for designer!
        protected BaseDoc()
        {
            InitializeComponent();
        }
#endif

        public BaseDoc(MainFrm GameEditorFrm)
        {
            InitializeComponent();
            //keep
            this.GameEditorFrm = GameEditorFrm;
        }

#if DEBUG
        public virtual object GetSaveLoadDescriptor()
        {
            throw new NotImplementedException("You must override this!");
        }
#else
        public abstract object GetSaveLoadDescriptor();  
#endif


        protected override string GetPersistString()
        {
            // Serialize and base64 descriptor so the object knows what to load when deserializing
            return MainFrm.GetDockContentPersistString(this, GetSaveLoadDescriptor());
        }

    }
}