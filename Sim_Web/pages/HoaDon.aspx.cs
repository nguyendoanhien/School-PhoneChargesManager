using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;
using Sim_Library.BUS;
using Sim_Library.DAO;
using Sim_Library.SimLogs;

namespace Sim_Web.pages
{
    public partial class HoaDon : System.Web.UI.Page
    {
        KhBus _khBus = new KhBus();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void rdlKh_Load()
        {


        }
        protected void btnLogSms_Click(object sender, EventArgs e)
        {
            var dskq = from sd in SimHelper.ReadFromTextLog()
                       select new
                       {
                           sd.MaSim,
                           sd.TgBd,
                           sd.TgKt,
                           MaKh = (sd.Sim != null) ? sd.Sim.MaKh + "" : "",
                       };
            gvLogSms.DataSource = dskq;
            gvLogSms.DataBind();

            rdlKh.DataSource = (from kh in _khBus.TatCa()
                                join kq in dskq.Where(m => m.MaKh != "") on kh.MaKh equals int.Parse(kq.MaKh)
                                select new { MaKh = kh.MaKh, TenKh = kh.TenKh }).Distinct();
            rdlKh.DataTextField = "TenKh";
            rdlKh.DataValueField = "MaKh";
            rdlKh.DataBind();

        }



        protected void rdlKh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int maKh = int.Parse(((DropDownList)sender).SelectedValue);
            var kq = from sd in SimHelper.ReadFromTextLog().Where(m => m.Sim != null)
                     where sd.Sim.MaKh == maKh
                     select new
                     {
                         sd.MaSim,
                         sd.TgBd,
                         sd.TgKt,
                         Money = String.Format("{0:n0}", SimHelper.CaculateSmsMoney(new List<Sd>() { sd }))
                     };

            gvLogSmsKh.DataSource = kq;
            gvLogSmsKh.DataBind();
        }
    }
}