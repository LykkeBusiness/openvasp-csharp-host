using Newtonsoft.Json;
using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class PostalAddressResponseModel
    {
        public string StreetName { get; set; }
        
        public string BuildingNumber { get; set; }
        
        public string AddressLine { get; set; }
        
        public string PostCode { get; set; }
        
        public string TownName { get; set; }
        
        public Country Country { get; set; }
    }
}