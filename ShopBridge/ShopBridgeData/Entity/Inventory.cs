using System;
using System.Collections.Generic;

namespace ShopBridgeData.Entity
{
    public partial class Inventory
    {
        public long InventoryId { get; set; }
        public int InventoryQuantity { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
