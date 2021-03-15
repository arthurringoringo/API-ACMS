﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using APIACMS.Repository;

namespace APIACMS.Services
{
    public class AdminServices : IAdminServices
    {
        private readonly IAvailableClassRepo _availableClassRepo;
        private readonly IClassCategoryRepo _classCategoryRepo;
        private readonly IClassReportRepo _classReportRepo;
        private readonly IPaidSessionRepo _paidSessionRepo;
        private readonly IPaymentMethodRepo _paymentMethodRepo;
        private readonly IRegistredClassRepo _registeredClassRepo;
        private readonly ISessionScheduleRepo _sessionScheduledRepo;
        private readonly IStudentRepo _studentRepo;
        private readonly ITeacherRepo _teacherRepo;


        public AdminServices(IAvailableClassRepo availableClassRepo,
            IClassCategoryRepo classCategoryRepo,
            IClassReportRepo classReportRepo,
            IPaidSessionRepo paidSessionRepo,
            IPaymentMethodRepo paymentMethodRepo,
            IRegistredClassRepo registeredClassRepo,
            ISessionScheduleRepo sessionScheduledRepo,
            IStudentRepo studentRepo,
            ITeacherRepo teacherRepo
            )
        {
            _availableClassRepo = availableClassRepo ?? throw new ArgumentNullException(nameof(availableClassRepo));
            _classCategoryRepo = classCategoryRepo ?? throw new ArgumentNullException(nameof(classCategoryRepo));
            _classReportRepo = classReportRepo ?? throw new ArgumentNullException(nameof(classReportRepo));
            _paidSessionRepo = paidSessionRepo ?? throw new ArgumentNullException(nameof(paidSessionRepo));
            _paymentMethodRepo = paymentMethodRepo ?? throw new ArgumentNullException(nameof(paymentMethodRepo));
            _registeredClassRepo = registeredClassRepo ?? throw new ArgumentNullException(nameof(registeredClassRepo));
            _sessionScheduledRepo = sessionScheduledRepo ?? throw new ArgumentNullException(nameof(sessionScheduledRepo));
            _studentRepo = studentRepo ?? throw new ArgumentNullException(nameof(studentRepo));
            _teacherRepo = teacherRepo ?? throw new ArgumentNullException(nameof(teacherRepo));

        }

        public bool CreateAvailableClass(AvailableClass model)
        {
            model.CreatedOn = DateTime.Now;
            model.Deleted = false;
            model.DeletedOn = null;

            var result = _availableClassRepo.Create(model);
            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateClassCategory(ClassCategory model)
        {
            model.CreatedOn = DateTime.Now;
            model.Deleted = false;
            model.DeletedOn = null;

            var result = _classCategoryRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateClassReport(ClassReport model)
        {
            model.CreatedOn = DateTime.Now;

            var result = _classReportRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreatePaymentMethod(PaymentMethod model)
        {
            model.CreatedOn = DateTime.Now;

            var result = _paymentMethodRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateSessionSchedule(SessionSchedule model)
        {
            model.CreatedOn = DateTime.Now;

            var result = _sessionScheduledRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CreateTeacher(Teacher model)
        {
            model.CreatedOn = DateTime.Now;

            var result = _teacherRepo.Create(model);

            if (result == model)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteAvailableClass(AvailableClass model)
        {

            var result = _availableClassRepo.Delete(model);

            return result;
        }

        public bool DeleteClassCategory(ClassCategory model)
        {
            var result = _classCategoryRepo.Delete(model);

            return result;
        }

        public bool DeleteClassReport(ClassReport model)
        {
            var result = _classReportRepo.Delete(model);

            return result;
        }

        public bool DeletePaidSession(PaidSession model)
        {
            var result = _paidSessionRepo.Delete(model);

            return result;
        }

        public bool DeleteRegisteredClass(RegistredClass model)
        {
            var result = _registeredClassRepo.Delete(model);

            return result;
        }

        public bool DeleteSessionSchedule(SessionSchedule model)
        {
            var result = _sessionScheduledRepo.Delete(model);

            return result;
        }

        public bool DeleteStudent(Student model)
        {
            var result = _studentRepo.Delete(model);

            return result;
        }

        public bool DeleteTeacher(Teacher model)
        {
            var result = _teacherRepo.Delete(model);

            return result;
        }

        public IQueryable<AvailableClass> GetAvailableClasses()
        {
            var result = _availableClassRepo.FindAll();

            return result;
        }

        public IQueryable<AvailableClass> GetAvailableClassesByCondition(Expression<Func<AvailableClass, bool>> expression)
        {
            var result = _availableClassRepo.FindByCondition(expression);

            return result;
        }

        public AvailableClass GetAvailableClassesWithExpressionAndFkData(Guid id)
        {
            var result = _availableClassRepo.FindByConditionWithFKData(x => x.ClassId == id);

            return result;
        }

        public IQueryable<ClassCategory> GetClassCategory()
        {
            var result = _classCategoryRepo.FindAll();

            return result;
        }

        public IQueryable<ClassCategory> GetClassCategoryByCondition(Expression<Func<ClassCategory, bool>> expression)
        {
            var result = _classCategoryRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<ClassReport> GetClassReport()
        {
            var result = _classReportRepo.FindAll();

            return result;
        }

        public IQueryable<ClassReport> GetClassReportByCondition(Expression<Func<ClassReport, bool>> expression)
        {
            var result = _classReportRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<PaidSession> GetPaidSession()
        {
            var result = _paidSessionRepo.FindAll();

            return result;
        }

        public IQueryable<PaidSession> GetPaidSessionByCondition(Expression<Func<PaidSession, bool>> expression)
        {
            var result = _paidSessionRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<RegistredClass> GetRegistredClass()
        {
            var result = _registeredClassRepo.FindAll();

            return result;
        }

        public IQueryable<RegistredClass> GetRegistredClassByCondition(Expression<Func<RegistredClass, bool>> expression)
        {
            var result = _registeredClassRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<SessionSchedule> GetSessionSchedule()
        {
            var result = _sessionScheduledRepo.FindAll();

            return result;
        }

        public IQueryable<SessionSchedule> GetSessionScheduleByCondition(Expression<Func<SessionSchedule, bool>> expression)
        {
            var result = _sessionScheduledRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<Student> GetStudent()
        {
            var result = _studentRepo.FindAll();

            return result;
        }

        public IQueryable<Student> GetStudentByCondition(Expression<Func<Student, bool>> expression)
        {
            var result = _studentRepo.FindByCondition(expression);

            return result;
        }

        public IQueryable<Teacher> GetTeacher()
        {
            var result = _teacherRepo.FindAll();

            return result;
        }

        public IQueryable<Teacher> GetTeacherByCondition(Expression<Func<Teacher, bool>> expression)
        {
            var result = _teacherRepo.FindByCondition(expression);

            return result;
        }

        public bool UpdateAvailableClass(AvailableClass model)
        {
            var result = _availableClassRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateClassCategory(ClassCategory model)
        {
            var result = _classCategoryRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateClassReport(ClassReport model)
        {
            var result = _classReportRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdatePaidSession(PaidSession model)
        {
            var result = _paidSessionRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateRegisteredClass(RegistredClass model)
        {
            var result = _registeredClassRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateSessionSchedule(SessionSchedule model)
        {
            var result = _sessionScheduledRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateStudent(Student model)
        {
            var result = _studentRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTeacher(Teacher model)
        {
            var result = _teacherRepo.Update(model);

            if (result == model)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //bisnis logic
    }
}