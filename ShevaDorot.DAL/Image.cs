using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShevaDorot.DAL
{
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
