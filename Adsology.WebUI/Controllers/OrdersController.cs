using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Adsology.BusinessLogic;
using Adsology.BusinessLogic.Model.OrdersXmlImportModel;
using Adsology.Common;
using Microsoft.AspNetCore.Mvc;

namespace Adsology.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController: ControllerBase
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> Import(HttpRequestMessage request)
        {
            var contentStream = await request.Content.ReadAsStreamAsync();
            await _ordersService.ImportFromXml(contentStream);
            return Ok();
        }
    }
}
