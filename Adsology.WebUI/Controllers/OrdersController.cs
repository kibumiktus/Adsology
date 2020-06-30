using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Adsology.BusinessLogic;
using Adsology.BusinessLogic.Model.OrdersXmlImportModel;
using Adsology.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Adsology.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersService _ordersService;

        public OrdersController(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost]
        public async Task<IActionResult> Import(IFormFile file)
        {
            await _ordersService.ImportFromXml(file.OpenReadStream());
            return Ok();
        }
    }
}
