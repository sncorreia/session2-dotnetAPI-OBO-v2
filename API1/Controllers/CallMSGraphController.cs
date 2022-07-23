using API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace API1.Controllers
{
    [Authorize]
    [Route("api1/[controller]")]
    [ApiController]
    public class CallMSGraphController : ControllerBase
    {
        private readonly GraphServiceClient _graphServiceClient;

        public CallMSGraphController(GraphServiceClient graphServiceClient)
        {
            _graphServiceClient = graphServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<Userinfo>> GetUserInfoFromMSGraph()
        {
            var user = await _graphServiceClient.Me.Request().GetAsync();

            var userinfo = new Userinfo
            {
                DisplayName = user.DisplayName,
                Email = user.Mail
            };

            return Ok(userinfo);
        }
    }
}
