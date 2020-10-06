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
    public class PageViewController : ControllerBase
    {
        private IPageViewService pageViewService;

        public PageViewController(IPageViewService pageViewService)
        {
            this.pageViewService=pageViewService;
        }

         [HttpGet]
        public ActionResult Get()
        {
            return Ok(
                pageViewService.GetAll()
            );
        }

        [HttpPost]
        public ActionResult Post([FromBody] PageView pageView)
        {
            return Ok(
                pageViewService.Save(pageView)
            );
        }

        [HttpPut]
        public ActionResult Put([FromBody] PageView pageView)
        {
            return Ok(
                pageViewService.Update(pageView)
            );
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(
                pageViewService.Delete(id)
            );
        }

    }
}