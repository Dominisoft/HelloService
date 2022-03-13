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
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloService.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private List<EndpointDataSource> endpointSources;

        public ValuesController(IEnumerable<EndpointDataSource> endpointSources)
        {
            this.endpointSources = endpointSources.ToList();
        }

        // GET: api/<ValuesController>
        [HttpGet]
        [EndpointGroup("Hello")]
        public string Get()
        {
            var name = ConfigurationValues.Values["Name"];
            return $"Hello {name}";
        }
        [HttpGet("{name}")]
        [EndpointGroup("Hello")]
        [NoAuth]

        public string Get2(string name)
        {
            var e = AppHelper.GetEndpoints(endpointSources);
            return $"Hello {name}";
        }

    }
}
