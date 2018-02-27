using Library.BLL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var publications = _publicationsService.GetAll();
            return Ok(publications.Publications);
        }
    }
}
