using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using APIACMS.Services;

namespace APIACMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ServiceExtensionController : ControllerBase
    {
        private readonly IServiceExtension _emailServices;

        public ServiceExtensionController( IServiceExtension emailServices)
        {

            _emailServices = emailServices ?? throw new ArgumentNullException(nameof(emailServices));
        }


        [HttpPost("email/send")]
        public IActionResult SendEmail([FromBody] EmailDto content)
        {

            var result = _emailServices.Send(content);

            return Ok(result);

        }
    }
}
