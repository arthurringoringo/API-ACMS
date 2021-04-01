using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using APIACMS.Services;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;


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

        [HttpPost("payment/upload/reciept")]
        [DisableRequestSizeLimit]
        public IActionResult UploadReciept([FromForm] PaidSessionDTOs session)
        {
            var result = _studentServices.UploadReciept(session);

            return Ok(result);


        }

        [HttpGet("profile/{id}")]
        public IActionResult GetStudentProfile(Guid id)
        {
            var result = _studentServices.GetProfileStudent(id);

            return Ok(result);
        }
        [HttpGet("profile/user/{id}")]
        public IActionResult GetStudentProfile(int id)
        {
            var result = _studentServices.GetProfileStudentUser(id);

            return Ok(result);
        }
        [HttpGet("registred/class/{id}")]
        public IActionResult GetStudentRegistredClass(Guid id)
        {
            var result = _studentServices.GetStudentRegistredClass(id);

            return Ok(result);
        }
        [HttpGet("registred/class/notpaid/{id}")]
        public IActionResult GetStudentRegistredClassNotPaid(Guid id)
        {
            var result = _studentServices.GetStudentRegistredClassNotFullyPaid(id);

            return Ok(result);
        }
        [HttpGet("paidsession/{id}")]
        public IActionResult GetStudentPaidSession(Guid id)
        {
            var result = _studentServices.GetStudentPaidSessionWithFKData(id);

            return Ok(result);
        }

        [HttpPost("class/register")]
        public IActionResult RegisterClass([FromBody] RegistredClass registerClass)
        {
            var result = _studentServices.RegisterClassStudent(registerClass);

            return Ok(result);
        }


        [HttpPost("profile/update")]
        public IActionResult UpdateProfile([FromBody] Student student)
        {
            var result = _studentServices.UpdateProfile(student);

            return Ok(student);
        }
        [HttpGet("classcategory")]
        public IActionResult Getclasscategory()
        {
            var result = _studentServices.GetAvailableClassCategory();

            return Ok(result);
        }
        [HttpGet("availableclass")]
        public IActionResult GetAvailableClass()
        {
            var result = _studentServices.GetAvailableClass();

            return Ok(result);
        }
        [HttpGet("paymentmethod")]
        public IActionResult GetPaymentMethod()
        {
            var result = _studentServices.GetPaymentMethod();

            return Ok(result);
        }
    }
}
