namespace LocalGoods.DAL.Entities
{
    public class OrderDetails: EntityBase
    {
        public decimal Price { get; set; }
        public double Discount { get; set; }
    }
}