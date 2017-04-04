using Firebase.Database;
using ShevaDorot.DAL;
using ShevaDorot.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace ShevaDorot
{
    public partial class FormLogin : Form
    {
        DBManager firebaseDBManager = null;
        public FormLogin()
        {
            InitializeComponent();
            firebaseDBManager = new DBManager();
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            if (firebaseDBManager == null)
                firebaseDBManager = new DBManager();

            var admins = await firebaseDBManager.FirebaseClient.Child("admins").OnceAsync<Admin>();
            string userName = textBoxUserName.Text;
            string password = textBoxPassword.Text;
            List<FirebaseObject<Admin>> adminss = admins.ToList();

            FirebaseObject<Admin> adminObject = admins.Where(a => a.Object?.Email == userName && a.Object?.Password == password).FirstOrDefault();
            if (adminObject != null)
            {
                Admin admin = adminObject.Object;
                Settings.Default.UserName = admin.UserName;
                Settings.Default.Save();
                Settings.Default.Password = admin.Password;
                Settings.Default.Save();

                admin.IsLoggedIn = "1";
                admin.LastLoginDate = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                await firebaseDBManager.FirebaseClient.Child("admins").PostAsync(admin);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You inserted invalid creadentials!\n Please try again!");
            }
        }
    }
}
