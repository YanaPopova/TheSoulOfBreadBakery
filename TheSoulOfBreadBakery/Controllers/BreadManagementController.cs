using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheSoulOfBreadBakery.Models;
using TheSoulOfBreadBakery.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheSoulOfBreadBakery.Controllers
{
    [Authorize(Roles = "Administrators")]
    [Authorize(Policy = "DeleteBread")]
    public class BreadManagementController : Controller
    {
        private readonly IBreadRepository _breadRepository;
        private readonly ICategoryRepository _categoryRepository;

        public BreadManagementController(IBreadRepository breadRepository, ICategoryRepository categoryRepository)
        {
            _breadRepository = breadRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult Index()
        {
            var breads = _breadRepository.Breads.OrderBy(p => p.BreadId);
            return View(breads);
        }

        public IActionResult AddBread()
        {
            var categories = _categoryRepository.Categories;
            var breadEditViewModel = new BreadEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                CategoryId = categories.FirstOrDefault().CategoryId
            };
            return View(breadEditViewModel);
        }

        [HttpPost]
        public IActionResult AddBread(BreadEditViewModel breadEditViewModel)
        {
            //Basic validation
            if (ModelState.IsValid)
            {
                _breadRepository.CreateBread(breadEditViewModel.Bread);
                return RedirectToAction("Index");
            }
            return View(breadEditViewModel);
        }

        public IActionResult EditBread(int breadId)
        {
            var categories = _categoryRepository.Categories;

            var bread = _breadRepository.Breads.FirstOrDefault(p => p.BreadId == breadId);

            var breadEditViewModel = new BreadEditViewModel
            {
                Categories = categories.Select(c => new SelectListItem() { Text = c.CategoryName, Value = c.CategoryId.ToString() }).ToList(),
                Bread = bread,
                CategoryId = bread.CategoryId
            };

            var item = breadEditViewModel.Categories.FirstOrDefault(c => c.Value == bread.CategoryId.ToString());
            item.Selected = true;

            return View(breadEditViewModel);
        }

        [HttpPost]
        public IActionResult EditBread(BreadEditViewModel breadEditViewModel)
        {
            breadEditViewModel.Bread.CategoryId = breadEditViewModel.CategoryId;

            if (ModelState.IsValid)
            {
                _breadRepository.UpdateBread(breadEditViewModel.Bread);
                return RedirectToAction("Index");
            }
            return View(breadEditViewModel);
        }

        [HttpPost]
        public IActionResult DeleteBread(string breadId)
        {
            return View();
        }
    }
}
