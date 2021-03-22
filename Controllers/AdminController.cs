using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIACMS.Services;
using ACMS.DAL.Models;

namespace APIACMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminServices;
        private readonly IStudentServices _studentServices;

        public AdminController(IAdminServices adminServices
                                , IStudentServices studentServices)
        {
            _adminServices = adminServices ?? throw new ArgumentNullException(nameof(adminServices));
            _studentServices = studentServices ?? throw new ArgumentNullException(nameof(studentServices));
        }
        //Create

        [HttpPost("availableclass/create")]
        public IActionResult CreateAvailableClass([FromBody] AvailableClass model)
        {
            var result = _adminServices.CreateAvailableClass(model);

            return Ok(result);

        }


        [HttpPost("classcategory/create")]
        public IActionResult CreateClassCategory([FromBody] ClassCategory model)
        {
            var result = _adminServices.CreateClassCategory(model);

            return Ok(result);

        }


        [HttpPost("classreport/create")]
        public IActionResult CreateAvailableClass([FromBody] ClassReport model)
        {
            var result = _adminServices.CreateClassReport(model);

            return Ok(result);

        }


        [HttpPost("paidsession/create")]
        public IActionResult CreatePaidSession([FromForm] PaidSessionDTO model)
        {
            var result = _studentServices.UploadReciept(model);

            return Ok(result);

        }

        [HttpPost("paymentmethod/create")]
        public IActionResult CreatePaymentMethod([FromBody] PaymentMethod model)
        {
            var result = _adminServices.CreatePaymentMethod(model);

            return Ok(result);

        }


        [HttpPost("sessionschedule/create")]
        public IActionResult CreateSessionSchedule([FromBody] SessionSchedule model)
        {
            var result = _adminServices.CreateSessionSchedule(model);

            return Ok(result);

        }


        [HttpPost("teacher/create")]
        public IActionResult CreateTeacherUser([FromBody] Teacher model)
        {
            var result = _adminServices.CreateTeacher(model);

            return Ok(result);

        }
        //

        [HttpGet("registeredclass/get/all")]
        public IActionResult GetRegisteredClass()
        {
            var result = _adminServices.GetRegistredClass();

            return Ok(result);
        }

        [HttpGet("AvailableClass/get/{id}")]
        [DisableRequestSizeLimit]
        public IActionResult GetAvailableClass([FromRoute] Guid id)
        {
            var result = _adminServices.GetAvailableClassesWithExpressionAndFkData(id);

            return Ok(result);
        }
    }

}
