using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeTrainingProject.Models
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public List<Department> Departments { get; set; }
    }
}