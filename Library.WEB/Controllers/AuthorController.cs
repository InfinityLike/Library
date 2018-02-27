using Library.BLL.Services;
using Library.ViewModels.Author;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class AuthorController : Controller
    {
        private readonly AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var authors = _authorService.GetAll();
            return Ok(authors.Authors);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostAuthorViewModel author)
        {
            _authorService.Add(author);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutAuthorViewModel author)
        {
            _authorService.Update(author);
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.Remove(id);
            return Ok();
        }
    }
}
