using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Example.Core.Models;

namespace Example.Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IBaseRepository<Author> Authors { get; }
        // IBaseRepository<Book> Books { get; }
        IBooksRepository Books { get; }
        int Complete();
    }
}
