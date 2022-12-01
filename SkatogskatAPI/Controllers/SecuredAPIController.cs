using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkatogskatAPI.Controllers
{
    public class SecuredAPIController : ControllerBase
    {
        protected Models.GatewayConfig _config { get; set; }
        protected Boolean Unauthorized { get; set; }

        protected void Protect(string authenticationToken)
        {
            if (authenticationToken != _config.SharedSecret)
            {
                this.Unauthorized = true;
            }

        }
    }
}
