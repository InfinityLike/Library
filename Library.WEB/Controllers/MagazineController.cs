using Library.BLL.Services;
using Library.ViewModels.Magazine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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

        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var magazines = _magazineService.GetAll();
            return Ok(magazines);
        }

        // POST api/<controller>
        [Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Post([FromBody]PostMagazineViewModel magazine)
        {
            _magazineService.Add(magazine);
            return Ok();
        }

        // PUT api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public IActionResult Put([FromRoute]int id, [FromBody]PutMagazineViewModel magazine)
        {
            _magazineService.Update(magazine);
            return Ok();
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _magazineService.Remove(id);
            return Ok();
        }
    }
}
