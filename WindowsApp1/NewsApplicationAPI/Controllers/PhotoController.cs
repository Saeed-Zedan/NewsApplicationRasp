﻿using Microsoft.AspNetCore.Http;
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
    public class PhotoController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public PhotoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET: api/<BusinessController>
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            FileWorxObject.PhotoQuery query = new FileWorxObject.PhotoQuery();
            var result = query.Run();
            if (result is null)
                return NotFound();
            return result;
        }

        // GET api/<BusinessController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            FileWorxObject.Photo @object = new FileWorxObject.Photo();
            @object.ID = id;
            var result = @object.Read();
            if (result)
                return @object.ToString();
            return NotFound();
        }

        // POST api/<BusinessController>
        [HttpPost]
        public ActionResult Post([FromBody] FileWorxObject.Photo @object)
        {
            var result = @object.Update();
            return CreatedAtAction(nameof(Get), new { id = result }, @object);
        }

        // DELETE api/<BusinessController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            FileWorxObject.Photo @object = new FileWorxObject.Photo();
            @object.ID = id;
            var result = @object.Delete();
            if (result)
                return "Record deleted successfully";
            return "Invalid Oberation";
        }
    }
}