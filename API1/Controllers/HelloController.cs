using API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers
{
    [Authorize]
    [Route("api1/[controller]")]
    [ApiController]
    public class HelloController : ControllerBase
    {
        public ActionResult GetResponseForAPI1()
        {
            var response = new API1Response
            {
                ComingFromAPI = 1,
                API1CreatedAt = DateTime.Now,
                Description = "Example response from API1"
            };

            return Ok(response);
        }
    }
}
