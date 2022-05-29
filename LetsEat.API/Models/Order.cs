namespace LetsEat.API.Models
{
    public enum OrderStatus
    {
        PENDING,
        CONFIRMED,
        CANCELLED
    }
    public class Order
    {
        public Guid Id { get; set; }
        public User User { get; set; }
        public string FrichtEmail { get; set; }
        public string FrichtiOrderId { get; set; }
        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<Feedback> Feedbacks {get;set;}
    }
}