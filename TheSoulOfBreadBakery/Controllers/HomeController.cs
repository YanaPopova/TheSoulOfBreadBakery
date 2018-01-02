using Microsoft.AspNetCore.Mvc;
using TheSoulOfBreadBakery.Models;
using TheSoulOfBreadBakery.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheSoulOfBreadBakery.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBreadRepository _breadRepository;

        public HomeController(IBreadRepository breadRepository)
        {
            _breadRepository = breadRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                BreadsOfTheWeek = _breadRepository.BreadsOfTheWeek
            };

            return View(homeViewModel);
        }
    }
}
