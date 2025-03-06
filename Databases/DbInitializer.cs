// using EFCoreTutorialsConsole;

using Bookish.Models;

namespace Bookish
{
    public class DbInitializer
    {
        public static void Initialize()
        {

            using (var context = new BookishContext())
            {
                //creates db if not exists 
                context.Database.EnsureCreated();

                //create entity objects
                var book1 = new Book(){Name="Harry Potter 1",Author="J.K.Rowling",PublicationYear = 1997, Genre="Fiction",TotalCopies=100,AvailableCopies =100};
                var book2 = new Book(){Name="The Lord of the Rings",Author="J.R.R. Tolkien",PublicationYear = 1954, Genre="Fiction",TotalCopies=200,AvailableCopies =200};

                // var bookcopy1 = new Student() { FirstName = "Yash", LastName = "Malhotra", Grade = grd1 };

                //add entitiy to the context
                context.Books.Add(book1);
                context.Books.Add(book2);
                

                //save data to the database tables
                context.SaveChanges();
               
            }

        }

    }
}