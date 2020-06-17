using Newtonsoft.Json;
using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class VaspInformationModel
    {
        public string Name { get; set; }
        
        public string VaspIdentity { get; set; }
        
        public string VaspPublickKey { get; set; }
        
        public PostalAddressResponseModel PostalAddress { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PlaceOfBirthResponseModel PlaceOfBirth { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public NaturalPersonIdResponseModel[] NaturalPersonIds { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public JuridicalPersonIdResponseModel[] JuridicalPersonIds { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string BIC { get; set; }
    }
}