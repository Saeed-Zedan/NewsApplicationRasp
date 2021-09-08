using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BusinessController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            FileWorxObject.BusinessObject @object = new FileWorxObject.BusinessObject();
            @object.ID = id;
            var result = @object.Read();
            if (result)
                return @object.ToString();
            return NotFound();
        }

        // POST api/<BusinessController>
        [HttpPost]
        public ActionResult Update([FromBody] FileWorxObject.BusinessObject @object)
        {
            try
            {
                var result = @object.Update();
                @object.ID = result;
                return CreatedAtAction(nameof(Get), new { id = result }, @object);
            }
            catch (Exception e)
            {
                if (e.InnerException is SqlException)
                    return Conflict();
            }
            return NoContent();
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            FileWorxObject.BusinessObject @object = new FileWorxObject.BusinessObject();
            @object.ID = id;
            try
            {
                var result = @object.Delete();
                if (result)
                    return "Record deleted successfully";

            }
            catch (Exception e)
            {
                if (e.InnerException is SqlException)
                    return NotFound();
            }
            return NotFound();
        }
    }
}
