using Library.BLL.Services;
using Library.ViewModels.Magazine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class MagazineController : Controller
    {
        private readonly MagazineService _magazineService;

        public MagazineController()
        {
            _magazineService = new MagazineService();
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var magazines = _magazineService.GetAll();
            return Ok(magazines);
        }
        
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostMagazineViewModel magazine)
        {
            _magazineService.Add(magazine);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]PutMagazineViewModel magazine)
        {
            _magazineService.Update(magazine);
            return Ok();
        }
        
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _magazineService.Remove(id);
            return Ok();
        }
    }
}
