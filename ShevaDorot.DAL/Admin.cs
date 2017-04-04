using Newtonsoft.Json;

namespace ShevaDorot.DAL
{
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
}
