using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheSoulOfBreadBakery.Models
{
    public class MockBreadRepository : IBreadRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Bread> Breads
        {
            get
            {
                return new List<Bread>
                {
                    new Bread {BreadId = 1, Name = "Anadama bread", Price = 2.55M, ShortDescription = "Yeast bread", LongDescription = "A sweet, cornmeal and molasses based bread.", Category = _categoryRepository.Categories.ToList()[0], InStock = true, IsBreadOfTheWeek = false},
                    new Bread {BreadId = 2, Name = "Baguette", Price = 1.55M, ShortDescription = "French bread", LongDescription = "Thin elongated loaf, made of water, flour, yeast, salt, instantly recognizable by slits cut in top surface before baking to allow gas expansion.", Category = _categoryRepository.Categories.ToList()[1], InStock = true, IsBreadOfTheWeek = false},
                    new Bread {BreadId = 3, Name = "Banana bread", Price = 3.55M, ShortDescription = "Sweet bread", LongDescription = "Dense, made with mashed bananas, often a moist, sweet, cake-like quick bread, but some recipes are traditional yeast breads.", Category = _categoryRepository.Categories.ToList()[0], InStock = true, IsBreadOfTheWeek = false},
                    new Bread {BreadId = 4, Name = "Panettone", Price = 9.55M, ShortDescription = "Sweet bread", LongDescription = "Fluffy, base round, octagon or star section, takes days to make to cure acidic dough like sourdough, contains candied citrus, raisins, sliced vertically, served with cider or champagne, esp. for Christmas, New Year.", Category = _categoryRepository.Categories.ToList()[2], InStock = true, IsBreadOfTheWeek = false}
                };
            }
        }

        public IEnumerable<Bread> BreadsOfTheWeek { get; }

        public Bread GetBreadById(int breadId)
        {
            throw new NotImplementedException();
        }
    }
}
