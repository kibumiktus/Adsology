using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Adsology.BusinessLogic.Model.OrdersXmlImportModel;
using Adsology.Common;
using Adsology.Common.Mapping;
using Adsology.Dal.Models;
using Adsology.Test.Common;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using BillingAddresses = Adsology.Dal.Models.BillingAddresses;

namespace Adsology.Test
{
    public class MappingTest
    {
        private IMapper _mapper;
        public MappingTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            var serviceProvider = services.BuildServiceProvider();
            _mapper = serviceProvider.GetService<IMapper>();
        }

        [Fact]
        public void OrdersCollectionMappingTest()
        {
            var source = GetOrders();
            var destination = _mapper.Map<Orders[]>(source.Items);
            Assert.NotEmpty(destination);
        }

        [Fact]
        public void OrdersMappingTest()
        {
            var source = GetOrders();
            var destination = _mapper.Map<Orders[]>(source.Items);
            var order = destination.First();
            Assert.NotNull(order.Articles);
            Assert.NotNull(order.Payments);
            Assert.NotNull(order.BillingAddresses);
            Assert.NotNull(order.OrderStatusNavigation);
            
            Assert.Equal(70002223,order.OxId);
            Assert.Equal(new DateTime(2018, 12, 14, 15, 48, 11), order.OrderDatetime);
        }

        [Fact]
        public void BillingAddressesMappingTest()
        {
            var source = GetOrders();
            var destination = _mapper.Map<Orders[]>(source.Items);
            var billingAddresses = destination.First().BillingAddresses;

            Assert.Equal("wittmann.k@web.de", billingAddresses.Email);
            Assert.Equal("Krissi Wittmann", billingAddresses.Fullname);
            Assert.Equal("Allerstrasse", billingAddresses.Street);
            Assert.Equal(47, billingAddresses.HomeNumber);
            Assert.Equal("Berlin", billingAddresses.City);
            Assert.Equal("DE", billingAddresses.Country);
            Assert.Equal(12049, billingAddresses.Zip);
        }

        [Fact]
        public void PaymentsMappingTest()
        {
            var source = GetOrders();
            var destination = _mapper.Map<Orders[]>(source.Items);
            var payments = destination.First().Payments;
            Assert.NotEmpty(payments);
            var paymentItem = payments.First();
            Assert.Equal(130.5m, paymentItem.Amount);
            Assert.Equal("INVOICE", paymentItem.MethodName);
        }

        [Fact]
        public void ArticlesMappingTest()
        {
            var source = GetOrders();
            var destination = _mapper.Map<Orders[]>(source.Items);
            var articles = destination.First().Articles;
            Assert.NotEmpty(articles);
            var articleItem = articles.First();
            Assert.Equal(00471500075l, articleItem.Nomenclature);
            Assert.Equal("Track Suit Women", articleItem.Title);
            Assert.Equal(1, articleItem.Amount);
            Assert.Equal(60d, articleItem.BrutPrice);
        }


        private OrdersCollections GetOrders()
        {
            using (var stream = File.OpenRead(Constants.OderXmlSourcePath))
            {
                return XmlStreamSerializer.Deserialize<OrdersCollections>(stream);
            }
        }
    }
}
