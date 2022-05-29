namespace LetsEat.API.Models
{
    public abstract class AFeedbackFoodTraits
    {
        public Guid Id { get; set; }
        public Guid FeedbackId { get; set; }
        public Feedback Feedback { get; set; }
        public Guid FoodTraitId { get; set; }
        public FoodTrait FoodTrait { get; set; }
    }
}