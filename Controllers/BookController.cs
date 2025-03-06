using System.Diagnostics;
using Bookish.Models;
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
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}