using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Application
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("personalInformation")]
        public PersonalInformation PersonalInformation { get; set; }

        [JsonProperty("additionalQuestions")]
        public AdditionalQuestion AdditionalQuestion { get; set; }
    }
}
