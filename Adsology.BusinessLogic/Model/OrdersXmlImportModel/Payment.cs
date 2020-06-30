using System.Xml.Serialization;
using Adsology.Common.Mapping;

namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("payment")]
    public class Payment: IMapTo<Dal.Models.Payments>
    {
        [XmlElement("method-name")]
        public string MethodName { get; set; }

        [XmlElement("amount")]
        public decimal Amount { get; set; }
    }
}