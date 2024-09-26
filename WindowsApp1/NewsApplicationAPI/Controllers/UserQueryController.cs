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
    public class UserQueryController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UserQueryController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: api/<BusinessQueryController>/Get
        [HttpPost("Run")]
        public ActionResult<IEnumerable<string>> Run([FromBody] FileWorxObject.UserQuery query)
        {
            //FileWorxObject.BusinessQuery query = new FileWorxObject.BusinessQuery();
            var result = query.Run();
            if (result is null)
                return NotFound();
            return result;
        }
    }
}
