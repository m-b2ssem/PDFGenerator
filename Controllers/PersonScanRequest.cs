using System;
using Newtonsoft.Json;

namespace generatePDF.Controllers
{
    public class PersonScanRequest
    {

        [JsonProperty("name")]
        public string name { get; set; } //originalname

        [JsonProperty("firstName")]
        public string firstName { get; set; }

        [JsonProperty("middleName")]
        public string middleName { get; set; }

        [JsonProperty("lastName")]
        public string lastName { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("dob")]
        public string dob { get; set; }

        [JsonProperty("country")]
        public string country { get; set; }

        [JsonProperty("matchRate")]
        public int matchRate { get; set; }

        [JsonProperty("maxResultCount")]
        public int maxResultCount { get; set; }
        
    }
}
