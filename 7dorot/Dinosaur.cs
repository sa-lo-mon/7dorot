using Newtonsoft.Json;

namespace ShevaDorot
{
    public class Dinosaur
    { 
        [JsonProperty(PropertyName = "height")]
        public double Height { get; set; }
    }
}