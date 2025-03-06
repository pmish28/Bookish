
namespace Bookish.Models {
    public class Book 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public string Genre { get; set; }

        public Book(BookViewModel bookViewModel) {
            Id = bookViewModel.Id;
            Name = bookViewModel.Name;
            Author = bookViewModel.Author;
            PublicationYear = bookViewModel.PublicationYear;
            TotalCopies = bookViewModel.TotalCopies;
            AvailableCopies = bookViewModel.AvailableCopies;
            Genre = bookViewModel.Genre;
        }
        public Book() {}
    }
}
