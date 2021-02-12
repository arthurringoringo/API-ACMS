using System;
using System.Collections.Generic;

#nullable disable

namespace APIACMS.Infrastructure.Models
{
    public partial class ClassReport
    {
        public ClassReport()
        {
            RegistredClasses = new HashSet<RegistredClass>();
        }

        public string ClassReportId { get; set; }
        public string Remarks { get; set; }

        public virtual ICollection<RegistredClass> RegistredClasses { get; set; }
    }
}
