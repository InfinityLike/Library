using System;
using System.Collections.Generic;
using Library.Entities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.WEB.Controllers
{
    [Route("api/[controller]")]
    public class TypeOfCoverController : Controller
    {
        // GET: api/<controller>
        [Authorize]
        [HttpGet]
        public IActionResult Get()
        {
            var typeList = Enum.GetNames(typeof(TypeOfCover));
            return Ok(typeList);
        }
    }
}
