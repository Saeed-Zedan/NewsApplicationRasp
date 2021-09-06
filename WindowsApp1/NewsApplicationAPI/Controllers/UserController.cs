using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace NewsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<BusinessController>/Get
        [HttpPost("Get")]
        public ActionResult<IEnumerable<string>> Get([FromBody] FileWorxObject.UserQuery query)
        {
            //FileWorxObject.UserQuery query = new FileWorxObject.UserQuery();
            var result = query.Run();
            if (result is null)
                return NotFound();
            return result;
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            FileWorxObject.User @object = new FileWorxObject.User();
            @object.ID = id;
            var result = @object.Read();
            if (result)
                return @object.ToString();
            return NotFound();
        }

        // POST api/<BusinessController>
        [HttpPost]
        public ActionResult<FileWorxObject.User> Post([FromBody] FileWorxObject.User @object)
        {
            var result = @object.Update();
            //if (result != 0)
            //    return "Record added successfully";
            return CreatedAtAction(nameof(Get), new { id = @object.ID }, @object);
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            FileWorxObject.User @object = new FileWorxObject.User();
            @object.ID = id;
            var result = @object.Delete();
            if (result)
                return "Record deleted successfully";
            return "Invalid Oberation";
        }
    }
}
