using System.Xml.Serialization;
using Adsology.Common.Mapping;
using AutoMapper;


namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("billingaddress")]
    public class BillingAddresses : IMapTo<Dal.Models.BillingAddresses>
    {
        [XmlElement("billemail")]
        public string Email { get; set; }
        [XmlElement("billfname")]
        public string Fullname { get; set; }
        [XmlElement("billstreet")]
        public string Street { get; set; }
        [XmlElement("billstreetnr")]
        public string HomeNumber { get; set; }
        [XmlElement("billcity")]
        public string City { get; set; }
        [XmlElement("country")]
        public Country BillCountry { get; set; }

        public string Country => BillCountry.Geo;
        [XmlElement("billzip")]
        public string Zip { get; set; }
    }
}