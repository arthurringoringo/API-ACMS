using ACMS.DAL.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
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
        public IQueryable<ClassCategory> GetAvailableClassCategory();
        public List<AvailableClass> GetAvailableClass();
        public IQueryable<PaymentMethod> GetPaymentMethod();
        public Student GetProfileStudentUser(int id);
    }
}