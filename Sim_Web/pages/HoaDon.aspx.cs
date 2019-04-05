using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Sim_Library;
using Sim_Library.BUS;
using Sim_Library.DAO;
using Sim_Library.SimLogs;

namespace Sim_Web.pages
{
    public partial class HoaDon : Page
    {
        private readonly KhBus _khBus = new KhBus();
        private readonly HdBus _hdBus = new HdBus();
        private readonly SdBus _sdBus = new SdBus();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void gvHoaDonChiTiet_GetData(int maHd)
        {
            gvHoaDonChiTiet.DataSource = _sdBus.TatCa().Where(m => m.MaHd == maHd);
            gvHoaDonChiTiet.DataBind();
        }

        protected void btnLogSms_Click(object sender, EventArgs e)
        {
            var dskq = from sd in SimHelper.ReadFromTextLog()
                       select new
                       {
                           sd.MaSim,
                           sd.TgBd,
                           sd.TgKt,
                           MaKh = sd.Sim?.HdDk != null ? sd.Sim.HdDk.MaKh + "" : ""
                       };
            gvLogSms.DataSource = dskq;
            gvLogSms.DataBind();

            rdlKh.DataSource = (from kh in _khBus.TatCa()
                                join kq in dskq.Where(m => m.MaKh != "") on kh.MaKh equals int.Parse(kq.MaKh)
                                select new { kh.MaKh, kh.TenKh }).Distinct();
            rdlKh.DataTextField = "MaKh";
            rdlKh.DataValueField = "MaKh";
            rdlKh.DataBind();
            drlLogSmsKh_GetData();
        }

        private void drlLogSmsKh_GetData()
        {
            if (rdlKh.SelectedIndex <= -1) return;
            var maKh = int.Parse(rdlKh.SelectedValue);
            var kq = from sd in SimHelper.ReadFromTextLog().Where(m => m.Sim != null)
                     where sd.Sim.HdDk.MaKh == maKh
                     select new
                     {
                         sd.MaSim,
                         sd.TgBd,
                         sd.TgKt,
                         Money = $"{SimHelper.CaculateSmsMoney(new List<Sd> { sd }):n0}"
                     };


            if (ViewState["vsLogSmsKh"] != null && JsonConvert.SerializeObject(kq) == (string)ViewState["vsLogSmsKh"])
            {
                var data = (string)ViewState["vsLogSmsKh"];
                var definition = new[] { new { MaSim = 0, TgBd = new DateTime(), TgKt = new DateTime(), Money = "0" } };
                var dynObject = JsonConvert.DeserializeAnonymousType(data, definition);

                gvLogSmsKh.DataSource = dynObject;
            }
            else
            {
                var data = JsonConvert.SerializeObject(kq);
                gvLogSmsKh.DataSource = kq;
                ViewState["vsLogSmsKh"] = data;
            }


            gvLogSmsKh.DataBind();
        }

        private void gvHoaDon_GetData()
        {
            gvHoaDon.DataSource = _hdBus.TatCa();
            gvHoaDon.DataBind();
        }

        protected void rdlKh_SelectedIndexChanged(object sender, EventArgs e)
        {
            drlLogSmsKh_GetData();
        }

        protected void btnLapHoaDon_Click(object sender, EventArgs e)
        {
            var data = (string)ViewState["vsLogSmsKh"];
            var definition = new[] { new { MaSim = 0, TgBd = new DateTime(), TgKt = new DateTime(), Money = "0" } };
            var dynObject = JsonConvert.DeserializeAnonymousType(data, definition);

            _hdBus.Them(new Hd { MaKh = int.Parse(rdlKh.SelectedValue) });

            foreach (var m in dynObject)
                _sdBus.Them(new Sd
                {
                    MaSim = m.MaSim,
                    TgBd = m.TgBd,
                    TgKt = m.TgKt,
                    MaHd = _hdBus.TatCa().Last().MaHd
                });
        }

        protected void btnHoaDon_Click(object sender, EventArgs e)
        {
            gvHoaDon_GetData();
        }

        protected void gvHoaDon_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var row = gvHoaDon.Rows[e.NewSelectedIndex];
            var index = GridViewHelper.GetColumnIndexByName(row, "MaHd");
            var maHd = int.Parse(row.Cells[index].Text);
            gvHoaDonChiTiet_GetData(maHd);
        }
    }
}