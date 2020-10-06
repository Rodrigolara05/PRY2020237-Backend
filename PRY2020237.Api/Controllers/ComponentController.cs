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
    public class ComponentController : ControllerBase
    {
        private IComponentService componentService;

        public ComponentController(IComponentService componentService)
        {
            this.componentService= componentService;
        }

         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                componentService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Component component)
        {
            return Ok(
                componentService.Save(component)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Component component)
        {
            return Ok(
                componentService.Update(component)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                componentService.Delete(id)
            );
        }

    }
}