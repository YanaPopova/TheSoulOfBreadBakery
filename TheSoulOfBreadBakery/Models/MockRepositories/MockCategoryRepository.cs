using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models.MockRepositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category{CategoryId = 1, CategoryName = "Fruit bread", Description = "Bread with fruits"},
                    new Category{CategoryId = 2, CategoryName = "Rye bread", Description = "Healthy bread"},
                    new Category{CategoryId = 3, CategoryName = "Seasonal bread", Description = "Bread with seasoning"}
                };
            }
        }
    }
}
