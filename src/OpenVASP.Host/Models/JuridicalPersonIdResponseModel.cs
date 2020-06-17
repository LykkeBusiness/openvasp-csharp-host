using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class JuridicalPersonIdResponseModel
    {
        public JuridicalIdentificationType IdentificationType { get; set; }
        
        public string Identifier { get; set; }
        
        public Country IssuingCountry { get; set; }
        
        public string NonStateIssuer { get; set; }
    }
}