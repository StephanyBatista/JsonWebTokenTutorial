using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using JwtTutorial.JwtModels;
using JwtTutorial.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtTutorial.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            var name = User.Claims.First(c => c.Type == "NameId").Value;
            
            return Json(name);
        }       
    }
}
