using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridgeServices;
using ShopBridgeServices.Interfaces;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryLogController : ControllerBase
    {
        private readonly ILogger<InventoryLogController> _logger;
        
        public InventoryLogController(ILogger<InventoryLogController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content("Yet not implemented...Work in progress...");
        }
    }
}
