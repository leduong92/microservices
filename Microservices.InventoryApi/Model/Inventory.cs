namespace Microservices.InventoryApi.Model
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int RegionId { get; set; }
        public int StockQuantity { get; set; }
        public int ReservedQuantity { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
