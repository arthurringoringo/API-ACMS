using ACMS.DAL.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace APIACMS.Services
{
    public interface IAdminServices
    {
        // Create

        public bool CreateAvailableClass(AvailableClass model);

        public bool CreateClassCategory(ClassCategory model);
        public bool CreateClassReport(ClassReport model);
        public bool CreatePaymentMethod(PaymentMethod model);
        public bool CreateSessionSchedule(SessionSchedule model);
        public bool CreateTeacher(Teacher model);
       

        //Update && softDelete

        public bool UpdateAvailableClass(AvailableClass model);
        public bool UpdateClassCategory(ClassCategory model);
        public bool UpdateClassReport(ClassReport model);
        public bool UpdatePaidSession(PaidSession model);
        public bool UpdateRegisteredClass(RegistredClass model);
        public bool UpdateSessionSchedule(SessionSchedule model);
        public bool UpdateStudent(Student model);
        public bool UpdateTeacher(Teacher model);






        // HArd Delete

        public bool DeleteAvailableClass(AvailableClass model);
        public bool DeleteClassCategory(ClassCategory model);
        public bool DeleteClassReport(ClassReport model);
        public bool DeletePaidSession(PaidSession model);
        public bool DeleteRegisteredClass(RegistredClass model);
        public bool DeleteSessionSchedule(SessionSchedule model);
        public bool DeleteStudent(Student model);
        public bool DeleteTeacher(Teacher model);


        //Get

        public IQueryable<AvailableClass> GetAvailableClasses();
        public IQueryable<AvailableClass> GetAvailableClassesByCondition(Expression<Func<AvailableClass, bool>> expression);

        public IQueryable<ClassCategory> GetClassCategory();
        public IQueryable<ClassCategory> GetClassCategoryByCondition(Expression<Func<ClassCategory, bool>> expression);

        public IQueryable<ClassReport> GetClassReport();
        public IQueryable<ClassReport> GetClassReportByCondition(Expression<Func<ClassReport, bool>> expression);

        public IQueryable<PaidSession> GetPaidSession();
        public IQueryable<PaidSession> GetPaidSessionWithFk();
        public IQueryable<PaidSession> GetPaidSessionByCondition(Expression<Func<PaidSession, bool>> expression);

        public IQueryable<RegistredClass> GetRegistredClass();
        public IQueryable<RegistredClass> GetRegistredClassByCondition(Expression<Func<RegistredClass, bool>> expression);

        public IQueryable<SessionSchedule> GetSessionSchedule();
        public IQueryable<SessionSchedule> GetSessionScheduleByCondition(Expression<Func<SessionSchedule, bool>> expression);

        public IQueryable<Student> GetStudent();
        public IQueryable<Student> GetStudentByCondition(Expression<Func<Student, bool>> expression);

        public IQueryable<Teacher> GetTeacher();
        public IQueryable<Teacher> GetTeacherByCondition(Expression<Func<Teacher, bool>> expression);

        public AvailableClass GetAvailableClassesWithExpressionAndFkData(Guid id);
        public ClassCategory GetClassCategoryWithExpressionAndFkData(Guid id);
        public PaidSession GetPaidSessionWithExpressionAndFkData(Guid id);
        public IQueryable<PaymentMethod> GetPaymentMethods();
        public PaymentMethod GetPaymentMethodWithExpressionAndFkData(Guid id);
        public RegistredClass GetRegistredClassWithExpressionAndFkData(Guid id);
        public SessionSchedule GetSessionSchedulesWithExpressionAndFkData(Guid id);
        public Student GetStudentsWithExpressionAndFkData(Guid id);
        public Teacher GetTeacherWithExpressionAndFkData(Guid id);

        //
        //BissLogic
    }
}