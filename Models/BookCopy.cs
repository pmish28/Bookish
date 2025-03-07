
namespace Bookish.Models {
    public class BookCopy
    {
        public int Id { get; set; }        
        public ICollection<Book> Books { get; set; }
        public bool IsCheckedOut  {get;set;}

        // public BookCopy(BookCopyViewModel bookCopyViewModel) {
        //     Id = bookCopyViewModel.Id;
        //     Books = bookCopyViewModel.Books;
        //     IsCheckedOut = bookCopyViewModel.IsCheckedOut;

        
        // }
        public BookCopy() {}
    }
}
