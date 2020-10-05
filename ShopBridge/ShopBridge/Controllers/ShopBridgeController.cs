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
    [Route("[controller]")]
    public class ShopBridgeController : ControllerBase
    {
        private readonly ILogger<ShopBridgeController> _logger;
        
        public ShopBridgeController(ILogger<ShopBridgeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Content("ShopBridge Api Started...");
        }
    }
}
