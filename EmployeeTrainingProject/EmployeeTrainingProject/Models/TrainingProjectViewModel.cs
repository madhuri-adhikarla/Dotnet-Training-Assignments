using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTrainingProject.Models
{
    public class TrainingProjectViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<Location> Locations { get; set; }

    }
}