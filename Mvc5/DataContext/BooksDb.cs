using System.Data.Entity;
using Books.Entities;

namespace Mvc5.DataContext
{
    public class BooksDb : DbContext
    {
        public BooksDb() : base("DefaultConnection")
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}