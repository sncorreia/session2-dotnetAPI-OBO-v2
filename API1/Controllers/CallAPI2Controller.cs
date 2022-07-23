using API1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using System.Text.Json;

namespace API1.Controllers
{
    [Authorize]
    [Route("api1/[controller]")]
    [ApiController]
    public class CallAPI2Controller : ControllerBase
    {
        private readonly IDownstreamWebApi _downstreamWebApi;
        private const string ServiceName = "API2";

        public CallAPI2Controller(IDownstreamWebApi downstreamWebApi)
        {
            _downstreamWebApi = downstreamWebApi;
        }

        [HttpGet]
        public async Task<ActionResult<API2Response>> GetAPI2()
        {
            var response = await _downstreamWebApi.CallWebApiForUserAsync(ServiceName, options =>
            {
                options.RelativePath = "hello";
            });

            if(response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var api2response = JsonSerializer.Deserialize<API2Response>(content, options);

                return api2response;
            }

            return StatusCode(500);
        }
    }
}
