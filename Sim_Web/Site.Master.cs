using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sim_Web
{
    public partial class SiteMaster : MasterPage
    {
        public string abc = "<script>alert(123)</script>";
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}