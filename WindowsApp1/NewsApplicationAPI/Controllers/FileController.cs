﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NewsApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public FileController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            FileWorxObject.File @object = new FileWorxObject.File();
            @object.ID = id;
            var result = @object.Read();
            if (result)
                return @object.ToString();
            return NotFound();
        }

        // POST api/<BusinessController>
        [HttpPost]
        public ActionResult Update([FromBody] FileWorxObject.File @object)
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
            FileWorxObject.File @object = new FileWorxObject.File();
            @object.ID = id;

            try
            {
                var result = @object.Delete();
                if (result)
                    return "Record deleted successfully";
                return Ok();
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