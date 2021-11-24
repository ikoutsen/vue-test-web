using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTestWebAPI.DAL;

namespace VueTestWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class PositionsController : Controller {
        private IUnitOfWork data;
        public PositionsController(IUnitOfWork uow) {
            this.data = uow;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var position = await data.Positions.GetAll();
            return Ok(position);
        }
    }
}