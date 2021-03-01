﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ACMS.DAL.Models;
using ACMS.DAL.DataContext;



namespace APIACMS.Repository
{
    public class StudentRepo : RepositoryBase<Student>, IStudentRepo
    {
        public StudentRepo(APIDbContext _context)
            : base(_context)
        {

        }

        
    }
}
