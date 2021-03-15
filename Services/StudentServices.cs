using ACMS.DAL.Models;
using APIACMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;

namespace APIACMS.Services
{

    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepo _studentRepo;
        private readonly IRegistredClassRepo _registredClassRepo;
        private readonly IServiceExtension _serviceExtension;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPaidSessionRepo _paidSessionRepo;
        private readonly IClassCategoryRepo _classCategoryRepo;




        public StudentServices(IStudentRepo studentRepo,
                               IRegistredClassRepo registredClassRepo,
                               IServiceExtension serviceExtension,
                               IHttpContextAccessor httpContextAccessor,
                               IPaidSessionRepo paidSessionRepo,
                               IClassCategoryRepo classCategory)
        {
            _studentRepo = studentRepo ?? throw new ArgumentNullException(nameof(studentRepo));
            _registredClassRepo = registredClassRepo ?? throw new ArgumentNullException(nameof(registredClassRepo));
            _serviceExtension = serviceExtension ?? throw new ArgumentNullException(nameof(registredClassRepo));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _paidSessionRepo = paidSessionRepo ?? throw new ArgumentNullException(nameof(paidSessionRepo));
            _classCategoryRepo = classCategory ?? throw new ArgumentNullException(nameof(classCategory));
        }


        public bool CreateStudentAccount(Student model)
        {

            model.CreatedOn = DateTime.Now;

            var result = _studentRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }



        }

        public bool RegisterClassStudent(RegistredClass model)
        {
            model.CreatedOn = DateTime.Now;
            model.ConfirmedByTeacher = false;
            model.DateRegistered = DateTime.Now;
            var result = _registredClassRepo.Create(model);

            //Email notification for student and Teacher
            // find ways to store list of date and time
            // for Day row and time row

            if (result != model)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public bool UpdateProfile(Student student)
        {
            var result = _studentRepo.Update(student);

            if (result == student)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string UploadReciept(PaidSessionDTO session)
        {
            var imageUrl = _serviceExtension.Upload(session.Image);

            string host = _httpContextAccessor.HttpContext.Request.Host.Value;

            PaidSession model = new PaidSession();

            model.StudentId = session.StudentId;
            model.ClassId = session.ClassId;
            model.PictureLink = host + imageUrl;
            model.PaymentAccepted = null;
            model.DatePaid = DateTime.Now;
            model.PaymentsMonth = session.PaymentsMonth;

            //TODO Email notification for Student and admin and teacher

            if (imageUrl == "Failed")
            {
                return "Failed";
            }
            else
            {
                var result = _paidSessionRepo.Create(model);

                return "Success";
            }

        }
        public IQueryable<Student> GetProfileStudent(Guid guid)
        {
            var result = _studentRepo.FindByCondition(x => x.StudentId == guid);

            return result;

        }

        

    }
}
