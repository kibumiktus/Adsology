using System.Collections.Generic;
using System.Xml.Serialization;
using Adsology.Common.Mapping;
using Adsology.Dal.Models;
using AutoMapper;


namespace Adsology.BusinessLogic.Model.OrdersXmlImportModel
{
    [XmlRoot("order")]
    public class Order : IMapTo<Dal.Models.Orders>
    {
        [XmlElement("oxid")]
        public string OxId { get; set; }
        [XmlElement("orderdate")]
        public string OrderDate { get; set; }
        [XmlElement("billingaddress")]
        public BillingAddresses BillingAddress { get; set; }
        
        [XmlArray("payments")]
        [XmlArrayItem("payment")]
        public List<Payment> Payments { get; set; }
        
        [XmlArray("articles")]
        [XmlArrayItem("orderarticle")]
        public List<OrderArticle> Articles { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, Dal.Models.Orders>()
                .ForMember(dest=>dest.BillingAddresses, src=>src.MapFrom(o=>o.BillingAddress))
                .ForMember(dest=>dest.OrderDatetime, src=>src.MapFrom(order=>order.OrderDate));
        }
    }
}