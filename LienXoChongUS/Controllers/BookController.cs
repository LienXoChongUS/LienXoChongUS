using LXxUS.DataAccess.Data;
using LXxUS.DataAccess.Repository.IRepository;
using LXxUS.Models;
using LXxUS.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LienXoChongUS.Controllers
{
    public class BookController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BookController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Book> objBookList = _unitOfWork.Book.GetAll(includeProperties:"Category").ToList();
            
            return View(objBookList);
        }

        public IActionResult UpSert(int? id)
        {
            BookVM bookVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Book = new Book()
            };
            if (id == null || id == 0)
            {
                //Create
                return View(bookVM);
            }
            else
            {
                bookVM.Book = _unitOfWork.Book.Get(u => u.Id == id);
                return View(bookVM);
            }

            
        }

        [HttpPost]
        public IActionResult UpSert(BookVM bookVM, IFormFile? file)
        {          
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string bookPath = Path.Combine(wwwRootPath, @"images\books");

                    if (!string.IsNullOrEmpty(bookVM.Book.ImageUrl))
                    {
                        // delete the old image
                        var oldImagePath = Path.Combine(wwwRootPath, bookVM.Book.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(bookPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    } ;

                    bookVM.Book.ImageUrl = @"\images\books\"+ fileName;
                }
                if(bookVM.Book.Id == null)
                {
                    _unitOfWork.Book.Add(bookVM.Book);
                }
                else
                {
                    _unitOfWork.Book.Update(bookVM.Book);
                }

                _unitOfWork.Save();
                TempData["SuccessMessage"] = "Book created successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                bookVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(bookVM);
            }       
        }                  

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Book? BookFromDb = _unitOfWork.Book.Get(u  => u.Id == id);
            if (BookFromDb == null)
            {
                return NotFound();
            }
            return View(BookFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Book? obj = _unitOfWork.Book.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Book.Delete(obj);
            _unitOfWork.Save();
            TempData["SuccessMessage"] = "Book deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
