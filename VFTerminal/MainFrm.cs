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

        [Serializable]
        public struct WorkSpaceContainer
        {
            public MemoryStream Layout;
            public Dictionary<string, VFTerminal.LoginDialog.Profile> Profiles;
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
            //make me visible..
            this.Show();

            //load user template
            if (File.Exists(configFile))
                LoadWorkspace(configFile);
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
            //TOOD: ask..
            if (configFile == "")
                return;

            //serialize and save to file
            //?
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public void SaveWorkspace(string filename)
        {
            //output final stream to file..
            using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
            {
                var ms = SerializeWorkspace();
                ms.Position = 0;
                ms.CopyTo(fs);
                ms.Close(); ms.Dispose();
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        public MemoryStream SerializeWorkspace()
        {
            //clone workspace container
            var container = new WorkSpaceContainer();
            //create layout stream
            using (var ms = new MemoryStream(1024 * 2))
            {
                //create layout(xml)
                dockPanel.SaveAsXml(ms, Encoding.ASCII,true);
                ms.Position = 0;
                container.Layout = ms;
                //collect profiles
                container.Profiles = LoginDialog.Profiles;
                //serialize container to stream
                var ser = Serialization_Master.Serializer.Serialize_Object(container, Compress: true);
                ser.Position = 0;
                return ser;
            }            
        }

        
        //-------------------------------------------------------------------------------------------------------------------------------

        public void LoadWorkspace(string filename)
        {
            //read file            
            using (var ms = new MemoryStream(1024 * 10))
            {
                //read to memory
                using (var fs = new FileStream(configFile, FileMode.Open, FileAccess.Read))
                    fs.CopyTo(ms);

                //deserialize container
                ms.Position = 0;
                var container = (WorkSpaceContainer)Serialization_Master.Serializer.DeSerialize_Object(ms, Decompress: true);
                //load layout
                dockPanel.LoadFromXml(container.Layout, m_deserializeDockContent);
                //retore profiles..
                LoginDialog.Profiles = container.Profiles;
            }
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
            if (saveFileDialog_workspace.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            //serialize and save to file
            SaveWorkspace(saveFileDialog_workspace.FileName);
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void loadWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog_workspace.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                return;

            //set filname
            configFile = openFileDialog_workspace.FileName;

            //load...
            LoadLayout();
        }

        //-------------------------------------------------------------------------------------------------------------------------------

        private void saveWorkspaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TOOD: ask..
            if (configFile == "")
            {
                if (saveFileDialog_workspace.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
                else
                    configFile = saveFileDialog_workspace.FileName;
            }

            //serialize and save to file
            SaveWorkspace(configFile);
        }
        
        //-------------------------------------------------------------------------------------------------------------------------------


        //-------------------------------------------------------------------------------------------------------------------------------
        #endregion

    }
}
