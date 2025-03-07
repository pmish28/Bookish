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

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Author,PublicationYear,Genre")] BookViewModel bookViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(new Book(bookViewModel));
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}