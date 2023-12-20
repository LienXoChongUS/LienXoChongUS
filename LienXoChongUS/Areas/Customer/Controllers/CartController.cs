using LXxUS.DataAccess.Repository.IRepository;
using LXxUS.Models;
using LXxUS.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LienXoChongUS.Areas.Customer.Controllers
{

    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.AppUserId == userId, includeProperties:"Book")
                
            };
            foreach(var cart in ShoppingCartVM.ShoppingCartList) {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }

        public IActionResult Summary() 
        {
            return View();
        }

        public IActionResult Plus(int? cartId) 
        {
            var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            cartFormDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(cartFormDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Minus(int? cartId) 
        {
            var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            if(cartFormDb.Count <= 1) {
                //remove from cart
                _unitOfWork.ShoppingCart.Delete(cartFormDb);
            }
            else
            {
                // minus from cart
                cartFormDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFormDb);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? cartId) 
        {
            var cartFormDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            _unitOfWork.ShoppingCart.Delete(cartFormDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            return shoppingCart.Book.Price;
        }
    }
}
