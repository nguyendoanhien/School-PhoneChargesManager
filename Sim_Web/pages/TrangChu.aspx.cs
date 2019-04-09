using System;
using System.Linq;
using System.Web.UI;
using Sim_Library.BUS;
using Sim_Library.SimLogs;

namespace Sim_Web.pages
{
    public partial class TrangChu : Page
    {
        KgBUS _kg = new KgBUS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptBangGia.DataSource = _kg.TatCa().ToList();
                rptBangGia.DataBind();
            }
        }
    }
}