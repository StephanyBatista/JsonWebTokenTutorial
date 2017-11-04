using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtTutorial.JwtModels;
using JwtTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace JwtTutorial.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Post([FromBody]LoginModel loginModel)
        {
            if (loginModel.Username != "stephany" && loginModel.Password != "batista")
                return Unauthorized();

            var token = new JwtTokenBuilder()
                                .AddSecurityKey(JwtSecurityKey.Create("a-password-very-big-to-be-good"))
                                .AddSubject("Stehany Batista")
                                .AddIssuer("stephanybatista.com")
                                .AddAudience("stephanybatista.com")
                                .AddNameId("salmeidabatista@gmail.com")
                                .AddClaim("employeer", "31")
                                .AddExpiry(1)
                                .Build();

            return Ok(token);
        }       
    }
}
