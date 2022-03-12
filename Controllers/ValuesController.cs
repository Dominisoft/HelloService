﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Web.Administration;
using System;
using System.Linq;
using System.IO;
using Dominisoft.WebCommon.Infrastructure;
using Dominisoft.WebCommon.Models;
using Dominisoft.WebCommon.Infrastructure.Attributes;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloService.Controllers
{
    [Route("")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        [EndpointGroup("Read")]
        public string Get()
        {
            //return $"{AppHelper.GetRootUri()}config/{AppHelper.GetAppName()}";
            var name = ConfigurationValues.Values["Name"];
            return $"Hello {name}";
        }
        [HttpGet("{name}")]
        [EndpointGroup("Write","Read")]

        public string Get2(string name)
        {
            return $"Hello {name}";
        }

    }
}
