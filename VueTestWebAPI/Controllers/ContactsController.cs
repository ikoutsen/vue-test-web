using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueTestWebAPI.DAL;
using VueTestWebAPI.Models;

namespace VueTestWebAPI.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : Controller {
        private IUnitOfWork data;
        public ContactsController(IUnitOfWork uow) {
            this.data = uow;
        }
        [HttpGet]
        public async Task<ActionResult> Get() {
            var contacts = await data.Employees.GetAll(includeProperties: "Company,Position");
            return Ok(contacts);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id) {
            var contact = await data.Employees.Get(id);
            return Ok(contact);
        }
        [HttpPost]
        public async Task<ActionResult> Post(Employee employee) {
            await data.Employees.Add(employee);
            await data.SaveAsync();
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Put(Employee employee) {
            data.Employees.Update(employee);
            await data.SaveAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) {
            await data.Employees.Delete(id);
            await data.SaveAsync();
            return Ok();
        }
    }
}