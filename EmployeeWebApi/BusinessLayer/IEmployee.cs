using EmployeeModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IEmployee
    {
        IEnumerable<EmpModel> searchdetails(int DeptId);
        IEnumerable<EmpModel> Employees();
    }
}
