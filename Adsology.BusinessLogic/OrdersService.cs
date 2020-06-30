using Adsology.Common;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Adsology.BusinessLogic.Model.OrdersXmlImportModel;
using Adsology.Dal;
using Adsology.Dal.Models;
using AutoMapper;

namespace Adsology.BusinessLogic
{
    public class OrdersService
    {
        private readonly IMapper _mapper;
        private readonly IAdsologyDbContext _dbContext;

        public OrdersService(IMapper mapper, IAdsologyDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task ImportFromXml(Stream stream)
        {
            var deserializeData = XmlStreamSerializer.Deserialize<OrdersCollections>(stream);
            var dalOrders = _mapper.Map<Orders[]>(deserializeData.Items);
            await _dbContext.Orders.AddRangeAsync(dalOrders);
            await _dbContext.SaveChangesAsync();
        }
    }
}
