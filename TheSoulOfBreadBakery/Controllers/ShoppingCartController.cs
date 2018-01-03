using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TheSoulOfBreadBakery.Models;
using TheSoulOfBreadBakery.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheSoulOfBreadBakery.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBreadRepository _breadRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IBreadRepository breadRepository, ShoppingCart shoppingCart)
        {
            _breadRepository = breadRepository;
            _shoppingCart = shoppingCart;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int breadId)
        {
            var selectedBread = _breadRepository.Breads.FirstOrDefault(b => b.BreadId == breadId);

            if (selectedBread != null)
            {
                _shoppingCart.AddToCart(selectedBread, 1);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int breadId)
        {
            var selectedBread = _breadRepository.Breads.FirstOrDefault(b => b.BreadId == breadId);

            if (selectedBread != null)
            {
                _shoppingCart.RemoveFromCart(selectedBread);
            }
            return RedirectToAction("Index");
        }
    }
}
