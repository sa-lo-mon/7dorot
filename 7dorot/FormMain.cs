using Firebase.Database;
using Firebase.Storage;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ShevaDorot.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShevaDorot
{
    public partial class FormMain : Form
    {
        FirebaseDBManager firebaseDBManager;
        List<System.Drawing.Image> usersImages;
        Dictionary<string, string> regions = new Dictionary<string, string>();
        Dictionary<string, string> statuses = new Dictionary<string, string>();
        Dictionary<string, string> genders = new Dictionary<string, string>();
        Dictionary<string, string> relAffs = new Dictionary<string, string>();

        public FormMain()
        {
            InitializeComponent();
            InitializeControls();
            InitializeServices();
            tabPageCreate.Enabled = false;
        }

        private void InitializeServices()
        {
            firebaseDBManager = new FirebaseDBManager();
            dataGridViewSearch.DataSource = bindingSourceSearch;
        }

        private async Task<string> GetDownloadImageUrl(FirebaseStorageReference storageRef, string userName)
        {
            if (storageRef == null) return null;

            var task = storageRef.Child(userName + ".jpg")
                .GetDownloadUrlAsync();

            return await task;
        }

        private void InitializeControls()
        {
            InitReligiousAffiliation();
            InitGender();
            InitRegion();
            InitStatus();
        }

        private void InitStatus()
        {
            foreach (Status item in Enum.GetValues(typeof(Status)))
            {
                string key = GetStatusName(item);
                string value = ((int)item).ToString();
                statuses.Add(key, value);
            }
            comboBoxStatus.DataSource = new BindingSource(statuses, null);
            comboBoxStatus.DisplayMember = "Key";
            comboBoxStatus.ValueMember = "Value";
        }

        private string GetStatusName(Status item)
        {
            string name = string.Empty;
            switch (item)
            {
                case Status.Single:
                    name = "רווק";
                    break;
                case Status.Divorced:
                    name = "גרוש";
                    break;
                case Status.Widow:
                    name = "אלמן";
                    break;
                default:
                    break;
            }
            return name;
        }

        private void InitRegion()
        {
            foreach (Region item in Enum.GetValues(typeof(Region)))
            {
                string key = GetRegionName(item);
                string value = ((int)item).ToString();
                regions.Add(key, value);
            }
            comboBoxRegion.DataSource = new BindingSource(regions, null);
            comboBoxRegion.DisplayMember = "Key";
            comboBoxRegion.ValueMember = "Value";
        }

        private string GetRegionName(Region item)
        {
            string name = string.Empty;
            switch (item)
            {
                case ShevaDorot.Region.North:
                    name = "צפון";
                    break;
                case ShevaDorot.Region.Center:
                    name = "מרכז";
                    break;
                case ShevaDorot.Region.South:
                    name = "דרום";
                    break;
                default:
                    break;
            }
            return name;
        }

        private void InitGender()
        {
            foreach (Gender item in Enum.GetValues(typeof(Gender)))
            {
                string key = GetGenderName(item);
                string value = ((int)item).ToString();
                genders.Add(key, value);
            }
            BindingSource genderBindSource = new BindingSource(genders, null);
            comboBoxGender.DataSource = genderBindSource;
            comboBoxGender.DisplayMember = "Key";
            comboBoxGender.ValueMember = "Value";
            comboBoxGender2.DataSource = genderBindSource;
            comboBoxGender2.DisplayMember = "Key";
            comboBoxGender2.ValueMember = "Value";
        }

        private string GetGenderName(Gender item)
        {
            string name = string.Empty;
            switch (item)
            {
                case Gender.Man: name = "גבר"; break;
                case Gender.Woman: name = "אישה"; break;
                default: name = "לא מוגדר"; break;
            }
            return name;
        }

        private void InitReligiousAffiliation()
        {
            foreach (ReligiousAffiliation item in Enum.GetValues(typeof(ReligiousAffiliation)))
            {
                string key = GetRelAffName(item);
                string value = ((int)item).ToString();
                relAffs.Add(key, value);
            }

            BindingSource relAffBindingSource = new BindingSource(relAffs, null);
            comboBoxReligiousAffiliation.DataSource = relAffBindingSource;
            comboBoxReligiousAffiliation.DisplayMember = "Key";
            comboBoxReligiousAffiliation.ValueMember = "Value";
            comboBoxRelAff.DataSource = relAffBindingSource;
            comboBoxRelAff.DisplayMember = "Key";
            comboBoxRelAff.ValueMember = "Value";
        }

        private string GetRelAffName(ReligiousAffiliation item)
        {
            string name = string.Empty;
            switch (item)
            {
                case ReligiousAffiliation.Religious: name = "דתי"; break;
                case ReligiousAffiliation.NationalReligious: name = "דתי-לאומי"; break;
                case ReligiousAffiliation.Orthodox: name = "חרדי"; break;
                case ReligiousAffiliation.NationalOrthodox: name = "חרדי-לאומי"; break;
                case ReligiousAffiliation.Traditional: name = "מסורתי"; break;
                default: name = "לא מוגדר"; break;
            }
            return name;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // track changes in controls
            //dirtyTracker = new DirtyTracker(this);

            if (string.IsNullOrEmpty(Settings.Default.UserName) ||
                string.IsNullOrEmpty(Settings.Default.UserName))
            {
                //Hide main tab control and display it just after the admin logs-in!
                tabControlMain.Hide();
                loginToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Enabled = false;
            }
            else
            {
                loginToolStripMenuItem.Enabled = false;
                logoutToolStripMenuItem.Enabled = true;
            }
        }

        // Extra helper code
        private async void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!isValidEntry())
            {
                MessageBox.Show("User must contain FirstName and LastName!");
                return;
            }

            bool isInDB = await isEntryInDB();
            if (!isInDB)
            {
                createEntry();
            }
            else
            {
                MessageBox.Show("This user is already in the database!");
            }
        }

        private bool isValidEntry()
        {
            if (string.IsNullOrEmpty(textBoxFirstName.Text) ||
                string.IsNullOrEmpty(textBoxLastName.Text) ||
                string.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void printAllDbContent()
        {
            /*
            List<MongoUser> users = dbManager.DataBase.GetCollection("users").AsQueryable<MongoUser>().ToList<MongoUser>();
            foreach (MongoUser user in users)
            {
                MessageBox.Show(string.Format("{0}, {1}", user.FirstName, user.LastName));
            }
            */
        }

        private async Task<bool> isEntryInDB()
        {
            bool isExist = false;
            var users = await firebaseDBManager.FirebaseClient.Child("users").OnceAsync<User>();
            if (users != null)
            {
                // (first_name AND last_name) AND (email OR phone_number)
                var res = users.Where(u => (u.Object?.first_name == textBoxFirstName.Text) &&
                u.Object?.first_name == textBoxFirstName.Text)
                .Where(u => u.Object?.email == textBoxEmail.Text ||
                u.Object?.phone_number == textBoxPhoneNumber.Text).ToList();

                isExist = res != null && res.Capacity > 0;
            }

            return isExist;
        }

        private async void createEntry()
        {
            User user = getUserFromForm();
            string msg = null;
            try
            {
                var users = firebaseDBManager.FirebaseClient.Child("users");
                await users.PutAsync(user);
                msg = string.Format("New user with the name: {0}, was created successfuly!", user.first_name);

                clearTextBoxControls(panelCreateForm.Controls);
            }
            catch (Exception ex)
            {
                msg = "Error has occured while inserting user to the database!" + "\n" + ex.Message;
            }

            MessageBox.Show(msg);
        }

        private User getUserFromForm()
        {
            User user = new User();
            user.age = textBoxAge.Text;
            user.performance = textBoxAppearance.Text;
            user.education = textBoxEducation.Text;
            user.email = textBoxEmail.Text;
            user.first_name = textBoxFirstName.Text;
            user.height = textBoxHeight.Text;
            user.profile_image_id = textBoxImageUrl.Text;
            user.last_name = textBoxLastName.Text;
            user.characteritics = textBoxMyCharacteritics.Text;
            user.occupation = textBoxOccupation.Text;
            user.phone_number = textBoxPhoneNumber.Text;
            user.spouse_characteritics = textBoxSpouseCharacteritics.Text;
            user.region = comboBoxRegion.SelectedValue.ToString();
            user.religious_affiliation = comboBoxRelAff.SelectedValue.ToString();
            user.status = comboBoxStatus.SelectedValue.ToString();
            user.gender = comboBoxGender2.SelectedValue.ToString();
            return user;
        }

        private void clearTextBoxControls(Control.ControlCollection controls)
        {
            if (controls == null)
                return;

            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is PictureBox)
                {
                    ((PictureBox)control).Image = null;
                }
                else if (control is Panel || control is GroupBox)
                {
                    clearTextBoxControls(control.Controls);
                }
            }
        }

        private void buttonChooseImage_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == openFileDialogUserImage.ShowDialog())
            {
                string filePath = openFileDialogUserImage.FileName;
                pictureBoxUserImage.LoadAsync(filePath);
                textBoxImageUrl.Text = Path.GetFileName(filePath);
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            searchUsers();
        }

        private async void searchUsers()
        {
            var users = await firebaseDBManager.FirebaseClient.Child("users").OnceAsync<User>();

            int startAge = (int)numericUpDownFrom.Value;
            int endAge = (int)numericUpDownUntilAge.Value;
            string gender = ((KeyValuePair<string, string>)comboBoxGender.SelectedItem).Value;
            string religious = ((KeyValuePair<string, string>)comboBoxReligiousAffiliation.SelectedItem).Value;
            bool withImage = checkBoxWithPicture.Checked;

            var users2 = users.Where(u => u.Object?.age != null && int.Parse(u.Object?.age) >= int.Parse(startAge.ToString()))
                 .Where(u => int.Parse(u.Object?.age) <= int.Parse(endAge.ToString()))
                 .Where(u => u.Object?.gender == gender)
                 .Where(u => u.Object?.religious_affiliation == religious);

            // if user want a picture "image-url" must contain an image
            if (withImage)
            {
                users2.Where(u => !string.IsNullOrEmpty(u.Object?.profile_image_id));
            }

            var validUsers = new List<User>();

            foreach (FirebaseObject<User> userObject in users2.ToList()) {

                validUsers.Add(userObject.Object);
            }

            if (validUsers.Count() > 0)
            {
                // i got the users here. now i need to get their images!
                usersImages = getUsersImages(validUsers);

                bindingSourceSearch.DataSource = validUsers;
            }
            else
            {
                MessageBox.Show("Search completed without results!");
            }
        }

        private List<System.Drawing.Image> getUsersImages(List<User> validUsers)
        {
            List<System.Drawing.Image> imagesLIst = new List<System.Drawing.Image>();
            foreach (User user in validUsers)
            {
                string imageDownloadUrl = user.images[0].url;
                System.Drawing.Image image = getImageFromUrl(imageDownloadUrl);
                imagesLIst.Add(image);
            }

            return imagesLIst;
        }

        private bool isValidUser(User user)
        {
            int userAge = 0;
            int.TryParse(user.age, out userAge);

            int startAge = (int)numericUpDownFrom.Value;
            int endAge = (int)numericUpDownUntilAge.Value;
            string gender = comboBoxGender.SelectedText;
            string religious = comboBoxReligiousAffiliation.Text;
            bool withImage = checkBoxWithPicture.Checked;

            if ((userAge >= startAge && userAge <= endAge) &&
                           (!string.IsNullOrEmpty(user.images[0].url) || !withImage) &&
                           (user.religious_affiliation == religious))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void dataGridViewSearch_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (e.ColumnIndex == 24)
            {
                if (usersImages == null || e.RowIndex >= usersImages.Count)
                {
                    e.Value = null;
                    return;
                }

                e.Value = usersImages[e.RowIndex];
            }
        }

        private System.Drawing.Image getImageFromUrl(string url)
        {
            if (url == null || url == "no-image")
                return null;

            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            using (HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (Stream stream = httpWebReponse.GetResponseStream())
                {
                    return System.Drawing.Image.FromStream(stream);
                }
            }
        }

        private void dataGridViewSearch_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridViewSearch.RowCount <= 0)
                return;

            if (dataGridViewSearch.SelectedRows.Count > 1)
                return;

            // only if current selected row is double clicked, 
            // set the create tab to be the current tab
            if (dataGridViewSearch.SelectedRows[0].Selected)
            {
                bindingSourceSearch.ResetCurrentItem();

                // extract the image cell from the selected row 
                // and put its value inside the picture box in create/update form
                DataGridViewCell cell = dataGridViewSearch.SelectedRows[0].Cells["profileimageidDataGridViewTextBoxColumn"];
                if (cell.FormattedValue is System.Drawing.Image)
                {
                    System.Drawing.Image image = (System.Drawing.Image)cell.FormattedValue;
                    pictureBoxUserImage.Image = image;
                }

                tabPageCreate.Enabled = true;
                this.tabControlMain.SelectTab(tabPageCreate.Name);
                buttonUpdate.Show();
                buttonCreate.Hide();
            }
        }

        private void buttonShowCreateForm_Click(object sender, EventArgs e)
        {
            tabPageCreate.Enabled = true;

            // clear all text boxes in "create/update form"
            clearTextBoxControls(panelCreateForm.Controls);
            buttonUpdate.Hide();
            buttonCreate.Show();
            this.tabControlMain.SelectTab(tabPageCreate.Name);
        }

        private void buttonShowUpdateForm_Click(object sender, EventArgs e)
        {
            if (dataGridViewSearch.RowCount <= 0)
            {
                MessageBox.Show("You must search something before updating!");
                return;
            }

            if (dataGridViewSearch.SelectedRows.Count != 1)
            {
                MessageBox.Show("You must select one row for updating!");
                return;
            }

            dataGridViewSearch_RowHeaderMouseDoubleClick(sender, null);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Settings.Default.UserName) ||
                string.IsNullOrEmpty(Settings.Default.Password))
            {
                FormLogin formLogin = new FormLogin();
                if (formLogin.ShowDialog() == DialogResult.OK)
                {
                    this.loginToolStripMenuItem.Enabled = false;
                    this.logoutToolStripMenuItem.Enabled = true;
                    tabControlMain.Show();
                }
            }
        }

        private async void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var admins = await firebaseDBManager.FirebaseClient.Child("admins").OnceAsync<Admin>();

            string userName = Settings.Default.Password;
            string password = Settings.Default.UserName;

            Admin admin = admins.Where(a => a.Object?.UserName == userName && a.Object?.Password == password).FirstOrDefault().Object;

            if (admin != null)
            {
                admin.IsLoggedIn = "0";
                await firebaseDBManager.FirebaseClient.Child("admins").PostAsync(admin);
            }

            Settings.Default.UserName = string.Empty;
            Settings.Default.Save();
            Settings.Default.Password = string.Empty;
            Settings.Default.Save();
            this.loginToolStripMenuItem.Enabled = true;
            this.logoutToolStripMenuItem.Enabled = false;
            this.tabControlMain.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void buttonClearSearch_Click(object sender, EventArgs e)
        {
            dataGridViewSearch.Rows.Clear();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            if (isValidEntry())
            {
                User selectedUser = (User)dataGridViewSearch.SelectedRows[0].DataBoundItem;

                //TODO: create image in picasa album
                if (!string.IsNullOrEmpty(openFileDialogUserImage.FileName))
                {
                    string file = openFileDialogUserImage.FileName;
                    try
                    {
                        firebaseDBManager.DeleteUserPhoto(selectedUser);
                        firebaseDBManager.insertUserNewPhoto(selectedUser, file);
                        selectedUser.images[0] = new Image(textBoxImageUrl.Text);
                        firebaseDBManager.updateUser(selectedUser);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error while trying to create an image in firebase!");
                    }
                }
            }

            // initialize the file path of open-file-dialog 
            // so only a change to 'FileName' property will cause 
            // creating the file in picasa album gallery
            openFileDialogUserImage.FileName = string.Empty;
        }
    }
}