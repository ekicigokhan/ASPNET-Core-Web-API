using HelloWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HelloWebAPI.Controllers
{
    [ApiController]
    [Route("home")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMessage()
        {
            var result = new ResponseModel()
            {
                HttpStatus = 200,
                Message = "Hello ASP"
            };
            return Ok(result);
        }
    }
}
