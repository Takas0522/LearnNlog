using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnNlog.Logging;
using LearnNlog.Logging.FilterExtensions;
using Microsoft.AspNetCore.Mvc;

namespace LearnNlog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ActionLogFilter]
    [ExceptionLogFilter]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var a = 0;
            var b = 0;
            var c = a / b;
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
