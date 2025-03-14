
namespace Bookish.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public string Genre { get; set; }

        public BookViewModel(Book book)
        {
            Id = book.Id;
            Name = book.Name;
            Author = book.Author;
            PublicationYear = book.PublicationYear;
            TotalCopies = book.TotalCopies;
            AvailableCopies = book.AvailableCopies;
            Genre = book.Genre;
        }
    }
}