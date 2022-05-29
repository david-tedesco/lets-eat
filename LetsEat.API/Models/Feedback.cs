namespace LetsEat.API.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }
        public Order Order { get; set; }
        public ICollection<FeedbackFoodTraitsLikedTraits> LikedTraits { get; set; }
        public ICollection<FeedbackFoodTraitsDislikedTraits> DislikedTraits { get; set; }
        public int Rating { get; set; }


    }
}