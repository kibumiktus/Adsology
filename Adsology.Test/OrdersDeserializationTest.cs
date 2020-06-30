using Adsology.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Adsology.BusinessLogic.Model.OrdersXmlImportModel;
using Adsology.Dal.Models;
using Adsology.Test.Common;
using Xunit;

namespace Adsology.Test
{
    public class OrdersDeserializationTest
    {
        [Fact]
        public void DeserializationTest()
        {
            OrdersCollections orders;
            using (var stream = File.OpenRead(Constants.OderXmlSourcePath))
            {
                orders = XmlStreamSerializer.Deserialize<OrdersCollections>(stream);
            }
            Assert.NotEmpty(orders.Items);
            Assert.NotEmpty(orders.Items.First().Articles);
            Assert.NotEmpty(orders.Items.First().Payments);
        }
    }
}
