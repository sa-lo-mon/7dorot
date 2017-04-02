using Firebase.Auth;
using Firebase.Database;
using Firebase.Storage;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ShevaDorot
{
    public class FirebaseDBManager
    {
        string FIREBASE_DATABASE;
        string FIREBASE_STORGAE;
        string FIREBASE_API_KEY;
        string FIREBASE_USER_NAME;
        string FIREBASE_PASSWORD;

        public FirebaseAuthProvider AuthProvider { get; internal set; }
        public FirebaseAuthLink AuthLink { get; internal set; }
        public FirebaseClient FirebaseClient { get; internal set; }
        public FirebaseStorage FirebaseStorage { get; internal set; }
        public FirebaseStorageReference WomenAlbumRef { get; internal set; }
        public FirebaseStorageReference MenAlbumRef { get; internal set; }

        public FirebaseDBManager()
        {
            init();
        }

        private async void init()
        {
            FIREBASE_API_KEY = ConfigurationManager.AppSettings["FIREBASE_API_KEY"];
            FIREBASE_DATABASE = ConfigurationManager.AppSettings["FIREBASE_DATABASE"];
            FIREBASE_STORGAE = ConfigurationManager.AppSettings["FIREBASE_STORGAE"];
            FIREBASE_USER_NAME = ConfigurationManager.AppSettings["FIREBASE_USER_NAME"];
            FIREBASE_PASSWORD = ConfigurationManager.AppSettings["FIREBASE_PASSWORD"];

            AuthProvider = new FirebaseAuthProvider(new FirebaseConfig(FIREBASE_API_KEY));
            AuthLink = await AuthProvider.SignInWithEmailAndPasswordAsync(FIREBASE_USER_NAME, FIREBASE_PASSWORD);

            FirebaseClient = new FirebaseClient(FIREBASE_DATABASE, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(AuthLink.FirebaseToken)
            });

            FirebaseStorage = new FirebaseStorage(FIREBASE_STORGAE, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(AuthLink.FirebaseToken)
            });
            MenAlbumRef = FirebaseStorage.Child("albums").Child("men");
            WomenAlbumRef = FirebaseStorage.Child("albums").Child("women");
        }

        internal async void DeleteUserPhoto(User user)
        {
            try
            {
                FirebaseStorageReference imageRef;
                if (user.gender.Equals("1")) // if gender is male
                {
                    imageRef = MenAlbumRef.Child(user.images[0].url);
                }
                else
                {
                    imageRef = WomenAlbumRef.Child(user.images[0].url);
                }

                await imageRef.DeleteAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal async Task<string> insertUserNewPhoto(User user, string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            FileStream fileStream = fileInfo.OpenRead();

            string downloadUrl;
            string fileName = string.Format("{0}_{1}", user.email, fileInfo.Name);
            if (user.gender.Equals("1"))
            {
                downloadUrl = await MenAlbumRef.Child(fileName).PutAsync(fileStream);
            }
            else
            {
                downloadUrl = await WomenAlbumRef.Child(fileName).PutAsync(fileStream);
            }

            fileStream.Close();
            return downloadUrl;
        }

        internal async void updateUser(User selectedUser)
        {
            await FirebaseClient.Child("users/" + selectedUser.id).PutAsync(selectedUser);
        }

        internal async void InsertUser(User user)
        {
            var child = FirebaseClient.Child("users");
            FirebaseObject<User> newUser = await child.PostAsync(user, true);
        }
    }

    public enum Gender
    {
        Man = 1, Woman
    }

    public enum Status
    {
        Single = 1, Divorced, Widow
    }

    public enum ReligiousAffiliation
    {
        Religious = 1, NationalReligious, Orthodox, NationalOrthodox, Traditional
    }

    public enum Region
    {
        North = 1, Center, South
    }

    public class Admin
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "user_name")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "last_login_date")]
        public string LastLoginDate { get; set; }

        [JsonProperty(PropertyName = "is_logged_in")]
        public string IsLoggedIn { get; set; }
    }

    public class User
    {
        [JsonProperty(PropertyName = "about_me")]
        public string about_me { get; set; }

        [JsonProperty(PropertyName = "about_spouse")]
        public string about_spouse { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public string birthday { get; set; }

        [JsonProperty(PropertyName = "body_shape")]
        public string body_shape { get; set; }

        [JsonProperty(PropertyName = "characteritics")]
        public string characteritics { get; set; }

        [JsonProperty(PropertyName = "economic_status")]
        public string economic_status { get; set; }

        [JsonProperty(PropertyName = "education")]
        public string education { get; set; }

        [JsonProperty(PropertyName = "eyes_color")]
        public string eyes_color { get; set; }

        [JsonProperty(PropertyName = "facebookid")]
        public string facebookid { get; set; }

        [JsonProperty(PropertyName = "family_status")]
        public string family_status { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string first_name { get; set; }

        [JsonProperty(PropertyName = "hair")]
        public string hair { get; set; }

        [JsonProperty(PropertyName = "headdress")]
        public string headdress { get; set; }

        [JsonProperty(PropertyName = "health_status")]
        public string health_status { get; set; }

        [JsonProperty(PropertyName = "height")]
        public string height { get; set; }

        [JsonProperty(PropertyName = "hobbies")]
        public string hobbies { get; set; }

        [JsonProperty(PropertyName = "image_exposure")]
        public string image_exposure { get; set; }

        [JsonProperty(PropertyName = "images")]
        public Image[] images { get; set; }

        [JsonProperty(PropertyName = "kosher_type")]
        public string kosher_type { get; set; }

        [JsonProperty(PropertyName = "languages")]
        public string languages { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string last_name { get; set; }

        [JsonProperty(PropertyName = "location")]
        public string location { get; set; }

        [JsonProperty(PropertyName = "luck")]
        public string luck { get; set; }

        [JsonProperty(PropertyName = "military_service")]
        public string military_service { get; set; }

        [JsonProperty(PropertyName = "occupation")]
        public string occupation { get; set; }

        [JsonProperty(PropertyName = "performance")]
        public string performance { get; set; }

        [JsonProperty(PropertyName = "prayer_frequency")]
        public string prayer_frequency { get; set; }

        [JsonProperty(PropertyName = "profile_image_id")]
        public string profile_image_id { get; set; }

        [JsonProperty(PropertyName = "religious_background")]
        public string religious_background { get; set; }

        [JsonProperty(PropertyName = "religious_level")]
        public string religious_level { get; set; }

        [JsonProperty(PropertyName = "second_location")]
        public string second_location { get; set; }

        [JsonProperty(PropertyName = "smoking_habits")]
        public string smoking_habits { get; set; }

        [JsonProperty(PropertyName = "talmud_frequency")]
        public string talmud_frequency { get; set; }

        [JsonProperty(PropertyName = "age")]
        public string age { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "phone_number")]
        public string phone_number { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string region { get; set; }

        [JsonProperty(PropertyName = "religious_affiliation")]
        public string religious_affiliation { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string gender { get; set; }

        [JsonProperty(PropertyName = "spouse_characteritics")]
        public string spouse_characteritics { get; set; }

        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string id { get; internal set; }
    }

    public class Image
    {
        private string text;

        public Image(string text)
        {
            this.text = text;
        }

        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string url { get; set; }
    }
}