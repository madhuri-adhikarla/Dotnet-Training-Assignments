using System;
using System.Collections.Generic;
using System.Text;
using EmployeeDataAccess;
using IBLL;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Web;
using EmployeeModel;

namespace BusinessLayer
{
    //public class GetEmployeeDetails : IEmployeeDetails
    //{
    //    List<EmployeeDetail> l = new List<EmployeeDetail>();
    //    IEnumerable<EmployeeDetail> ee;
    //    public List<EmployeeDetail> searchdetails(string departmentName, string locationName)
    //    {
    //        EmployeeDBEntities entity = new EmployeeDBEntities();
    //        var deptIdObtained = entity.Departments.FirstOrDefault(d => d.deptName == departmentName);
    //      //  l.All(emp => emp.deptId.ToString() == deptIdObtained.ToString());
    //        ee = from m in entity.EmployeeDetails
    //             where m.deptId.Equals(deptIdObtained)
    //             select m;
    //        foreach (IEnumerable<EmployeeDetail> item in ee)
    //        {
    //            l.Add(item);
    //        }
    //        return l;
    //    }

       
    //}

    public class GetEmployeeDetails : IEmployee
    {
        private EmployeeDBEntities empDbEntity = null;

        public GetEmployeeDetails()
        {
            empDbEntity = new EmployeeDBEntities();
        }

        public IEnumerable<EmpModel> Employees()
        {
            return empDbEntity.EmployeeDetails.Select(e => new EmpModel
            {
                Name = e.name,
                Id=e.id,
                Salary=e.salary??-1,
                LocationId=e.locationId??-1,
                DeptId=e.deptId??-1
            });
        }

        public IEnumerable<EmpModel> searchdetails(int deptId)
        {
            IEnumerable<EmpModel> list = empDbEntity.EmployeeDetails.Where(e=>e.deptId==deptId).Select(e => new EmpModel {
                Id = e.id,
                Name = e.name,
                DeptId = e.Department.deptId,
                LocationId = e.Location.locationId,
                Salary = e.salary ?? -1
            });
            return list;
           
        }

        
    }
}
