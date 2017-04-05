using Firebase.Database;
using ShevaDorot.DAL;
using ShevaDorot.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        DBManager firebaseDBManager;
        Dictionary<string, System.Drawing.Image> usersImages;

        public FormMain()
        {
            InitializeComponent();
            InitializeSearchFormControls();
            InitializeServices();
            tabPageCreate.Enabled = false;
        }

        private void InitializeServices()
        {
            firebaseDBManager = new DBManager();
            dataGridViewSearch.DataSource = bindingSourceSearch;
        }

        private void InitializeSearchFormControls()
        {
            InitHeightSearchForm();
            InitReligiousLevelSearchForm();
            InitGenderSearchForm();
            InitFamilyStatusSearchForm();
            InitPrayerFrequencySearchForm();
            InitEtnicitySearchForm();
            InitEducationSearchForm();
            InitEconomicStatusSearchForm();
            InitSmokingHabitsSearchForm();
        }

        private void BindControlData(ListControl contorl, SpinnerData data)
        {
            contorl.DataSource = new BindingSource(data.GetTypes(), null);
            contorl.DisplayMember = "Value";
            contorl.ValueMember = "Key";
        }

        private void InitHeightSearchForm()
        {
            HeightType heightType = new HeightType();
            BindControlData(comboBoxHeightFrom, heightType);
            BindControlData(comboBoxHeightTo, heightType);
        }

        private void InitSmokingHabitsSearchForm()
        {
            SmokingHabitType smokingHabitTypes = new SmokingHabitType();
            BindControlData(checkedListBoxSmokingHabits, smokingHabitTypes);
        }

        private void InitEconomicStatusSearchForm()
        {
            EconomicStatusType economicStatusType = new EconomicStatusType();
            BindControlData(checkedListBoxEconomicStatus, economicStatusType);
        }

        private void InitEducationSearchForm()
        {
            EducationType educationType = new EducationType();
            BindControlData(checkedListBoxEducation, educationType);
        }

        private void InitEtnicitySearchForm()
        {
            EtnicityType etnicityType = new EtnicityType();
            BindControlData(checkedListBoxEtnicity, etnicityType);
        }

        private void InitPrayerFrequencySearchForm()
        {
            PrayerFrequencyType prayerFrequencyType = new PrayerFrequencyType();
            BindControlData(checkedListBoxPrayerFrequency, prayerFrequencyType);
        }

        private void InitFamilyStatusSearchForm()
        {
            FamilyStatusType familyStatusType = new FamilyStatusType();
            BindControlData(checkedListBoxFamilyStatus, familyStatusType);
        }

        private void InitGenderSearchForm()
        {
            GenderType genderType = new GenderType();
            BindControlData(comboBoxGender, genderType);
        }

        private void InitReligiousLevelSearchForm()
        {
            ReligiousType relType = new ReligiousType();
            BindControlData(checkedListBoxReligiousLevel, relType);
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

            bool isInDB = await IsEntryInDB();
            if (!isInDB)
            {
                CreateEntry();
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
                string.IsNullOrEmpty(textBoxPhoneNumber.Text) ||
                comboBoxGender2.SelectedItem == null)
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

        private async Task<bool> IsEntryInDB()
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

        private async void CreateEntry()
        {
            User user = GetUserFromForm();
            string msg = null;
            try
            {
                if (isValidEntry())
                {
                    if ((!string.IsNullOrEmpty(textBoxImageUrl.Text)) && (!string.IsNullOrEmpty(openFileDialogUserImage.FileName)))
                    {
                        string file = openFileDialogUserImage.FileName;
                        string downloadUrl = await firebaseDBManager.InsertUserNewPhoto(user, file);
                        Image image = new Image(textBoxImageUrl.Text);
                        image.url = downloadUrl;
                        user.images = new Image[] { image };
                        user.profile_image_id = downloadUrl;
                    }

                    firebaseDBManager.InsertUser(user);
                    msg = string.Format("New user with the name: {0}, was created successfuly!", user.first_name);

                    ResetControls(panelCreateForm.Controls);
                }
            }
            catch (Exception ex)
            {
                msg = "Error has occured while inserting user to the database!" + "\n" + ex.Message;
            }

            MessageBox.Show(msg);
        }

        private User GetUserFromForm()
        {
            User user = new User();
            user.age = textBoxAge.Text;
            user.birthday = dateTimePickerBirthday.Text;
            user.performance = (string)comboBoxPerformance.SelectedValue;
            user.email = textBoxEmail.Text;
            user.first_name = textBoxFirstName.Text;
            user.height = (string)comboBoxHeight.SelectedValue;
            //user.profile_image_id = textBoxImageUrl.Text;
            user.last_name = textBoxLastName.Text;

            user.education = GetKeyCodesFromCheckedLIstBox(checkedListBoxEducation2);
            user.characteritics = GetKeyCodesFromCheckedLIstBox(checkedListBoxMyCharacteristics); ;
            user.spouse_characteritics = GetKeyCodesFromCheckedLIstBox(checkedListBoxSpouseCharacteristics);
            user.occupation = (string)comboBoxOccupation.SelectedValue;
            user.phone_number = textBoxPhoneNumber.Text;
            user.region = (string)comboBoxRegion.SelectedValue;
            user.religious_level = (string)comboBoxRelLevel.SelectedValue;
            user.status = (string)comboBoxFamilyStatus.SelectedValue;
            user.gender = (string)comboBoxGender2.SelectedValue;
            return user;
        }

        private string GetKeyCodesFromCheckedLIstBox(CheckedListBox checkedListBox)
        {
            string res = "";
            foreach (KeyValuePair<string, SpinnerData> item in checkedListBox.CheckedItems)
            {

                res += item.Key + ",";
            }

            return res;
        }

        private void ResetControls(Control.ControlCollection controls)
        {
            if (controls == null)
                return;

            foreach (Control control in controls)
            {
                if (control is TextBox)
                {
                    control.Text = string.Empty;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).Checked = false;
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedItem = null;
                }
                else if (control is ListBox)
                {
                    ((ListBox)control).ClearSelected();

                    foreach (int index in ((CheckedListBox)control).CheckedIndices)
                    {
                        ((CheckedListBox)control).SetItemChecked(index, false);
                    }

                }
                else if (control is PictureBox)
                {
                    ((PictureBox)control).Image = null;
                }
                else if (control is Panel || control is GroupBox)
                {
                    ResetControls(control.Controls);
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
            string gender = ((KeyValuePair<string, SpinnerData>)comboBoxGender.SelectedItem).Key;
            string religious = ((KeyValuePair<string, SpinnerData>)checkedListBoxReligiousLevel.SelectedItem).Key;
            bool withImage = checkBoxWithPicture.Checked;

            var users2 = users.Where(u => u.Object?.age != null && int.Parse(u.Object?.age) >= int.Parse(startAge.ToString()))
                 .Where(u => int.Parse(u.Object?.age) <= int.Parse(endAge.ToString()))
                 .Where(u => u.Object?.gender == gender)
                 .Where(u => u.Object?.religious_level == religious);

            // if user want a picture "image-url" must contain an image
            if (withImage)
            {
                users2.Where(u => !string.IsNullOrEmpty(u.Object?.profile_image_id));
            }

            var validUsers = new List<User>();

            foreach (FirebaseObject<User> userObject in users2.ToList())
            {
                User user = userObject.Object;
                user.id = userObject.Key;
                validUsers.Add(user);
            }

            if (validUsers.Count() > 0)
            {
                // i got the users here. now i need to get their images!
                usersImages = getUsersImages(validUsers);

                bindingSourceSearch.DataSource = new BindingList<User>(validUsers);
            }
            else
            {
                MessageBox.Show("Search completed without results!");
            }
        }

        private Dictionary<string, System.Drawing.Image> getUsersImages(List<User> validUsers)
        {
            Dictionary<string, System.Drawing.Image> imagesLIst = new Dictionary<string, System.Drawing.Image>();
            foreach (User user in validUsers)
            {
                if (user.images != null && user.images.Length > 0)
                {
                    string imageDownloadUrl = user.images[0].url;
                    System.Drawing.Image image = getImageFromUrl(imageDownloadUrl);
                    if (image != null)
                    {
                        image = image.GetThumbnailImage(100, 100, null, IntPtr.Zero);
                    }
                    imagesLIst.Add(imageDownloadUrl, image);
                }
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
            string religious = comboBoxRelLevel.SelectedText;
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
            User user = (User)dataGridViewSearch.Rows[e.RowIndex].DataBoundItem;

            switch (dataGridViewSearch.Columns[e.ColumnIndex].Name)
            {
                case "smokinghabitsDataGridViewTextBoxColumn": FormatSmokingHabitsCell(user, e); break;
                case "luckDataGridViewTextBoxColumn": FormatLuckCell(user, e); break;
                case "educationDataGridViewTextBoxColumn": FormatEducationCell(user, e); break;
                case "religiouslevelDataGridViewTextBoxColumn": FormatReligiousLevelCell(user, e); break;
                case "familystatusDataGridViewTextBoxColumn": FormatFamilyStatusCell(user, e); break;
                case "profileimageidDataGridViewTextBoxColumn": FormatProfileImageCell(user, e); break;
                default: break;
            }
        }

        private void FormatSmokingHabitsCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(user.smoking_habits)) return;

            string value = GetSpinnerDataCodeValue(user.smoking_habits, new SmokingHabitType());
            e.Value = value;
            e.FormattingApplied = true;
        }

        private void FormatLuckCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(user.luck)) return;

            string value = GetSpinnerDataCodeValue(user.luck, new LuckType());
            e.Value = value;
            e.FormattingApplied = true;
        }

        private void FormatEducationCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(user.education)) return;

            string value = GetSpinnerDataCodeValue(user.education, new EducationType());
            e.Value = value;
            e.FormattingApplied = true;
        }

        private string GetSpinnerDataCodeValue(string code, SpinnerData spinnerData)
        {
            string[] codes = code.Split(',');
            Dictionary<string, SpinnerData> dictionary = spinnerData.GetTypes();
            string value = "";
            foreach (string keyCode in codes)
            {
                SpinnerData data;
                dictionary.TryGetValue(keyCode, out data);
                if (data != null)
                {
                    value += data.name + ",";
                }
            }

            if (!string.IsNullOrEmpty(value))
                value = value.Substring(0, value.Length - 1);
            return value;
        }

        private void FormatReligiousLevelCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(user.religious_level)) return;

            string value = GetSpinnerDataCodeValue(user.religious_level, new ReligiousType());
            e.Value = value;
            e.FormattingApplied = true;
        }

        private void FormatFamilyStatusCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (string.IsNullOrEmpty(user.family_status)) return;

            string value = GetSpinnerDataCodeValue(user.family_status, new FamilyStatusType());
            e.Value = value;
            e.FormattingApplied = true;
        }

        private void FormatProfileImageCell(User user, DataGridViewCellFormattingEventArgs e)
        {
            if (usersImages == null)
            {
                e.Value = null;
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(user.profile_image_id) && usersImages[user.profile_image_id] != null)
                    {
                        e.Value = usersImages[user.profile_image_id];
                        e.FormattingApplied = true;
                    }
                }
                catch (KeyNotFoundException ex)
                {
                    //key not found
                    Console.WriteLine(ex.Message);
                }
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
                tabControlMain.SelectTab(tabPageCreate.Name);
                InitCreateFormFields();
                User user = (User)dataGridViewSearch.SelectedRows[0].DataBoundItem;

                //TODO: load selected search user details into search form fields!
                LoadCreateFormFromUser(user);

                buttonUpdate.Show();
                buttonCreate.Hide();
            }
        }

        private void LoadCreateFormFromUser(User user)
        {
            textBoxAge.Text = user.age;
            DateTime birthDate;
            dateTimePickerBirthday.Value = (DateTime.TryParse(user.birthday, out birthDate) ? birthDate : DateTime.Now);

            textBoxEmail.Text = user.email;
            textBoxFirstName.Text = user.first_name;
            //textBoxImageUrl.Text = user.profile_image_id;
            textBoxLastName.Text = user.last_name;
            textBoxPhoneNumber.Text = user.phone_number;

            SetComboBoxValue(comboBoxOccupation, user.occupation);
            SetComboBoxValue(comboBoxHeight, user.height);
            SetComboBoxValue(comboBoxPerformance, user.performance);
            SetComboBoxValue(comboBoxRegion, user.region);
            SetComboBoxValue(comboBoxRelLevel, user.religious_level);
            SetComboBoxValue(comboBoxFamilyStatus, user.status);
            SetComboBoxValue(comboBoxGender2, user.gender);

            CheckCheckedkListBoxByString(checkedListBoxEducation2, user.education);
            CheckCheckedkListBoxByString(checkedListBoxMyCharacteristics, user.characteritics);
            CheckCheckedkListBoxByString(checkedListBoxSpouseCharacteristics, user.spouse_characteritics);
        }

        private void SetComboBoxValue(ComboBox comboBox, string value)
        {
            if (value != null)
            {
                comboBox.SelectedValue = value;
            }
        }

        private void CheckCheckedkListBoxByString(CheckedListBox checkedListBox, string selectedIndices)
        {
            if (string.IsNullOrEmpty(selectedIndices)) return;

            KeyValuePair<string, SpinnerData> item;
            string[] indices = selectedIndices.Split(',');
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                item = (KeyValuePair<string, SpinnerData>)checkedListBox.Items[i];
                if (!string.IsNullOrEmpty(indices.FirstOrDefault(s => s.Equals(item.Key))))
                {
                    checkedListBox.SetItemChecked(i, true);
                }
            }
        }

        private void buttonShowCreateForm_Click(object sender, EventArgs e)
        {
            tabPageCreate.Enabled = true;

            // init all contorls in "create/update form"
            ResetControls(panelCreateForm.Controls);
            buttonUpdate.Hide();
            buttonCreate.Show();
            InitCreateFormFields();
            this.tabControlMain.SelectTab(tabPageCreate.Name);
        }

        private void InitCreateFormFields()
        {
            InitFamilyStatusCreateForm();
            InitHeightCreateForm();
            InitRegionCreateForm();
            InitReligiousLevelCreateForm();
            InitGenderCreateForm();
            InitPerformanceCreateForm();
            InitOccupationCreateForm();
            InitEducationCreateForm();
            InitMyCharacteristicsCreateForm();
            InitSpouseCharacteristicsCreateForm();
        }

        private void InitOccupationCreateForm()
        {
            OccupationType occupationType = new OccupationType();
            BindControlData(comboBoxOccupation, occupationType);
        }

        private void InitFamilyStatusCreateForm()
        {
            FamilyStatusType familyStatusType = new FamilyStatusType();
            BindControlData(comboBoxFamilyStatus, familyStatusType);
        }

        private void InitSpouseCharacteristicsCreateForm()
        {
            CharacteristicsType characteristicsType = new CharacteristicsType();
            BindControlData(checkedListBoxSpouseCharacteristics, characteristicsType);
        }

        private void InitMyCharacteristicsCreateForm()
        {
            CharacteristicsType characteristicsType = new CharacteristicsType();
            BindControlData(checkedListBoxMyCharacteristics, characteristicsType);
        }

        private void InitEducationCreateForm()
        {
            EducationType educationType = new EducationType();
            BindControlData(checkedListBoxEducation2, educationType);
        }

        private void InitPerformanceCreateForm()
        {
            PerformanceType performanceType = new PerformanceType();
            BindControlData(comboBoxPerformance, performanceType);
        }

        private void InitGenderCreateForm()
        {
            GenderType genderType = new GenderType();
            BindControlData(comboBoxGender2, genderType);
        }

        private void InitReligiousLevelCreateForm()
        {
            ReligiousType relType = new ReligiousType();
            BindControlData(comboBoxRelLevel, relType);
        }

        private void InitRegionCreateForm()
        {
            ResidentialAreaPrimaryType residentialAreaPrimaryType = new ResidentialAreaPrimaryType();
            BindControlData(comboBoxRegion, residentialAreaPrimaryType);
        }

        private void InitHeightCreateForm()
        {
            HeightType heightType = new HeightType();
            BindControlData(comboBoxHeight, heightType);
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
            //TODO: change this - get admin list from firebaseDBManager
            var admins = await firebaseDBManager.FirebaseClient.Child("admins").OnceAsync<Admin>();


            string password = Settings.Default.Password;
            string userName = Settings.Default.UserName;

            Admin admin = admins.Where(a => a.Object?.UserName == userName && a.Object?.Password == password).FirstOrDefault().Object;

            if (admin != null)
            {
                admin.IsLoggedIn = "0";

                //TODO: change this - update logout inside firebaseDBManager
                await firebaseDBManager.FirebaseClient.Child("admins/" + admin.Id).PutAsync(admin);
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

        private async void buttonUpdate_Click(object sender, EventArgs e)
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
                        //firebaseDBManager.DeleteUserPhoto(selectedUser);
                        string downloadUrl = await firebaseDBManager.InsertUserNewPhoto(selectedUser, file);
                        Image image = new Image(textBoxImageUrl.Text);
                        image.url = downloadUrl;
                        selectedUser.images[0] = image;
                        selectedUser.profile_image_id = downloadUrl;
                        firebaseDBManager.UpdateUser(selectedUser);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while trying to create an image in firebase! " + ex.Message);
                    }
                }
            }

            // initialize the file path of open-file-dialog 
            // so only a change to 'FileName' property will cause 
            // creating the file in picasa album gallery
            openFileDialogUserImage.FileName = string.Empty;
        }

        private void dateTimePickerBirthday_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerBirthday.Value;
            CalculateAgeFromDateTime(date).ToString();
            textBoxAge.Text = CalculateAgeFromDateTime(date).ToString();
        }

        private int CalculateAgeFromDateTime(DateTime dateOfBirth)
        {
            if (dateOfBirth == null) return 0;

            //long ageInMillis = DateTime.Now.Ticks - date.Ticks;
            //double ageInSecs = ageInMillis / 1000;
            //double years = (double)Math.Floor(ageInSecs / 31536000);
            //return years.ToString();

            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(dateOfBirth.ToString("yyyyMMdd"));
            return ((now - dob) / 10000);
        }
    }
}