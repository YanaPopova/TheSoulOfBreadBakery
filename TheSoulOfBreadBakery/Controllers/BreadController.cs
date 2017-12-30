using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public ViewResult List()
        {
            BreadListViewModel breadListViewModel = new BreadListViewModel();
            breadListViewModel.Breads = _breadRepository.Breads;

            breadListViewModel.CurrentCategory = "Fruit bread";
            return View(breadListViewModel);
        }
    }
}
