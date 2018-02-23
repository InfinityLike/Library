using Library.BLL.Services;
using Library.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class PublisherController : Controller
    {
        private readonly PublisherService _publisherService;

        public PublisherController()
        {
            _publisherService = new PublisherService();
        }

        //GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _publisherService.GetAll();
            return Ok(publishers);
        }

        // POST api/<controller>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostPublisherViewModel publisher)
        {
            _publisherService.Add(publisher);
            return Ok();
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutPublisherViewModel publisher)
        {
            _publisherService.Update(publisher);
            return Ok();
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _publisherService.Remove(id);
            return Ok();
        }
    }
}
