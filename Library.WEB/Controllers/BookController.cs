using Library.BLL.Services;
using Library.ViewModels.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController()
        {
            _bookService = new BookService();
        }

        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var books = _bookService.GetAll();
            return Ok(books);
        }

        // POST api/<controller>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostBookViewModel book)
        {
            _bookService.Add(book);
            return Ok();
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutBookViewModel book)
        {
            _bookService.Update(book);
            return Ok();
        }
        
        // DELETE api/<controller>/5
        [Authorize(Roles ="admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Remove(id);
            return Ok();
        }
    }
}
