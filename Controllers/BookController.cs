using Microsoft.AspNetCore.Mvc;

namespace Bookish.Controllers
{
    public class BookController : Controller
    {

        public BookController()
        {

        }
        public IActionResult Index()
        {
            return View("Index");
        }
    }
}