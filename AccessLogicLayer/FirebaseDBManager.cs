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

    public class UserDBHelper
    {
        public ArrayList<KosherType> getKosherTypes()
        {
            ArrayList<KosherType> kosherTypes = new ArrayList<>();
            kosherTypes.add(new KosherType("1", "השגחה מיוחדת"));
            kosherTypes.add(new KosherType("2", "מהדרין"));
            kosherTypes.add(new KosherType("3", "רבנות"));
            kosherTypes.add(new KosherType("4", "רבנות ומהדרין"));
            return kosherTypes;
        }

        public ArrayList<MarriageStatusType> getStatusTypes()
        {
            ArrayList<MarriageStatusType> statusTypes = new ArrayList<>();
            statusTypes.add(new MarriageStatusType("1", "רווק/ה"));
            statusTypes.add(new MarriageStatusType("2", "גרוש/ה"));
            statusTypes.add(new MarriageStatusType("3", "אלמן/ה"));
            statusTypes.add(new MarriageStatusType("4", "גרוש/ה עם ילדים"));
            statusTypes.add(new MarriageStatusType("5", "אלמן/ה עם ילדים"));
            return statusTypes;
        }

        public ArrayList<ResidentialAreaPrimaryType> getResidentialAreaPrimaryTypes()
        {
            ArrayList<ResidentialAreaPrimaryType> residentialAreas = new ArrayList<>();
            residentialAreas.add(new ResidentialAreaPrimaryType("1", "ירושלים והסביבה"));
            residentialAreas.add(new ResidentialAreaPrimaryType("2", "מרכז וגוש דן"));
            residentialAreas.add(new ResidentialAreaPrimaryType("3", "צפון"));
            residentialAreas.add(new ResidentialAreaPrimaryType("4", "דרום"));
            residentialAreas.add(new ResidentialAreaPrimaryType("5", "לונדון"));
            residentialAreas.add(new ResidentialAreaPrimaryType("6", "השרון"));
            residentialAreas.add(new ResidentialAreaPrimaryType("7", "יהודה ושומרון"));
            residentialAreas.add(new ResidentialAreaPrimaryType("8", "ארה\"ב"));
            residentialAreas.add(new ResidentialAreaPrimaryType("9", "צרפת"));
            residentialAreas.add(new ResidentialAreaPrimaryType("10", "חו\"ל/אחר"));
            return residentialAreas;
        }

        public ArrayList<ResidentialAreaSecondaryType> getResidentialAreaSecondaryTypes()
        {
            ArrayList<ResidentialAreaSecondaryType> secondaryResidentialAreaTypes = new ArrayList<>();
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("1", "ירושלים והסביבה"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("2", "מרכז וגוש דן"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("3", "צפון"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("4", "דרום"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("5", "לונדון"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("6", "השרון"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("7", "יהודה ושומרון"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("8", "ארה\"ב"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("9", "צרפת"));
            secondaryResidentialAreaTypes.add(new ResidentialAreaSecondaryType("10", "חו\"ל/אחר"));
            return secondaryResidentialAreaTypes;
        }

        public ArrayList<OccupationType> getOccupationTypes()
        {
            ArrayList<OccupationType> occupationTypes = new ArrayList<>();
            occupationTypes.add(new OccupationType("1", "אדריכלות"));
            occupationTypes.add(new OccupationType("2", "אדריכלות"));
            occupationTypes.add(new OccupationType("3", "בחר/י"));
            occupationTypes.add(new OccupationType("4", "אדריכלות"));
            occupationTypes.add(new OccupationType("5", "אינטרנט/הייטק"));
            occupationTypes.add(new OccupationType("6", "אמנות/מוזיקה/יצירה"));
            occupationTypes.add(new OccupationType("7", "ביולוגיה/ביוטכנולוגיה"));
            occupationTypes.add(new OccupationType("8", "בין עבודות"));
            occupationTypes.add(new OccupationType("9", "בעל חברה"));
            occupationTypes.add(new OccupationType("10", "גרפקה/עיצוב"));
            occupationTypes.add(new OccupationType("11", "הוראה/חינוך/הדרכה"));
            occupationTypes.add(new OccupationType("12", "הנדסאי"));
            occupationTypes.add(new OccupationType("13", "חייל"));
            occupationTypes.add(new OccupationType("14", "חקלאות"));
            occupationTypes.add(new OccupationType("15", "טייס"));
            occupationTypes.add(new OccupationType("16", "טכנאי"));
            occupationTypes.add(new OccupationType("17", "טכנולוגיה/הייטק"));
            occupationTypes.add(new OccupationType("18", "ייעוץ/קאוצ'ינג"));
            occupationTypes.add(new OccupationType("19", "כלכלה/יעוץ השקעות"));
            occupationTypes.add(new OccupationType("20", "לומד/מלמד תורה"));
            occupationTypes.add(new OccupationType("21", "מהנדס"));
            occupationTypes.add(new OccupationType("22", "מכירות"));
            occupationTypes.add(new OccupationType("23", "מסעדנות ובתי קפה"));
            occupationTypes.add(new OccupationType("24", "משאבי אנוש"));
            occupationTypes.add(new OccupationType("25", "ניהול/הדרכה"));
            occupationTypes.add(new OccupationType("26", "ניהול בכיר"));
            occupationTypes.add(new OccupationType("27", "סטודנט"));
            occupationTypes.add(new OccupationType("28", "עבודה סוציאלית"));
            occupationTypes.add(new OccupationType("29", "עורך/סופר/מתרגם"));
            occupationTypes.add(new OccupationType("30", "עריכת דין"));
            occupationTypes.add(new OccupationType("31", "פוליטיקה/ארגונים שונים"));
            occupationTypes.add(new OccupationType("32", "פסיכולוגיה"));
            occupationTypes.add(new OccupationType("33", "פקידות"));
            occupationTypes.add(new OccupationType("34", "קבע/קצונה/ביטחון"));
            occupationTypes.add(new OccupationType("35", "קוסמטיקה"));
            occupationTypes.add(new OccupationType("36", "ראיית חשבון/פיננסים"));
            occupationTypes.add(new OccupationType("37", "ריפוי בעיסוק"));
            occupationTypes.add(new OccupationType("38", "רפואה"));
            occupationTypes.add(new OccupationType("39", "תחום הטיפול הרפואי"));
            occupationTypes.add(new OccupationType("40", "קלינאי תקשורת"));
            occupationTypes.add(new OccupationType("41", "תקשורת/קולנוע"));
            occupationTypes.add(new OccupationType("42", "אחר"));
            return occupationTypes;
        }

        public ArrayList<AppearanceType> getAppearanceTypes()
        {
            ArrayList<AppearanceType> appearanceTypes = new ArrayList<>();
            appearanceTypes.add(new AppearanceType("1", "מצוין"));
            appearanceTypes.add(new AppearanceType("2", "טוב מאוד"));
            appearanceTypes.add(new AppearanceType("3", "יש תמונה.."));
            appearanceTypes.add(new AppearanceType("4", "טוב"));
            appearanceTypes.add(new AppearanceType("5", "בינוני"));
            appearanceTypes.add(new AppearanceType("6", "מתחת לממוצע"));
            appearanceTypes.add(new AppearanceType("7", "לא רלבנטי"));
            return appearanceTypes;
        }

        public ArrayList<BodyShapeType> getBodyShapeTypes()
        {
            ArrayList<BodyShapeType> bodyShapeTypes = new ArrayList<>();
            bodyShapeTypes.add(new BodyShapeType("1", "ממוצע"));
            bodyShapeTypes.add(new BodyShapeType("2", "חטוב"));
            bodyShapeTypes.add(new BodyShapeType("3", "רזה"));
            bodyShapeTypes.add(new BodyShapeType("4", "רחב"));
            bodyShapeTypes.add(new BodyShapeType("5", "מלא"));
            bodyShapeTypes.add(new BodyShapeType("6", "שרירי"));
            bodyShapeTypes.add(new BodyShapeType("7", "אתלטי"));
            bodyShapeTypes.add(new BodyShapeType("8", "מרשים"));
            bodyShapeTypes.add(new BodyShapeType("9", "אצילי"));
            bodyShapeTypes.add(new BodyShapeType("10", "שמן"));
            return bodyShapeTypes;
        }

        public ArrayList<CohenType> getCohenTypes()
        {
            ArrayList<CohenType> cohenTypes = new ArrayList<>();
            cohenTypes.add(new CohenType("1", "כן"));
            cohenTypes.add(new CohenType("2", "לא"));
            return cohenTypes;
        }

        public ArrayList<EconomicStatusType> getEconomicStatusTypes()
        {
            ArrayList<EconomicStatusType> economicStatusTypes = new ArrayList<>();
            economicStatusTypes.add(new EconomicStatusType("1", "עשיר"));
            economicStatusTypes.add(new EconomicStatusType("2", "אמיד"));
            economicStatusTypes.add(new EconomicStatusType("3", "מבוסס"));
            economicStatusTypes.add(new EconomicStatusType("4", "ממוצע"));
            economicStatusTypes.add(new EconomicStatusType("5", "מתחת לממוצע"));
            economicStatusTypes.add(new EconomicStatusType("6", "לא רלבנטי"));
            return economicStatusTypes;
        }

        public ArrayList<EducationType> getEducationTypes()
        {
            ArrayList<EducationType> educationTypes = new ArrayList<>();
            educationTypes.add(new EducationType("1", "תיכונית"));
            educationTypes.add(new EducationType("2", "תעודה"));
            educationTypes.add(new EducationType("3", "תואר ראשון"));
            educationTypes.add(new EducationType("4", "תואר שני"));
            educationTypes.add(new EducationType("5", "דוקטוקרט ומעלה"));
            educationTypes.add(new EducationType("6", "תורנית"));
            educationTypes.add(new EducationType("7", "מכינה"));
            educationTypes.add(new EducationType("8", "מדרשה"));
            educationTypes.add(new EducationType("9", "ישיבת הסדר"));
            return educationTypes;
        }

        public ArrayList<EtnicityType> getEtnicityTypes()
        {
            ArrayList<EtnicityType> etnicityTypes = new ArrayList<>();
            etnicityTypes.add(new EtnicityType("1", "אשכנזי/ה"));
            etnicityTypes.add(new EtnicityType("2", "ספרדי/ה"));
            etnicityTypes.add(new EtnicityType("3", "מעורב/ת"));
            etnicityTypes.add(new EtnicityType("4", "תימני/ה"));
            etnicityTypes.add(new EtnicityType("5", "רוסי/ה"));
            etnicityTypes.add(new EtnicityType("6", "אתיופי/ת"));
            etnicityTypes.add(new EtnicityType("7", "אמריקאי/ת"));
            etnicityTypes.add(new EtnicityType("8", "לא רלוונטי"));
            return etnicityTypes;
        }

        public ArrayList<EyesColorType> getEyesColorTypes()
        {
            ArrayList<EyesColorType> eyesColorTypes = new ArrayList<>();
            eyesColorTypes.add(new EyesColorType("1", "שחור"));
            eyesColorTypes.add(new EyesColorType("2", "כחול"));
            eyesColorTypes.add(new EyesColorType("3", "ירוק"));
            eyesColorTypes.add(new EyesColorType("4", "חום"));
            eyesColorTypes.add(new EyesColorType("5", "אפור"));
            eyesColorTypes.add(new EyesColorType("6", "דבש"));

            return eyesColorTypes;
        }

        public ArrayList<FamilyReligiousType> getFamilyReligiousTypes()
        {
            ArrayList<FamilyReligiousType> familyReligiousTypes = new ArrayList<>();
            familyReligiousTypes.add(new FamilyReligiousType("1", "משפחה דתית"));
            familyReligiousTypes.add(new FamilyReligiousType("2", "מפחה חרדית"));
            familyReligiousTypes.add(new FamilyReligiousType("3", "משפחה מסורתית"));
            familyReligiousTypes.add(new FamilyReligiousType("4", "משפחה חילונית"));
            return familyReligiousTypes;
        }

        public ArrayList<HeaddressType> getHeaddressTypes()
        {
            ArrayList<HeaddressType> headdressTypes = new ArrayList<>();
            headdressTypes.add(new HeaddressType("1", "כיפה סרוגה"));
            headdressTypes.add(new HeaddressType("2", "כיפה שחורה"));
            headdressTypes.add(new HeaddressType("3", "כיפה סרוגה שחורה"));
            headdressTypes.add(new HeaddressType("4", "כיפה עור"));
            headdressTypes.add(new HeaddressType("5", "כיפה לבנה"));
            headdressTypes.add(new HeaddressType("6", "כובע"));
            headdressTypes.add(new HeaddressType("7", "ללא כיסוי ראש"));

            return headdressTypes;
        }

        public ArrayList<HealthConditionType> getHealthConditionTypes()
        {
            ArrayList<HealthConditionType> healthConditionTypes = new ArrayList<>();
            healthConditionTypes.add(new HealthConditionType("1", "תקין"));
            healthConditionTypes.add(new HealthConditionType("2", "אספר לך בהמשך"));
            return healthConditionTypes;
        }

        public ArrayList<HairType> getHairTypes()
        {
            ArrayList<HairType> hearTypes = new ArrayList<>();
            hearTypes.add(new HairType("1", "שחור"));
            hearTypes.add(new HairType("2", "חום"));
            hearTypes.add(new HairType("3", "בלונדיני"));
            hearTypes.add(new HairType("4", "אדמוני"));
            hearTypes.add(new HairType("5", "שטני"));
            hearTypes.add(new HairType("6", "ג\'ינג\'י"));
            hearTypes.add(new HairType("7", "כסוף"));
            hearTypes.add(new HairType("8", "חלק"));
            hearTypes.add(new HairType("9", "מתולתל"));
            hearTypes.add(new HairType("10", "גלי"));
            hearTypes.add(new HairType("11", "קצר"));
            hearTypes.add(new HairType("12", "ארוך"));
            hearTypes.add(new HairType("13", "בינוני"));
            hearTypes.add(new HairType("14", "קרחת"));
            return hearTypes;
        }

        public ArrayList<LanguageType> getLanguageTypes()
        {
            ArrayList<LanguageType> languageTypes = new ArrayList<>();
            languageTypes.add(new LanguageType("1", "עברית"));
            languageTypes.add(new LanguageType("2", "אנגלית"));
            languageTypes.add(new LanguageType("3", "אמהרית"));
            languageTypes.add(new LanguageType("4", "רוסית"));
            languageTypes.add(new LanguageType("5", "צרפתית"));

            return languageTypes;
        }

        public ArrayList<LuckType> getLuckTypes()
        {
            ArrayList<LuckType> luckTypes = new ArrayList<>();
            luckTypes.add(new LuckType("1", "אריה"));
            luckTypes.add(new LuckType("2", "בתולה"));
            luckTypes.add(new LuckType("3", "גדי"));
            luckTypes.add(new LuckType("4", "דגים"));
            luckTypes.add(new LuckType("5", "דלי"));
            luckTypes.add(new LuckType("6", "טלה"));
            luckTypes.add(new LuckType("7", "מאזניים"));
            luckTypes.add(new LuckType("8", "סרטן"));
            luckTypes.add(new LuckType("9", "עקרב"));
            luckTypes.add(new LuckType("10", "קשת"));
            luckTypes.add(new LuckType("11", "שור"));
            luckTypes.add(new LuckType("12", "תאומים"));
            return luckTypes;
        }

        public ArrayList<MilitaryNationalServiceType> getMilitaryNationalServiceTypes()
        {
            ArrayList<MilitaryNationalServiceType> militaryNationalServiceTypes = new ArrayList<>();
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("1", "שירות לאומי"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("2", "שירות סדיר מלא"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("3", "קרבי"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("4", "הסדר"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("5", "עתודה"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("6", "יחידה מיוחדת"));
            militaryNationalServiceTypes.add(new MilitaryNationalServiceType("7", "לא שירתתי"));
            return militaryNationalServiceTypes;
        }

        public ArrayList<PrayerFrequencyType> getPrayerFrequencyTypes()
        {
            ArrayList<PrayerFrequencyType> prayerFrequencyTypes = new ArrayList<>();
            prayerFrequencyTypes.add(new PrayerFrequencyType("1", "שלוש פעמים ביום"));
            prayerFrequencyTypes.add(new PrayerFrequencyType("2", "פעם ביום"));
            prayerFrequencyTypes.add(new PrayerFrequencyType("3", "שבת וחגים"));
            return prayerFrequencyTypes;
        }

        public ArrayList<ReligiousType> getReligiousTypes()
        {
            ArrayList<ReligiousType> religiousTypes = new ArrayList<>();
            religiousTypes.add(new ReligiousType("1", "מסורתי/ת"));
            religiousTypes.add(new ReligiousType("2", "דתי/ה לייט"));
            religiousTypes.add(new ReligiousType("3", "דתי/ה"));
            religiousTypes.add(new ReligiousType("4", "דתי/ה לאומי/ת"));
            religiousTypes.add(new ReligiousType("5", "דתי/ה לאומי/ת תורני/ת"));
            religiousTypes.add(new ReligiousType("6", "חרדי/ה"));
            religiousTypes.add(new ReligiousType("7", "חרדי/ה לאומי/ת"));
            religiousTypes.add(new ReligiousType("8", "חרדי/ה מודרני/ת"));
            religiousTypes.add(new ReligiousType("9", "ברסלב"));
            religiousTypes.add(new ReligiousType("10", "חב\"ד"));
            religiousTypes.add(new ReligiousType("11", "חוזר/ת בתשובה"));
            religiousTypes.add(new ReligiousType("12", "דתל\"ש/ית"));
            return religiousTypes;
        }

        public ArrayList<SmokingHabitType> getSmokingHabitTypes()
        {
            ArrayList<SmokingHabitType> smokingHabitTypes = new ArrayList<>();
            smokingHabitTypes.add(new SmokingHabitType("1", "לא מעשן/ת"));
            smokingHabitTypes.add(new SmokingHabitType("2", "לעיתים רחוקות"));
            smokingHabitTypes.add(new SmokingHabitType("3", "מנסה להפסיק"));
            smokingHabitTypes.add(new SmokingHabitType("4", "מעשן"));
            return smokingHabitTypes;
        }

        public ArrayList<ToraStudingType> getToraStudingTypes()
        {
            ArrayList<ToraStudingType> toraStudingTypes = new ArrayList<>();
            toraStudingTypes.add(new ToraStudingType("1", "כל יום"));
            toraStudingTypes.add(new ToraStudingType("2", "בערך פעם בשבוע"));
            toraStudingTypes.add(new ToraStudingType("3", "לעיתים רחוקות"));
            toraStudingTypes.add(new ToraStudingType("4", "לעיתים קרובות"));
            toraStudingTypes.add(new ToraStudingType("5", "כמה שעות ביום"));
            return toraStudingTypes;
        }

        public ArrayList<HobbyType> getHobbyTypes()
        {
            ArrayList<HobbyType> hobbyTypes = new ArrayList<>();
            hobbyTypes.add(new HobbyType("1", "ערב בבית"));
            hobbyTypes.add(new HobbyType("2", "קריאה/כתיבה"));
            hobbyTypes.add(new HobbyType("3", "בישול"));
            hobbyTypes.add(new HobbyType("4", "אמנות/ציור"));
            hobbyTypes.add(new HobbyType("5", "תיאטרון"));
            hobbyTypes.add(new HobbyType("6", "ומופעים"));
            hobbyTypes.add(new HobbyType("7", "מוזיקה - האזנה"));
            hobbyTypes.add(new HobbyType("8", "הרצאות תורניות"));
            hobbyTypes.add(new HobbyType("9", "קניות"));
            hobbyTypes.add(new HobbyType("10", "צמיחה אישית/רוחניות"));
            hobbyTypes.add(new HobbyType("11", "קורסים להעשרה"));
            hobbyTypes.add(new HobbyType("12", "קונצרטים ואופרה"));
            hobbyTypes.add(new HobbyType("13", "שהיה עם חברים"));
            hobbyTypes.add(new HobbyType("14", "טיולים"));
            hobbyTypes.add(new HobbyType("15", "מסיבות/ריקודים"));
            hobbyTypes.add(new HobbyType("16", "אינטרנט"));
            hobbyTypes.add(new HobbyType("17", "סרטים"));
            hobbyTypes.add(new HobbyType("18", "מוזיקה - שירה"));
            hobbyTypes.add(new HobbyType("19", "ספורט/כושר"));
            hobbyTypes.add(new HobbyType("20", "לימודים/העשרת ידע"));
            hobbyTypes.add(new HobbyType("21", "טלוויזיה"));
            hobbyTypes.add(new HobbyType("22", "פוליטיקה ואקטואליה"));

            return hobbyTypes;
        }

        public ArrayList<CharacteristicsType> getCharacteristicsTypes()
        {
            ArrayList<CharacteristicsType> characteristicsTypes = new ArrayList<>();
            characteristicsTypes.add(new CharacteristicsType("1", "חוכמה"));
            characteristicsTypes.add(new CharacteristicsType("2", "שמחת חיים"));
            characteristicsTypes.add(new CharacteristicsType("3", "זריזות"));
            characteristicsTypes.add(new CharacteristicsType("4", "פרפקציוניזם"));
            characteristicsTypes.add(new CharacteristicsType("5", "לבביות"));
            characteristicsTypes.add(new CharacteristicsType("6", "תמימות"));
            characteristicsTypes.add(new CharacteristicsType("7", "חסד"));
            characteristicsTypes.add(new CharacteristicsType("8", "כריזמטיות"));
            characteristicsTypes.add(new CharacteristicsType("9", "אמינות"));
            characteristicsTypes.add(new CharacteristicsType("10", "חייכנות"));
            characteristicsTypes.add(new CharacteristicsType("11", "חריצות"));
            characteristicsTypes.add(new CharacteristicsType("12", "משמעת עצמית"));
            characteristicsTypes.add(new CharacteristicsType("13", "עקשנות"));
            characteristicsTypes.add(new CharacteristicsType("14", "שנינות"));
            characteristicsTypes.add(new CharacteristicsType("15", "כנות"));
            characteristicsTypes.add(new CharacteristicsType("16", "אופטימיות"));
            characteristicsTypes.add(new CharacteristicsType("17", "חפרנות"));
            characteristicsTypes.add(new CharacteristicsType("18", "אומץ"));
            characteristicsTypes.add(new CharacteristicsType("19", "ותרנות"));
            characteristicsTypes.add(new CharacteristicsType("20", "נדיבות"));
            characteristicsTypes.add(new CharacteristicsType("21", "בררנות"));
            characteristicsTypes.add(new CharacteristicsType("22", "חמימות"));
            characteristicsTypes.add(new CharacteristicsType("23", "טוב לב"));
            characteristicsTypes.add(new CharacteristicsType("24", "נחישות"));

            return characteristicsTypes;
        }

        public ArrayList<PerformanceType> getPerformanceTypes()
        {
            ArrayList<PerformanceType> performanceTypes = new ArrayList<>();

            performanceTypes.add(new PerformanceType("1", "מצוין"));
            performanceTypes.add(new PerformanceType("2", "טוב מאוד"));
            performanceTypes.add(new PerformanceType("3", "יש תמונה..."));
            performanceTypes.add(new PerformanceType("4", "טוב"));
            performanceTypes.add(new PerformanceType("5", "בינוני"));
            performanceTypes.add(new PerformanceType("6", "מתחת למוצע"));
            performanceTypes.add(new PerformanceType("7", "לא רלבנטי"));

            return performanceTypes;
        }

        public ArrayList<TalmudFrequencyType> getTalmudFrequencyTypes()
        {
            ArrayList<TalmudFrequencyType> talmudFrequencyTypes = new ArrayList<>();

            talmudFrequencyTypes.add(new TalmudFrequencyType("1", "כל יום"));
            talmudFrequencyTypes.add(new TalmudFrequencyType("2", "בערך פעם בשבוע"));
            talmudFrequencyTypes.add(new TalmudFrequencyType("3", "לעיתים רחוקות"));
            talmudFrequencyTypes.add(new TalmudFrequencyType("4", "לעיתים קרובות"));
            talmudFrequencyTypes.add(new TalmudFrequencyType("5", "כמה שעות ביום"));

            return talmudFrequencyTypes;
        }

        public ArrayList<HeightType> getHeightTypes()
        {
            ArrayList<HeightType> heightTypes = new ArrayList<>();
            for (int i = 130; i <= 210; i++)
            {
                heightTypes.add(new HeightType(String.valueOf(i), i + " ס\"מ"));
            }

            return heightTypes;
        }

        public String getValueByCode(ArrayList<? extends SpinnerData> items, String code)
        {
            for (SpinnerData item : items)
            {
                if (item.getId().equals(code))
                {
                    return item.getName();
                }
            }
            return null;
        }
    }
}