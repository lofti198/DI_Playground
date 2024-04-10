﻿using DI_Playground.Services.SomeTaskManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_Playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        private readonly DITypeFactoryBase<string, ISomeClass> _someClassFactory;

        public SomeController(DITypeFactoryBase<string, ISomeClass> someClassFactory)
        {
            _someClassFactory = someClassFactory;
        }

        [HttpGet("SomeAction/{key}")] 
        public IActionResult SomeAction(string key)
        {
            var someClassInstance = _someClassFactory.GetOrCreate(key);
            
            return Ok(someClassInstance.GetServiceName());
        }
    }

}
