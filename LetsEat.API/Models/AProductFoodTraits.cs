namespace LetsEat.API.Models
{
    public abstract class AProductFoodTraits
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid FoodTraitId { get; set; }
        public FoodTrait FoodTrait { get; set; }
    }
}