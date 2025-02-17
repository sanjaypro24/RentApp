using Microsoft.AspNetCore.Mvc;
using RentApp.Models.ViewModel;
using RentApp.Services.Implementation;
using RentApp.Services.Interface;

namespace RentApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        private readonly IBookServices _bookService;
        public BookController(IBookServices bookService)
        {
            _bookService = bookService;
        }
        [HttpGet("getAll")]

        public async Task<IActionResult> GetAll()
        {
            List<BookModel> books = await _bookService.GetAll();
            return Ok(books);
        }

        [HttpGet("getById/{{id}}")]

        public IActionResult GetById(Guid id)
        {

            BookModel books = _bookService.GetById(id);
            return Ok(books);
        }
        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] BookModel bookModel)
        {
            //if (bookModel == null)
            //{
            //    return BadRequest("User data is required.");
            //}
            //BookModel createdBook = await _bookService.CreateBook(bookModel);
            //return CreatedAtAction(nameof(GetById), new { id = createdBook.Bookid }, createdBook);

            if (bookModel == null)
                return BadRequest("Invalid data");

            BookModel createdBook = await _bookService.CreateBook(bookModel);

            return Ok(createdBook);
        }
        [HttpDelete("deleteById/{{id}}")]
        public async Task<IActionResult> DeleteById(Guid id)
        {
            bool isDeleted = await _bookService.DeleteById(id);
            if (!isDeleted)
            {
                return NotFound("User not found.");
            }
            return NoContent();
        }
    }
}
