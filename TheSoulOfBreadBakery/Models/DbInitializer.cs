using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            AppDbContext context = applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Breads.Any())
            {
                context.AddRange
                (
                    new Bread { Name = "Banana Bread", Price = 5.95M, ShortDescription = "A moist and delicious banana bread", LongDescription = "Moist, tender, and chock full of pure banana flavor with a gentle sweetness. Our Banana bread is made of ripe bananas, butter, sugar, egg, vanilla, baking soda, and flour.", Category = Categories["Sweet breads"], ImageUrl = "/images/sweet-breads/banana-bread.jpg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/sweet-breads/banana-bread.jpg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Panettone", Price = 7.95M, ShortDescription = "A fluffy, lighter-than-air Italian sweetbread", LongDescription = "A fluffy, lighter-than-air classic Italian sweetbread, packed with festive flavours and candied fruits.", Category = Categories["Sweet breads"], ImageUrl = "/images/sweet-breads/panettone.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/sweet-breads/panettone.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Pumpkin Bread", Price = 6.55M, ShortDescription = "Fragrant with cinnamon and chopped nuts", LongDescription = "This Pumpkin Bread is loaded with warm spices and full of delicious pumpkin flavor. Try it and it will become one of your absolute fall favorites!", Category = Categories["Sweet breads"], ImageUrl = "/images/sweet-breads/pumpkin-bread.jpg", InStock = true, IsBreadOfTheWeek = true, ImageThumbnailUrl = "/images/sweet-breads/pumpkin-bread.jpg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Wholegrain Baguette", Price = 4.85M, ShortDescription = "A long, thin loaf of French bread, made of whole grains", LongDescription = "Thin elongated loaf, made of water, wholegrain flour, yeast, salt, instantly recognizable by slits cut in top surface before baking to allow gas expansion.", Category = Categories["Wholegrain breads"], ImageUrl = "/images/wholegrain-breads/wholegrain-baguette.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/wholegrain-breads/wholegrain-baguette.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Wholemeal Bread", Price = 5.85M, ShortDescription = "A soft and fluffy homemade whole wheat bread", LongDescription = "Perfect for sandwiches, toast, and more! This loaf is magnificent; everything you want in a homemade bread. Tender on the inside. Crusty on the outside.", Category = Categories["Wholegrain breads"], ImageUrl = "/images/wholegrain-breads/wholemeal-bread.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/wholegrain-breads/wholemeal-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Multigrain Bread", Price = 5.55M, ShortDescription = "A delicious and healthy homemade multi grain bread", LongDescription = "This is an amazingly delicious homemade multigrain bread. We grind raw grains to make multigrain mix for this high quality homemade multigrain bread.", Category = Categories["Wholegrain breads"], ImageUrl = "/images/wholegrain-breads/multigrain-bread.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/wholegrain-breads/multigrain-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Baguette", Price = 3.85M, ShortDescription = "A long, thin loaf of French bread", LongDescription = "Thin elongated loaf, made of water, flour, yeast, salt, instantly recognizable by slits cut in top surface before baking to allow gas expansion.", Category = Categories["White breads"], ImageUrl = "/images/white-breads/baguette.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/white-breads/baguette.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "White Bread", Price = 3.55M, ShortDescription = "A fluffy wheat flour bread with rich flavor", LongDescription = "A delicious white bread with a delicate crumb and soft texture. A classic recipe made with the finest ingredients.", Category = Categories["White breads"], ImageUrl = "/images/white-breads/white-bread.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/white-breads/white-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Pretzel Bread", Price = 2.55M, ShortDescription = "Dense, chewy dough, beautifully browned with a salty crust", LongDescription = "Classic street-food pretzels are deep golden brown, chewy, and generously topped with coarse salt.", Category = Categories["White breads"], ImageUrl = "/images/white-breads/pretzel-bread.jpeg", InStock = true, IsBreadOfTheWeek = true, ImageThumbnailUrl = "/images/white-breads/pretzel-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Sourdough Bread", Price = 3.65M, ShortDescription = "A sourdough bread for healthy diet", LongDescription = "This chewy loaf, with its deep-brown crust, has rich, deep, flavor, and very mild tang. We love this bread for its chewiness and golden crust. Try it with ham and cheese, for a new take on that favorite sandwich.", Category = Categories["White breads"], ImageUrl = "/images/white-breads/sourdough-bread.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/white-breads/sourdough-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Wholegrain Bread", Price = 3.85M, ShortDescription = "A wholegrain sourdough bread for health and vitality", LongDescription = "This chewy loaf, with its deep-brown crust, has rich, deep, flavor, and very mild tang. We love this bread for its chewiness and golden crust. Try it with ham and cheese, for a new take on that favorite sandwich.", Category = Categories["Wholegrain breads"], ImageUrl = "/images/wholegrain-breads/wholegrain-sourdough-bread.jpeg", InStock = true, IsBreadOfTheWeek = true, ImageThumbnailUrl = "/images/wholegrain-breads/wholegrain-sourdough-bread.jpeg", AllergyInformation = "Gluten" },
                    new Bread { Name = "Fruit Bread", Price = 7.55M, ShortDescription = "A rich flavor bread for a beautiful breakfast or afternoon treat", LongDescription = "A freshly baked and fluffy sweetbread, packed with candied fruits, nuts and spices.", Category = Categories["Sweet breads"], ImageUrl = "/images/sweet-breads/fruit-bread.jpeg", InStock = true, IsBreadOfTheWeek = false, ImageThumbnailUrl = "/images/sweet-breads/fruit-bread.jpeg", AllergyInformation = "Gluten" }
                );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Sweet breads" },
                        new Category { CategoryName = "Wholegrain breads" },
                        new Category { CategoryName = "White breads" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
