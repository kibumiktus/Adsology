using System.Collections.Generic;
using System.Xml.Serialization;
using Adsology.Common.Mapping;

namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("orders")]
    public class OrdersCollections : IMapTo<Dal.Models.Orders[]>
    {
        [XmlElement("order")]
        public Order[] Items { get; set; }

    }
}
