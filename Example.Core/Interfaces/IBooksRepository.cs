using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using Example.Core.Models;

namespace Example.Core.Interfaces
{
    public interface IBooksRepository: IBaseRepository<Book>
    {
        IEnumerable<Book> GetAllSpecialForBooksRepository();
    }
}
