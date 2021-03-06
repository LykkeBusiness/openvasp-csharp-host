using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class JuridicalPersonIdModel
    {
        public string Id { set; get; }

        [JsonConverter(typeof(StringEnumConverter))]
        public JuridicalIdentificationType Type { set; get; }

        public string CountryIso2Code { set; get; }

        public string NonStateIssuer { set; get; }
    }
}