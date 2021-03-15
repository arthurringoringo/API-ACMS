using ACMS.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace APIACMS.Services
{
    public interface IStudentServices
    {
        public bool CreateStudentAccount(Student model);
        public bool RegisterClassStudent(RegistredClass model);
        public bool UpdateProfile(Student student);
        public string UploadReciept(PaidSessionDTO session);
        public IQueryable<Student> GetProfileStudent(Guid guid);

    }
}