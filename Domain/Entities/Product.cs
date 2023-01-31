namespace Domain.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; private set; }
    }
}
