using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonnelDepartment.ViewModels
{
    public class PersonnelFViewModels
    {
        public IEnumerable<PersonnelDepartment.Models.EntityFramework.Department> Departments { get; set; }
        public PersonnelDepartment.Models.EntityFramework.Personnel Personnel { get; set; }
    }
}