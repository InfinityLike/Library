using Library.BLL.Services;
using Library.ViewModels.Brochure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class BrochureController : Controller
    {
        private readonly BrochureService _brochureService;

        public BrochureController()
        {
            _brochureService = new BrochureService();
        }

        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var brochures = _brochureService.GetAll();
            return Ok(brochures);
        }

        // POST api/<controller>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostBrochureViewModel brochure)
        {
            _brochureService.Add(brochure);
            return Ok();
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutBrochureViewModel brochure)
        {
            _brochureService.Update(brochure);
            return Ok();
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brochureService.Remove(id);
            return Ok();
        }
    }
}
