using System.Xml.Serialization;

namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("country")]
    public class Country
    {
        [XmlElement("geo")]
        public string Geo { get; set; }
    }
}