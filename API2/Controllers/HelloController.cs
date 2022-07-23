using API2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API2.Controllers
{
    [Authorize]
    [Route("api2/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetResponseForAPI2()
        {
            var response = new API2Response
            {
                ComingFromAPI = 2,
                API2CreatedAt = DateTime.Now,
                Description = "Example response from API2"
            };

            return Ok(response);
        }
    }
}
