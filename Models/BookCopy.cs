
namespace Bookish.Models {
    public class BookCopy
    {
        public int Id { get; set; }        
        public Book Book { get; set; }
        public bool IsCheckedOut  {get;set;}

        public BookCopy(int id, bool isCheckedOut) {
            Id = id;
            IsCheckedOut = isCheckedOut;        
        }
        public BookCopy() {}
    }
}
