using BackEnd.Data;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        public DataContextClass objDataContextClass { get; set; }
        public RegistrationController(DataContextClass registrationcontext)
        {
            this.objDataContextClass = registrationcontext;
        }
        [HttpPost("insertregistrationdata")]
        public async Task<ActionResult> Registration(Registration rg)
        {
            objDataContextClass.tblregistration.Add(rg);
            await objDataContextClass.SaveChangesAsync();
            return Ok(rg);
        }
        [HttpPost("LoginUser")]
        public IActionResult Login(Login user)
        {
            var userAvailable = objDataContextClass.tblregistration.Where(u => u.UserName == user.UserName && u.Password == user.Password).FirstOrDefault();
            System.Console.WriteLine(userAvailable);
            if (userAvailable == null)
            {
                return Ok("Failure");
            }
            return Ok("Success");
        }
    }
}
       

