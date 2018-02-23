using Library.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class PublicationsController : Controller
    {
        private readonly PublicationsService _publicationsService;

        public PublicationsController()
        {
            _publicationsService = new PublicationsService();
        }

        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var publications = _publicationsService.GetAll();
            return Ok(publications);
        }
    }
}
