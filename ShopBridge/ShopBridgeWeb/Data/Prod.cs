using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopBridgeWeb.Data
{
    [Serializable]
    public partial class Prod
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductImage { get; set; }
        public string ProductImageBytes { get; set; }
        public bool? IsActive { get; set; }
        public long InventoryId { get; set; }
        public int InventoryQuantity { get; set; }
    }
}
