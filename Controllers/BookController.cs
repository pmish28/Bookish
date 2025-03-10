using System.Diagnostics;
using System.Threading.Tasks;
using Bookish.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
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

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);

            BookViewModel bookViewModal = new(book)
            {
                AvailableCopies = _context.BookCopy.Where(copy => copy.Book == book && copy.IsCheckedOut == false).Count(),
                TotalCopies = _context.BookCopy.Where(copy => copy.Book == book).Count()
            };
            return View(bookViewModal);
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

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }            
            return View(new BookViewModel(book));
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Author,PublicationYear,TotalCopies,AvailableCopies,Genre")] BookViewModel book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(new Book(book));
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            
            return View(new BookViewModel(book));
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(book => book.Id == id);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       // GET: Books/Create
        public IActionResult AddBookCopy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBookCopy(int Id, AddCopyViewModel addCopyViewModel)
        {
            if (ModelState.IsValid)
            {
                for(int i=1;i<addCopyViewModel.NumberOfCopies;i++)
                {
                    BookCopy bookCopy = new(Id,false);
                    await _context.BookCopy.AddAsync(bookCopy);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Details));
            }
            return View(addCopyViewModel);
        }
    }
}