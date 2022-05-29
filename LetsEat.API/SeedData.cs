using IdentityModel;
using LetsEat.API.Data;
using LetsEat.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Security.Claims;

namespace LetsEat.API
{
    public class SeedData
    {
        public static void Build(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();
                context.Database.EnsureCreated();
            }
        }

        public static void Populate(WebApplication app)
        {
            Build(app);
            ensureSeedData(app);
        }

        public static void Reset(WebApplication app)
        {
            Drop(app);
            Populate(app);
        }

        public static void Drop(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.EnsureDeleted();
            }
        }

        private static void seedBusinessData(ApplicationDbContext context, User[] users)
        {
            var businessData = new
            {
                foodTraits = new List<FoodTrait>
                {
                    new FoodTrait(FoodTraitType.INGREDIENT, "Brocoli"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Chocolat"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Vanille"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Lait"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Fromage"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Fenouil"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Poivre"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Sucre"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Oeuf"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Pomme"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Pomme de terre"),
                    new FoodTrait(FoodTraitType.INGREDIENT, "Escalope de poulet"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Gluten"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Arachides"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Crustacés"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Poisson"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Oeufs"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Lupin"),
                    new FoodTrait(FoodTraitType.ALLERGEN, "Mollusques"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Italie"),
                    new FoodTrait(FoodTraitType.COUNTRY, "France"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Pays-Bas"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Belgique"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Allemagne"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Espagne"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Portugal"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Etats-Unis"),
                    new FoodTrait(FoodTraitType.COUNTRY, "Canada"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Pizza"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Pâtisserie"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Pâtes"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Quiche"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Plat en sauce"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Salade"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Sandwich"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Soupe"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Tartare"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Tarte"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Tartiflette"),
                    new FoodTrait(FoodTraitType.MEALCATEGORY, "Tortilla")
                }
            };

            context.Database.EnsureCreated();
            context.SaveChanges();
            context.AddRange(businessData.foodTraits);
            context.SaveChanges();

            var foodTraits = context.FoodTraits;

            var aliceLikedFoodTraits = foodTraits.Where(
                    ft => ft.Type == FoodTraitType.INGREDIENT
                    || ft.Type == FoodTraitType.MEALCATEGORY
                    || ft.Type == FoodTraitType.COUNTRY).Take(5);

            var aliceDislikedFoodTraits = foodTraits
                .Except(aliceLikedFoodTraits)
                .Where(
                    ft => ft.Type == FoodTraitType.INGREDIENT
                    || ft.Type == FoodTraitType.MEALCATEGORY
                    || ft.Type == FoodTraitType.COUNTRY).Take(5);

            var aliceAllergies = foodTraits.
                Where(ft => ft.Type == FoodTraitType.ALLERGEN)
                .Take(2);

            var bobLikedFoodTraits = foodTraits.Where(
                    ft => ft.Type == FoodTraitType.INGREDIENT
                    || ft.Type == FoodTraitType.MEALCATEGORY
                    || ft.Type == FoodTraitType.COUNTRY).Take(5);
            
            var bobDislikedFoodTraits = foodTraits
                .Except(bobLikedFoodTraits)
                .Where(
                    ft => ft.Type == FoodTraitType.INGREDIENT
                    || ft.Type == FoodTraitType.MEALCATEGORY
                    || ft.Type == FoodTraitType.COUNTRY).Take(5);
            
            var bobAllergies = foodTraits.
                Where(ft => ft.Type == FoodTraitType.ALLERGEN)
                .Take(2);

            var aliceFoodPrint = new FoodPrint(
                    users[0],
                    aliceLikedFoodTraits,
                    aliceDislikedFoodTraits,
                    aliceAllergies,
                    (float) 18.5
                );

            var bobFoodPrint = new FoodPrint(
                    users[1],
                    bobLikedFoodTraits,
                    bobDislikedFoodTraits,
                    bobAllergies,
                    (float) 15
                );

            context.AddRange(aliceFoodPrint, bobFoodPrint);
            context.SaveChanges();
        }

        private static void ensureSeedData(WebApplication app)
        {
            using (var scope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();

                var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var alice = userMgr.FindByNameAsync("alicesmith@email.com").Result;
                if (alice == null)
                {
                    alice = new User
                    {
                        UserName = "alicesmith@email.com",
                        Email = "alicesmith@email.com",
                        EmailConfirmed = true,
                    };
                    var result = userMgr.CreateAsync(alice, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Alice Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Alice"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("alice created");
                }
                else
                {
                    Log.Debug("alice already exists");
                }

                var bob = userMgr.FindByNameAsync("bobsmith@email.com").Result;
                if (bob == null)
                {
                    bob = new User
                    {
                        UserName = "bobsmith@email.com",
                        Email = "bobsmith@email.com",
                        EmailConfirmed = true
                    };
                    var result = userMgr.CreateAsync(bob, "Pass123$").Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }

                    result = userMgr.AddClaimsAsync(bob, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Bob Smith"),
                            new Claim(JwtClaimTypes.GivenName, "Bob"),
                            new Claim(JwtClaimTypes.FamilyName, "Smith"),
                            new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                            new Claim("location", "somewhere")
                        }).Result;
                    if (!result.Succeeded)
                    {
                        throw new Exception(result.Errors.First().Description);
                    }
                    Log.Debug("bob created");
                }
                else
                {
                    Log.Debug("bob already exists");
                }
                seedBusinessData(context, new [] { alice, bob });
            }
        }
    }
}