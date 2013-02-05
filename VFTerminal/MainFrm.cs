using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VFTerminal
{
    public partial class MainFrm : Form
    {
        #region Variables
        //-------------------------------------------------------------------------------------------------------------------------------
        bool isLayoutLoaded = false;

        string configFile;//= Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Layout.xml");

        private DeserializeDockContent m_deserializeDockContent;

        //-------------------------------------------------------------------------------------------------------------------------------

        [Serializable]
        public struct SaveLoadDescriptor
        {
            public Type Type;
            public string Text;
            public object Object_Descriptor;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion


        #region Constructor
        //-------------------------------------------------------------------------------------------------------------------------------
        public MainFrm(string configFile)
        {
            InitializeComponent();
            this.configFile = configFile;
            //decerialization helper
            m_deserializeDockContent = new DeserializeDockContent(GetContentFromPersistString);
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

        

        #region Functions
        //-------------------------------------------------------------------------------------------------------------------------------

        private void MainFrm_Load(object sender, EventArgs e)
        {
            LoadLayout();
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public virtual void LoadLayout()
        {
            //set flag
            isLayoutLoaded = true;

            //make me visible..
            this.Show();

            //load user template
            if (File.Exists(configFile))
                dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
            else
            {
                using (var stream = new MemoryStream(Encoding.Unicode.GetBytes(Resources.DefaultLayout)))
                {
                    stream.Position = 0;
                    dockPanel.LoadFromXml(stream, m_deserializeDockContent); //load default template
                }
            }

            //get forms ( or load whatever is not loaded )
            //MainViewport = Get_MainViewport_Instance();
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public static string GetDockContentPersistString(DockContent content, object Object_Descriptor)
        {
            var desc = new SaveLoadDescriptor()
            {
                Type = content.GetType(),
                Text = content.Text,
                Object_Descriptor = Object_Descriptor,
            };
            var buffer = Serialization_Master.Serializer.Serialize_Object_To_ByteArray(desc, Compress: true);
            var base64 = System.Convert.ToBase64String(buffer);
            return base64;
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public static void SetupDockContentFromPersistString(DockContent content, SaveLoadDescriptor desc)
        {
            //setup
            content.Text = desc.Text;
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private IDockContent GetContentFromPersistString(string persistString)
        {
            //decode and deserialize
            var desc = (SaveLoadDescriptor)Serialization_Master.Serializer.DeSerialize_Object_From_ByteArray(Convert.FromBase64String(persistString), Decompress: true);
            var type = desc.Type;// Type.GetType(desc.Type);
            var obj = Activator.CreateInstance(type, this, desc.Object_Descriptor) as DockContent;
            SetupDockContentFromPersistString(obj, desc);
            return obj;
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        protected virtual void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dockPanel.SaveAsXml(configFile);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public void MakeFormVisible(DockContent doc)
        {
            //make visible..
            if (doc.IsHidden)
                doc.IsHidden = false;
            //remove auto-hide
            if (doc.DockState == WeifenLuo.WinFormsUI.Docking.DockState.DockBottomAutoHide)
                doc.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockBottom;
            else if (doc.DockState == WeifenLuo.WinFormsUI.Docking.DockState.DockLeftAutoHide)
                doc.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockLeft;
            else if (doc.DockState == WeifenLuo.WinFormsUI.Docking.DockState.DockTopAutoHide)
                doc.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockTop;
            else if (doc.DockState == WeifenLuo.WinFormsUI.Docking.DockState.DockRightAutoHide)
                doc.DockState = WeifenLuo.WinFormsUI.Docking.DockState.DockRight;
            //focus
            doc.Focus();
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void newTerminalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new TerminalDoc(this);
            frm.Show(dockPanel);
            MakeFormVisible(frm);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void newDummyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new DummyDoc(this);
            frm.Show(dockPanel);
            MakeFormVisible(frm);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void saveLayoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            dockPanel.SaveAsXml(saveFileDialog1.FileName);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void loadWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            //set filname
            configFile = openFileDialog1.FileName;

            //load...
            LoadLayout();
        }
        
        //-------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
