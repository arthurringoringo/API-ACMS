using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using APIACMS.Repository;


namespace APIACMS.Services
{

        public class StudentServices : IStudentServices
    {
        private readonly IStudentRepo _studentRepo;

        public StudentServices(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo ?? throw new ArgumentNullException(nameof(studentRepo));
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
            //TODO Email Confirmation or Email Notification


        }

    }

}
