using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShopBridgeData.Entity;
using ShopBridgeServices;
using ShopBridgeServices.Interfaces;

namespace ShopBridge.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger, IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Description : To get all inventories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllInventories")]
        public async Task<IActionResult> GetAllInventories()
        {
            var response = await _inventoryService.GetAllInventoriesAsync();

            switch (response)
            {
                case null:
                    return StatusCode(500);
                default:
                    return Ok(response.ToList());
            }
        }

        /// <summary>
        /// Description : To get a inventory by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetInventoryById/{id}")]
        public async Task<IActionResult> GetInventoryById(long id)
        {
            var response = await _inventoryService.GetInventoryByIdAsync(id);

            switch (response)
            {
                case null:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To create a new inventory
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("CreateInventory")]
        public async Task<IActionResult> CreateInventory(Inventory inventory)
        {
            if (inventory == null || inventory.InventoryId != 0)
                return BadRequest();

            inventory.CreatedBy = 1;
            inventory.CreatedDate = DateTime.UtcNow;

            var response = await _inventoryService.CreateInventory(inventory);

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To update a inventory
        /// </summary>
        /// <param name="inventory"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("UpdateInventory")]
        public async Task<IActionResult> UpdateInventory(Inventory inventory)
        {
            if (inventory == null || inventory.InventoryId <= 0)
                return BadRequest();

            var inventories = await _inventoryService.GetAllInventoriesAsync();
            if (inventories != null && inventories.ToList().Any(x => x.InventoryId != inventory.InventoryId && x.ProductId != inventory.ProductId))
            {
                return Conflict();
            }

            if (inventories != null && !inventories.ToList().Any(x => x.InventoryId == inventory.InventoryId))
            {
                return NotFound();
            }

            inventory.UpdatedBy = 1;
            inventory.UpdatedDate = DateTime.UtcNow;

            var response = await _inventoryService.UpdateInventory(inventory);

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }

        /// <summary>
        /// Description : To delete an inventory
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteInventory/{id}")]
        public async Task<IActionResult> DeleteInventory(long id)
        {
            if (id <= 0)
                return BadRequest();

            var users = await _inventoryService.GetAllInventoriesAsync();
            if (users != null || !users.ToList().Any(x => x.InventoryId != id))
            {
                return BadRequest();
            }

            var response = await _inventoryService.DeleteInventory(users.ToList().FirstOrDefault(x => x.InventoryId == id));

            switch (response)
            {
                case false:
                    return StatusCode(500);
                default:
                    return Ok(response);
            }
        }
    }
}
