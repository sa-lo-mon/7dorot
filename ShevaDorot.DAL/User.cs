using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShevaDorot.DAL
{
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
        public string id { get; set; }
    }
}
