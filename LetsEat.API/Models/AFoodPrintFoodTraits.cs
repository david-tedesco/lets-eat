namespace LetsEat.API.Models
{
    public abstract class AFoodPrintFoodTraits
    {
        public Guid Id { get; set; }
        public Guid FoodPrintId { get; set; }
        public FoodPrint FoodPrint { get; set; }
        public Guid FoodTraitId { get; set; }
        public FoodTrait FoodTrait { get; set; }
    }
}