using System;
using System.Collections.Generic;
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
            var name = User.Claims.Where(c => c.Issuer == "stephanybatista.com").First();
            
            return Json(new {Name = "AAA", Age = "3", UserName = name.Value});
        }       
    }
}
