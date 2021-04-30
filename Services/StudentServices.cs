using ACMS.DAL.Models;
using APIACMS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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
        private readonly ITeacherRepo _teacherRepo;
        private readonly IAvailableClassRepo  _availableClassRepo;
        private readonly IPaymentMethodRepo  _paymentMethodRepo;




        public StudentServices(IStudentRepo studentRepo,
                               IRegistredClassRepo registredClassRepo,
                               IServiceExtension serviceExtension,
                               IHttpContextAccessor httpContextAccessor,
                               IPaidSessionRepo paidSessionRepo,
                               IClassCategoryRepo classCategory,
                               ITeacherRepo teacherRepo,
                               IAvailableClassRepo availableClassRepo,
                               IPaymentMethodRepo paymentMethodRepo)
        {
            _studentRepo = studentRepo ?? throw new ArgumentNullException(nameof(studentRepo));
            _registredClassRepo = registredClassRepo ?? throw new ArgumentNullException(nameof(registredClassRepo));
            _serviceExtension = serviceExtension ?? throw new ArgumentNullException(nameof(registredClassRepo));
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            _paidSessionRepo = paidSessionRepo ?? throw new ArgumentNullException(nameof(paidSessionRepo));
            _classCategoryRepo = classCategory ?? throw new ArgumentNullException(nameof(classCategory));
            _teacherRepo = teacherRepo ?? throw new ArgumentNullException(nameof(teacherRepo));
            _availableClassRepo = availableClassRepo ?? throw new ArgumentNullException(nameof(availableClassRepo));
            _paymentMethodRepo = paymentMethodRepo ?? throw new ArgumentNullException(nameof(paymentMethodRepo));
        }


        public bool CreateStudentAccount(Student model)
        {

            model.CreatedOn = DateTime.Now;

            var result = _studentRepo.Create(model);
            //email confirmation is on client side
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
            model.FullyPaid = false;
            model.DateRegistered = DateTime.Now;
   
            var result = _registredClassRepo.Create(model);


            var student = _studentRepo.FindByConditionWithFKData(x => x.StudentId == model.StudentId);
            var classObject = _availableClassRepo.FindByCondition(x => x.ClassId == model.ClassId).FirstOrDefault();
            var catObject = _classCategoryRepo.FindByCondition(x => x.CategoryId == model.CategoryId).FirstOrDefault();
            var paymentMethod = _paymentMethodRepo.FindByCondition(x => x.PaymentMethodId == model.PaymentMethodId).FirstOrDefault();
            var teacherObject = _teacherRepo.FindByConditionWithFKData(x => x.TeacherId == classObject.TeacherId);
            
            var registrationReply = new EmailDto();
            registrationReply.Body = _serviceExtension.CreateRegistrationReplyHTML(student.FirstName +" "+ student.LastName, teacherObject.FirstName, classObject.ClassName, teacherObject.User.Email, teacherObject.User.PhoneNumber);
            //registrationReply.Body = "Dear Student, <br><br> <h1> Thank you</h1>";
            registrationReply.To = student.User.Email;
            registrationReply.Subject = "ACMS Class Registration";
            registrationReply.Cc = teacherObject.User.Email;
            _serviceExtension.Send(registrationReply);
            
             // find ways to store list of date and time
            // for Day row and time row

            if (result != model)
            {
                return false;
            }
            else
            {
                decimal amount = new decimal();
                if (catObject.DiscountedFee == 0) { amount = catObject.TotalTutionFee.Value; } else { amount = catObject.DiscountedFee.Value; };
                amount = Math.Round((decimal)(amount /paymentMethod.Terms), 2);
                var invoice =new EmailDto();
                invoice.Body = _serviceExtension.CreateInvoice(student.FirstName+" "+student.LastName,teacherObject.FirstName,catObject.CategoryName,amount.ToString(),paymentMethod.MethodName+"-"+paymentMethod.Terms+"Terms");
                invoice.To = student.User.Email;
                invoice.Subject = "ACMS Class Invoice";
                invoice.Cc = teacherObject.User.Email;
                _serviceExtension.Send(invoice);
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

        public string UploadReciept(PaidSessionDTOs session)
        {
            var imageUrl = _serviceExtension.Upload(session);

            string host = "https://"+_httpContextAccessor.HttpContext.Request.Host.Value+"/";


            var registredClassObject = _registredClassRepo.FindAllByConditionWithFKData(x => x.RegistredClassId == new Guid(session.RegistredClassId));
            var studentObject = _studentRepo.FindByConditionWithFKData(x => x.StudentId == registredClassObject.FirstOrDefault().StudentId);
            var teacherObject = _availableClassRepo.FindByConditionWithFKData(x => x.ClassId == registredClassObject.FirstOrDefault().Class.ClassId);

            PaidSession model = new PaidSession();

            //model.StudentId = session.StudentId;
            model.RegistredClassId = new Guid(session.RegistredClassId);
            model.CreatedOn = DateTime.Now;
            //model.ClassId = session.ClassId;
            model.PictureLink = host + imageUrl;
            model.PaymentAccepted = null;
            model.DatePaid = DateTime.Now;
            model.PaymentsMonth = session.PaymentsMonth;

            //TODO Email notification for Student and admin and teacher
            var registrationReply = new EmailDto();
            registrationReply.Body = _serviceExtension.CreateUploadReieptReplyHTML();
            registrationReply.To = studentObject.User.Email;
            registrationReply.Subject = "ACMS Class Payment";
            registrationReply.Cc = teacherObject.Teacher.User.Email;
            _serviceExtension.Send(registrationReply);


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
        public Student GetProfileStudent(Guid guid)
        {
            var result = _studentRepo.FindByCondition(x => x.StudentId == guid).FirstOrDefault();

            return result;

        }
        public Student GetProfileStudentUser(int id)
        {
            var result = _studentRepo.FindByCondition(x => x.UserId == id).FirstOrDefault();

            return result;

        }

        public IQueryable<ClassCategory> GetAvailableClassCategory()
        {
            var result = _classCategoryRepo.FindAll();
            
            return result;
        
        }

        public List<AvailableClass> GetAvailableClass()
        {
            var result = _availableClassRepo.FindAllWithFKData();
            
            return result;

        }
        public IQueryable<PaymentMethod> GetPaymentMethod()
        {
            var result = _paymentMethodRepo.FindAll();

            return result;

        }
        public IQueryable<RegistredClass> GetStudentRegistredClass(Guid id)
        {
            var result = _registredClassRepo.FindAllByConditionWithFKData(x=>x.StudentId == id);

            return result;

        }
        public IQueryable<RegistredClass> GetStudentRegistredClassNotFullyPaid(Guid id)
        {
            var result = _registredClassRepo.FindAllByConditionWithFKData(x => x.StudentId == id && x.FullyPaid == null || false);

            return result;

        }

        public IQueryable<PaidSession> GetStudentPaidSessionWithFKData(Guid id)
        {
            var result = _paidSessionRepo.FindAllByConditionWithFkData(x => x.RegistredClass.StudentId == id);

            return result;

        }


    }
}
