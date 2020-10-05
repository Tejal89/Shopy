using System;
using System.Collections.Generic;

namespace ShopBridgeData.Entity
{
    public partial class InventoryLog
    {
        public long InventoryLogId { get; set; }
        public long InventoryId { get; set; }
        public int OldQuantity { get; set; }
        public int NewQuantity { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
