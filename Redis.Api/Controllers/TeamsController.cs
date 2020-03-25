using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Redis.Api.Models;
using StackExchange.Redis.Extensions.Core.Abstractions;

namespace Redis.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeamsController : ControllerBase
    {
        private readonly ILogger<TeamsController> _logger;
        private readonly IRedisDefaultCacheClient _cacheRedis;

        public TeamsController(ILogger<TeamsController> logger, IRedisDefaultCacheClient cacheRedis)
        {
            _logger = logger;
            _cacheRedis = cacheRedis;
        }

        public async Task<IActionResult> Get()
        {
            var result = await _cacheRedis.GetAsync<Teams>("urn:teams:patriots");

            if(result is null) 
                return NotFound();


            return Ok(result);
        }
    }
}