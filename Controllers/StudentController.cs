﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult UploadReciept([FromForm] PaidSessionDTO session)
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
    }
}
