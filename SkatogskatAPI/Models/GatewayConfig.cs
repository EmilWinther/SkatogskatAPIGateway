using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkatogskatAPI.Models
{
    public class GatewayConfig
    {
        [FromHeader]
        public String SharedSecret { get; set; }

    }
    public class GatewayConfigVariable
    {
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
