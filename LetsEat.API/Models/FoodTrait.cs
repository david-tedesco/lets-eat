namespace LetsEat.API.Models
{
    public enum FoodTraitType
    {
        INGREDIENT,
        ALLERGEN,
        COUNTRY,
        MEALCATEGORY,
        NUTRITIONALINFO,
        TAG
    }
    public class FoodTrait
    {
        public FoodTrait()
        {
            Likes = new List<FoodPrintFoodTraitsLikes>();
            Dislikes = new List<FoodPrintFoodTraitsDislikes>();
            Allergies = new List<FoodPrintFoodTraitsAllergies>();
        }

        public FoodTrait(FoodTraitType type, string value)
        {
            Type = type;
            Value = value;
            Likes = new List<FoodPrintFoodTraitsLikes>();
            Dislikes = new List<FoodPrintFoodTraitsDislikes>();
            Allergies = new List<FoodPrintFoodTraitsAllergies>();
        }

        public Guid Id { get; set; }
        public FoodTraitType Type { get; set; }
        public string Value { get; set; }
        public ICollection<FoodPrintFoodTraitsLikes> Likes { get; set; }
        public ICollection<FoodPrintFoodTraitsDislikes> Dislikes { get; set; }
        public ICollection<FoodPrintFoodTraitsAllergies> Allergies { get; set; }
    }
}