using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PRY2020237.Entity;
using PRY2020237.Service;

namespace PRY2020237.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService=userService;
        }

         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                userService.GetAll()
            );
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] User user)
        {
            return Ok(
                userService.Login(user.email,user.password)
            );
        }


        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            return Ok(
                userService.Save(user)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] User user)
        {
            return Ok(
                userService.Update(user)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                userService.Delete(id)
            );
        }

    }
}