using LetsEat.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LetsEat.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProducts> CartProducts { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<FeedbackFoodTraitsLikedTraits> FeedbackFoodTraitLikedTraits { get; set; }
        public DbSet<FeedbackFoodTraitsDislikedTraits> FeedbackFoodTraitDislikedTraits { get; set; }
        public DbSet<FoodPrint> FoodPrint { get; set; }
        public DbSet<FoodPrintFoodTraitsLikes> FoodPrintFoodTraitLikes { get; set; }
        public DbSet<FoodPrintFoodTraitsDislikes> FoodPrintFoodTraitDislikes { get; set; }
        public DbSet<FoodPrintFoodTraitsAllergies> FoodPrintFoodTraitAllergies { get; set; }
        public DbSet<FoodTrait> FoodTraits { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFoodTraitsIngredients> ProductFoodTraitsIngredients { get; set; }
        public DbSet<ProductFoodTraitsNutritionalInfos> ProductFoodTraitsNutritionalInfos { get; set; }
        public DbSet<ProductFoodTraitsTags> ProductFoodTraitsTags { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasKey(p => new { p.UserId, p.RoleId });
            base.OnModelCreating(builder);
        }
    }
}