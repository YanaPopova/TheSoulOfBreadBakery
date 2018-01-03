using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TheSoulOfBreadBakery.Models;
using TheSoulOfBreadBakery.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheSoulOfBreadBakery.Controllers
{
    public class BreadController : Controller
    {
        private readonly IBreadRepository _breadRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BreadController(IBreadRepository breadRepository, ICategoryRepository categoryRepository)
        {
            _breadRepository = breadRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List(string category)
        {
            IEnumerable<Bread> breads;
            string currentCategory = string.Empty;

            if (string.IsNullOrEmpty(category))
            {
                breads = _breadRepository.Breads.OrderBy(b => b.BreadId);
                currentCategory = "All products";
            }
            else
            {
                breads = _breadRepository.Breads.Where(b => b.Category.CategoryName == category).OrderBy(b => b.BreadId);
                currentCategory = _categoryRepository.Categories.FirstOrDefault(c => c.CategoryName == category).CategoryName;
            }

            return View(new BreadListViewModel
            {
                Breads = breads,
                CurrentCategory = currentCategory
            });
        }

        public IActionResult Details(int id)
        {
            var bread = _breadRepository.GetBreadById(id);
            if (bread == null)
                return NotFound();

            return View(bread);
        }
    }
}