﻿using System.ComponentModel.DataAnnotations;

namespace WillsIMS.Models
{
    public class InventoryItem
    {
        public string InventoryItemTableName = "InventoryItem";
        [Key]
        public int InventoryItemId { get; set; }
        public int ProductId { get; set; }
        public int CurrentStockQuantity { get; set; }
        public int MinStockThreshold { get; set; }
        public int ReorderPoint { get; set; }
        public List<string> BinLocations { get; set; } = new List<string>();
    }
}