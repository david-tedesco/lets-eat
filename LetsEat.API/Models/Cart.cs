namespace LetsEat.API.Models
{
    public enum CartStatus
    {
        OPEN,
        CLOSED
    }

    public class Cart
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public ICollection<CartProducts> Items { get; set; }
        public CartStatus CartStatus { get; set; }
    }
}