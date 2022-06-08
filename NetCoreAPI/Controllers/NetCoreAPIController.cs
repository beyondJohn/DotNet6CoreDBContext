using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreAPI.Data;

namespace NetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetCoreAPIController : ControllerBase
    {
        private readonly IDbContextFactory<NetCoreDBContext> _db;
        private readonly ILogger<NetCoreAPIController> _logger;
        
        public NetCoreAPIController(ILogger<NetCoreAPIController> logger, IDbContextFactory<NetCoreDBContext> contextFactory)
        {
            _logger = logger;
            _db = contextFactory;
        }

        [HttpGet]
        public string Get()
        {
            var name = "";
            using (var db = _db.CreateDbContext())
            {
                var users = db.Users.Select(x => x.FirstName);
                name = users.First();
            }
            return name;

        }
    }
}