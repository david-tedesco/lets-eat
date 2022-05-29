namespace LetsEat.API.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string FrichtiProductId { get; set; }
        public float GrossWeight { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Image { get; set; }
        public ICollection<ProductFoodTraitsIngredients> Ingredients { get; set; }
        public ICollection<ProductFoodTraitsNutritionalInfos> NutritionalInfos { get; set; }
        public ICollection<ProductFoodTraitsTags> Tags { get; set; }
    }
}