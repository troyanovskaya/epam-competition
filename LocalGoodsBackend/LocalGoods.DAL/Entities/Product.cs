namespace LocalGoods.DAL.Entities
{
    public class Product: AuditEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Poster { get; set; }
        public double Discount { get; set; }
    }
}