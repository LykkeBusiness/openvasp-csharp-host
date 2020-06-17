using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class NaturalPersonIdResponseModel
    {
        public NaturalIdentificationType IdentificationType { get; private set; }
        
        public string Identifier { get; private set; }
        
        public Country IssuingCountry { get; private set; }
        
        public string NonStateIssuer { get; private set; }
    }
}