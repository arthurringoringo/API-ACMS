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
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices ?? throw new ArgumentNullException(nameof(studentServices));
        }

        [HttpPost("account/create")]
        public IActionResult CreateAccount([FromBody] Student student)
        {
            var result = _studentServices.CreateStudentAccount(student);

            return Ok(result);

        }
    }
}
