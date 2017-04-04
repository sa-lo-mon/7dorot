using Firebase.Auth;
using Firebase.Database;
using Firebase.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace ShevaDorot.DAL
{
    public class DBManager
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

        public DBManager()
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

        public async void DeleteUserPhoto(User user)
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

        public async Task<string> InsertUserNewPhoto(User user, string file)
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

        public async void UpdateUser(User selectedUser)
        {
            await FirebaseClient.Child("users/" + selectedUser.id).PutAsync(selectedUser);
        }

        public async void InsertUser(User user)
        {
            var child = FirebaseClient.Child("users");
            FirebaseObject<User> newUser = await child.PostAsync(user, true);
        }
    }
}