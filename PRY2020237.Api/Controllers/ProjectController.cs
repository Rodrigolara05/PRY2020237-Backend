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
    public class ProjectController : ControllerBase
    {
        private IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService=projectService;
        }

         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                projectService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] Project project)
        {
            return Ok(
                projectService.Save(project)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] Project project)
        {
            return Ok(
                projectService.Update(project)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                projectService.Delete(id)
            );
        }

    }
}