using System.Diagnostics;
using System.Threading.Tasks;
using Bookish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Controllers
{
    public class BookController : Controller
    {


        private readonly BookishContext _context;
        public BookController(BookishContext context)
        {
            _context = context;

        }
        public async Task<IActionResult> Index()
        {
            List<BookViewModel> books = (await _context.Books.ToListAsync()).Select(book=>new BookViewModel(book)).ToList();
            return View(books);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}