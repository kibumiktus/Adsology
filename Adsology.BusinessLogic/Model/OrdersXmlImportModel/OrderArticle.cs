using System.Xml.Serialization;
using Adsology.Common.Mapping;
using DalModels = Adsology.Dal.Models;

namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("orderarticle")]
    public class OrderArticle : IMapTo<Dal.Models.Articles>
    {
        [XmlElement("artnum")]
        public long Nomenclature { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("amount")]
        public int Amount { get; set; }
        [XmlElement("brutprice")]
        public double BrutPrice { get; set; }
    }
}