using System;
using OpenVASP.Messaging.Messages.Entities;

namespace OpenVASP.Host.Models
{
    public class PlaceOfBirthResponseModel
    {
        public DateTime DateOfBirth { get; set; }
        
        public string CityOfBirth { get; set; }
        
        public Country CountryOfBirth { get; set; }
    }
}