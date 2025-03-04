using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Core.Interfaces;
using Example.Core.Models;

namespace Example.EF.Repositories
{
    public class BooksRepository(ApplicationDbContext context) : BaseRepository<Book>(context), IBooksRepository
    {
        public IEnumerable<Book> GetAllSpecialForBooksRepository()
        {
            return context.Books.ToList();
        }
    }
}
