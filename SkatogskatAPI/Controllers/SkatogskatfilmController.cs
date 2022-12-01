using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkatogskatAPI.Managers;
using SkatogskatAPI.Models;

namespace SkatogskatAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SkatogskatfilmController : SecuredAPIController
    {
        private readonly SkatogskatfilmManager _manager = new SkatogskatfilmManager();
        private readonly GatewayConfig _config;
        public SkatogskatfilmController(Models.GatewayConfig config)
        {
            _config = config;
        }

        [HttpGet]
        public IEnumerable<Film> GetAllFilms()
        {
            return _manager.GetAllFilms();
        }
        [HttpPost]
        public Film Post([FromBody] Film value)
        {
            return _manager.Add(value);
        }
        [HttpPut]
        [Route("Id/{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return _manager.Update(id, value);
        }

        [HttpDelete("id/{id}")]
        public ActionResult<Film> Delete([FromQuery(Name = "Authorization")] string authorization, int id)
        {
            if(authorization != _config.SharedSecret)
            {
                throw new UnauthorizedAccessException();
                return Unauthorized();

            }
            Film result = _manager.Delete(id, _config);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
