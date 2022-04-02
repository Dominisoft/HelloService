using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Web.Administration;
using System;
using System.Linq;
using System.IO;
using Dominisoft.WebCommon.Infrastructure;
using Dominisoft.WebCommon.Models;
using Dominisoft.WebCommon.Infrastructure.Attributes;
using Microsoft.AspNetCore.Routing;
using Dominisoft.WebCommon.Infrastructure.Controllers;
using Dominisoft.WebCommon.Infrastructure.CustomExceptions;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloService.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : NokatesControllerBase
    {

        // GET: api/<ValuesController>
        [HttpGet]
        [EndpointGroup("Hello")]
        public string Get()
        {
            ConfigurationValues.TryGetValue(out var name, "Name");
            return $"Hello {name}";
        }
        [HttpGet("{name}")]
        [EndpointGroup("Hello")]
        [NoAuth]

        public string Get2(string name)
        {
            if (name == "ErrorTest")
                throw new BadRequestException("This is a test error message");
            return $"Hello {name}";
        }
        [HttpGet("User")]
        [EndpointGroup("Hello")]

        public string Get3()
        {
            var user = HttpContext.User;
            var claims = user.Claims.ToList();
            var name = claims.FirstOrDefault(c => c.Type == "name")?.Value;
            return $"Hello {name}";
        }

    }
}
