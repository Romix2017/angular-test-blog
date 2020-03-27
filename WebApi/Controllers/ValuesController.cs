using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ISingletonService singletonService;
        public ValuesController(ISingletonService singletonService)
        {
            this.singletonService = singletonService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Todo>> Get()
        {
            return Ok(this.singletonService.GetAll());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public ActionResult<Todo> Post([FromBody] Todo value)
        {
            this.singletonService.AddItem(value);
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<Todo> Put(int id, [FromBody] Todo value)
        {
           return Ok(this.singletonService.UpdateItem(value));
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.singletonService.RemoveItem(id);
        }
    }
}
