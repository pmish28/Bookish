
using System.ComponentModel.DataAnnotations;

namespace Bookish.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public int PublicationYear { get; set; }

        [Required]
        public string Genre { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }

        public Book(BookViewModel bookViewModel)
        {
            Id = bookViewModel.Id;
            Name = bookViewModel.Name;
            Author = bookViewModel.Author;
            PublicationYear = bookViewModel.PublicationYear;
            Genre = bookViewModel.Genre;
        }
        public Book() { }
    }
}
