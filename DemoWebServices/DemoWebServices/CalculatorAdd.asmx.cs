using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace DemoWebServices
{
    /// <summary>
    /// Summary description for CalculatorAdd
    /// </summary>
    [WebService(Namespace = "http://calculatorwebservice.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CalculatorAdd : System.Web.Services.WebService
    {
       
        [WebMethod(EnableSession = true)]
 
        public int Add(int num1 , int num2)
        {
            List<string> calc;
            if (Session["CALCULATIONS"] == null)
            {
                calc = new List<string>();
            } else
            {
                calc = (List<string>)Session["CALCULATIONS"];
            }

            string res = num1.ToString() + "+" + num2.ToString() + "=" + (num1 + num2).ToString();
            calc.Add(res);
            Session["CALCULATIONS"] = calc;
            return num1+num2;
        }

        [WebMethod(EnableSession = true)]
        public List<string> getCalculations()
        {
           if(Session["CALCULATIONS"] == null)
            {
                List<string> cal = new List<string>();
                cal.Add("no calculations");
                return cal;
            }
            else
            {

                return (List<string>)Session["CALCULATIONS"];
            }

        }

    }
}
