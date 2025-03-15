namespace Shop.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string SKU { get; set; }
        public decimal Price { get; set; }
        public ICollection<PurchaseItem> PurchaseItems { get; set; }
    }
}
