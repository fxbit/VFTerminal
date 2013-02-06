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
        //----------------------------------------------------------------------------------------------------------------------

        public static Dictionary<string, Profile> Profiles = new Dictionary<string, Profile>();

        //----------------------------------------------------------------------------------------------------------------------

        [Serializable]
        public struct Profile
        {
            public bool isValid;
            public string ProfileName;
            public string Server;
            public string Username;
            public string Password;

            public override string ToString()
            {
                return ProfileName;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------

        public string SelectedProfile = "";

        //----------------------------------------------------------------------------------------------------------------------

        static LoginDialog()
        {
            //load profiles..
            lock (Profiles)
                try
                {
                    //load..
                    //Profiles = (Dictionary<string, Profile>)Serialization_Master.Serializer.DeSerialize_Object_From_File("profiles.bin", Decompress: true);
                    //check..
                    //if (Profiles == null)
                    //    Profiles = new Dictionary<string, Profile>();
                }
                catch
                {
                    Profiles = new Dictionary<string, Profile>();
                }
        }

        //----------------------------------------------------------------------------------------------------------------------

        public LoginDialog()
        {
            InitializeComponent();
        }
        
        //----------------------------------------------------------------------------------------------------------------------

        private void LoginDialog_Load(object sender, EventArgs e)
        {
            RefreshProfiles();
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void RefreshProfiles()
        {
            listBox1.Items.Clear();
            lock (Profiles)
                foreach (var profile in Profiles)
                    listBox1.Items.Add(profile.Value);
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("You must select a profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelectedProfile = ((Profile)listBox1.SelectedItem).ProfileName;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void button3_Click(object sender, EventArgs e)
        {
            //trim..
            txt_prof_name.Text = txt_prof_name.Text.Trim();

            //check fields
            if (txt_prof_name.Text == ""
                ||
                txt_username.Text == ""
                ||
                txt_server.Text == ""
                ||
                txt_pass.Text == ""
                )
            {
                MessageBox.Show("All fields must be filled", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //check if exists
            if (Profiles.ContainsKey(txt_prof_name.Text))
                if (MessageBox.Show("A profile with the same name already exists.Do you wish to overwrite it?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                    return;

            //create profile
            var profile = new Profile()
            {
                isValid = true,
                ProfileName = txt_prof_name.Text,
                Server = txt_server.Text,
                Username = txt_username.Text,
                Password = txt_pass.Text
            };

            //write-overwrite            
            if (Profiles.ContainsKey(txt_prof_name.Text))
                Profiles[txt_prof_name.Text] = profile;
            else
                Profiles.Add(profile.ProfileName, profile);

            //save/overwrite file
            lock (Profiles)
            {
                //Serialization_Master.Serializer.Serialize_Object_to_File(Profiles, "profiles.bin", Compress: true, overwrite: true);
            }

            //refresh list
            RefreshProfiles();
        }

        //----------------------------------------------------------------------------------------------------------------------

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("You must select a profile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //get profile
            var profile = (Profile)listBox1.SelectedItem;
            //ask..
            if (MessageBox.Show("Are you sure you want to delete profile " + profile.ProfileName, "Delete Profile?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                return;
            //remove and save
            lock (Profiles)
            {
                if (Profiles.ContainsKey(profile.ProfileName))
                {
                    Profiles.Remove(profile.ProfileName);
                    //Serialization_Master.Serializer.Serialize_Object_to_File(Profiles, "profiles.bin", Compress: true, overwrite: true);
                }
            }

            //refresh list
            RefreshProfiles();
        }

        //----------------------------------------------------------------------------------------------------------------------
        
    }
}
