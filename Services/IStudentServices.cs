using ACMS.DAL.Models;

namespace APIACMS.Services
{
    public interface IStudentServices
    {
        public bool CreateStudentAccount(Student model);
    }
}