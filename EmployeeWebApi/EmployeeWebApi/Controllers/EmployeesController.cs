using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer;
using EmployeeModel;
using IBLL;

namespace EmployeeWebApi.Controllers
{
    public class EmployeesController : ApiController
    {

        private IEmployeeDetails iempDetails = null;
        public EmployeesController(GetEmployeeDetails empDetails)
        {
            
        }

        public EmployeesController()
        {
            iempDetails = new GetEmployeeDetails();

        }

        [System.Web.Http.HttpGet]
        public HttpResponseMessage SearchResults(DeptModel deptModel)
        { 
         //  var result = iempDetails.searchdetails(deptModel);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        //public HttpResponseMessage Get(int id)
        //{
        //    EmployeeDBEntities entity = new EmployeeDBEntities();
        //    EmployeeDetail em = entity.EmployeeDetails.FirstOrDefault(e => e.id == id);
        //    if (em == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound, "no employee with the give ID");
        //    }
        //    else
        //    {
        //        return Request.CreateResponse(HttpStatusCode.OK, em.name);
        //    }

        //}
    }
}
