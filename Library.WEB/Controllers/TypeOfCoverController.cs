using System;
using Library.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class TypeOfCoverController : Controller
    {
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var typeList = Enum.GetNames(typeof(TypeOfCover));
            return Ok(typeList);
        }
    }
}
