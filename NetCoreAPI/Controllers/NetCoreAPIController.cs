using Microsoft.AspNetCore.Mvc;
using NetCoreAPI.Data;

namespace NetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetCoreAPIController : ControllerBase
    {
        private readonly ILogger<NetCoreAPIController> _logger;
        private readonly IConfiguration _configuration;

        public NetCoreAPIController(ILogger<NetCoreAPIController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public string Get()
        {
            var name = "";
            using (var db = new NetCoreDBContext(_configuration))
            {
                var users = db.Users.Select(x => x.FirstName);
                name = users.First();
            }
            return name;

        }
    }
}