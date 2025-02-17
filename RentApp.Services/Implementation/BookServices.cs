using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RentApp.Models.ViewModel;
using RentApp.Repository.Entities;
using RentApp.Repository.Interface;
using RentApp.Services.Discount;
using RentApp.Services.Interface;
using RentApp.Services.Price;

namespace RentApp.Services.Implementation
{
    public class BookServices:IBookServices
    {
        private readonly IBookRepository _bookRepo;
        private readonly IMapper _mapper;
        private const decimal BasePricePerHour = 45;
        private readonly PriceCalculator _priceCalculator;
        public BookServices(IBookRepository bookRepo, IMapper mapper, PriceCalculator priceCalculator)
        {
            _bookRepo = bookRepo;
            _mapper = mapper;
            _priceCalculator = priceCalculator;
        }

        public async Task<List<BookModel>> GetAll()
        {
            List<Book> books = await _bookRepo.GetAll();
            List<BookModel> bookModels = _mapper.Map<List<BookModel>>(books);
            return bookModels;
        }

        public BookModel GetById(Guid id)
        {
            Book book = _bookRepo.GetById(id);
            BookModel bookModel = _mapper.Map<BookModel>(book);
            return bookModel;
        }
        public async Task<BookModel> CreateBook(BookModel bookModel)
        {
            Book bookEntity = _mapper.Map<Book>(bookModel);
            bookEntity.Bookid = Guid.NewGuid();
           
            decimal calculatedPrice = _priceCalculator.CalculatePrice(
                bookModel.Duration,
                bookModel.Customertype,
                bookModel.Location,
                bookModel.Engine
            );

            BookModel responseModel = _mapper.Map<BookModel>(bookEntity);
            responseModel.CalculatedPrice = calculatedPrice;

            await _bookRepo.CreateBook(bookEntity);
            return responseModel;

        }
        
        public async Task<bool> DeleteById(Guid id)
        {
            return await _bookRepo.DeleteById(id);
        }
    }
}
