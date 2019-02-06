using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConsumeWebServicesDemo
{
    public partial class demo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitData_Click(object sender, EventArgs e)
        {
            ThomasBayerRef.BLZServicePortTypeClient cl = new ThomasBayerRef.BLZServicePortTypeClient();

            var res = cl.getBank(tb1.Text);
            output.InnerHtml += "BEZEICHNUNG "+res.bezeichnung;

        }
    }
}