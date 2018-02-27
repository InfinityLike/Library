using Library.BLL.Services;
using Library.ViewModels.Publisher;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var publishers = _publisherService.GetAll();
            return Ok(publishers.Publishers);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostPublisherViewModel publisher)
        {
            _publisherService.Add(publisher);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutPublisherViewModel publisher)
        {
            _publisherService.Update(publisher);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _publisherService.Remove(id);
            return Ok();
        }
    }
}
