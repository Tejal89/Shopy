using System;
using System.Collections.Generic;

namespace ShopBridgeData.Entity
{
    public class ProductInventory
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public bool? IsActive { get; set; }
        public long InventoryId { get; set; }
        public int? InventoryQuantity { get; set; }
    }

    public class Prod : Product
    {
        public int? InventoryQuantity { get; set; }
    }
}
