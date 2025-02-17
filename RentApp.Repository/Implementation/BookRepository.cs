using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentApp.Repository.Entities;
using RentApp.Repository.Interface;

namespace RentApp.Repository.Implementation
{
    public class BookRepository:IBookRepository
    {
        public readonly AppDbContext _dbContext;

        public BookRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<List<Book>> GetAll()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public Book GetById(Guid id)
        {
            return _dbContext.Books.FirstOrDefault(book => book.Bookid == id);
        }
        public async Task<Book> CreateBook(Book book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();
            return book;
        }
        public async Task<bool> DeleteById(Guid id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
                return false;

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
