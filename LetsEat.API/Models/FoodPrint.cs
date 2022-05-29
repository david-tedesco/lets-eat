namespace LetsEat.API.Models
{
    public class FoodPrint
    {
        public FoodPrint()
        {
            Likes = new List<FoodPrintFoodTraitsLikes>();
            Dislikes = new List<FoodPrintFoodTraitsDislikes>();
            Allergies = new List<FoodPrintFoodTraitsAllergies>();
        }

        public FoodPrint(User user, IEnumerable<FoodTrait> likes, IEnumerable<FoodTrait> dislikes, IEnumerable<FoodTrait> allergies, float budget)
        {
            User = user;
            Likes = new List<FoodPrintFoodTraitsLikes>();
            Dislikes = new List<FoodPrintFoodTraitsDislikes>();
            Allergies = new List<FoodPrintFoodTraitsAllergies>();

            Likes = likes.Select(ft => new FoodPrintFoodTraitsLikes { FoodTrait = ft, FoodPrint = this } ).ToList();
            Dislikes = dislikes.Select(ft => new FoodPrintFoodTraitsDislikes { FoodTrait = ft, FoodPrint = this } ).ToList();
            Allergies = allergies.Select(ft => new FoodPrintFoodTraitsAllergies { FoodTrait = ft, FoodPrint = this } ).ToList();
            Budget = budget;
        }
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public ICollection<FoodPrintFoodTraitsLikes> Likes { get; set; }
        public ICollection<FoodPrintFoodTraitsDislikes> Dislikes { get; set; }
        public ICollection<FoodPrintFoodTraitsAllergies> Allergies { get; set; }
        public float Budget { get; set; }
    }
}