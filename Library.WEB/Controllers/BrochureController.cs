using Library.BLL.Services;
using Library.ViewModels.Brochure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var brochures = _brochureService.GetAll();
            return Ok(brochures);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostBrochureViewModel brochure)
        {
            _brochureService.Add(brochure);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PutBrochureViewModel brochure)
        {
            _brochureService.Update(brochure);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _brochureService.Remove(id);
            return Ok();
        }
    }
}
