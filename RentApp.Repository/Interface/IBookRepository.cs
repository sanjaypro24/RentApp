using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Repository.Entities;

namespace RentApp.Repository.Interface
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Book GetById(Guid id);
        Task<Book> CreateBook(Book book);
        Task<bool> DeleteById(Guid id);

    }
}
