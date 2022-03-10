using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Web.Administration;
using System;
using System.Linq;
using System.IO;
using Dominisoft.WebCommon.Infrastructure;
using Dominisoft.WebCommon.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloService.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            //return $"{AppHelper.GetRootUri()}config/{AppHelper.GetAppName()}";
            var name = ConfigurationValues.Values["name"];
            return $"Hello {name}";
        }

    }
}
