using Library.BLL.Services;
using Library.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(IConfiguration configuration)
        {
            _bookService = new BookService();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.GetAll();
            return Ok(books.Books);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostBookViewModel book)
        {
            _bookService.Add(book);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutBookViewModel book)
        {
            _bookService.Update(book);
            return Ok();
        }
        
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Remove(id);
            return Ok();
        }
    }
}
