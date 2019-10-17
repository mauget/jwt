﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace JwtApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtController : ControllerBase
    {
        // GET api/jwts
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "jwt1", "jwt2" };
        }

        // GET api/jwt/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "jwt";
        }

        // POST api/jwt
        [HttpPost]
        public void Post([FromBody] string jwt)
        {
            return;
        }

        // PUT api/jwt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string jwt)
        {
        }

        // DELETE api/jwt/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
