using DI_Playground.Services.SomeTaskManagement;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DI_Playground.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("SomeAction/A")] 
        public IActionResult SomeAction([FromKeyedServices("A")] ISomeClass someClass)
        {
            return Ok(someClass.GetServiceName());
        }
    }

}
