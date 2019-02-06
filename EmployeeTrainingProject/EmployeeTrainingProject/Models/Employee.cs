using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeTrainingProject.Models
{
    public class Employee
    { 
        public int Id { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="Length cannot exceed 20 characters")]
        [RegularExpression("^[a-zA-Z]*", ErrorMessage = "Name entered is not proper")]
        public string Name { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [Required]
        public int LocationID { get; set; }

        public Department Department { get; set; }
    }
}