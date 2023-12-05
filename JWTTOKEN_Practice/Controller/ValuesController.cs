using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTTOKEN_Practice.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext context;
        public ValuesController(DataContext context)
        {
            this.context = context;
        }
       
        [HttpPost("SignIn")]
        public IActionResult SignIn(SignUp signUp)  //signIn part
        {
            var data = context.signUps.Add(signUp);
            context.SaveChanges();
            return Ok("Record Added successfully...");
            //return BadRequest(data);
            //return 
           
        }

        [HttpPost("Login")]
        public IActionResult Login(SignUp signUp)
        {
            bool data = context.signUps.Any(x => x.Email == signUp.Email && x.Password == signUp.Password);

            if (data != false)
            {
                return RedirectToAction("", "");
              
            }

            return Ok();
        }

    }
}

