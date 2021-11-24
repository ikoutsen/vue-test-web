using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTestWebAPI.DAL;

namespace VueTestWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : Controller {
        private IUnitOfWork data;
        public CompaniesController(IUnitOfWork uow) {
            this.data = uow;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var companies = await data.Companies.GetAll();
            return Ok(companies);
        }
    }
}