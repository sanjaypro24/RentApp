using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.ViewModel;

namespace RentApp.Services.Interface
{
    public interface IBookServices
    {
        Task<List<BookModel>> GetAll();
        BookModel GetById(Guid id);
        Task<BookModel> CreateBook(BookModel bookModel);
        Task<bool> DeleteById(Guid id);

    }
}
