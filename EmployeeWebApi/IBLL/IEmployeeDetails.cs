using System;
using System.Collections.Generic;
using EmployeeDataAccess;
using System.Net.Http;
using EmployeeModel;

namespace IBLL
{
    public interface IEmployeeDetails
    {
        IEnumerable<EmpModel> searchdetails(int DeptId);
        IEnumerable<EmpModel> Employees();

    }
}
