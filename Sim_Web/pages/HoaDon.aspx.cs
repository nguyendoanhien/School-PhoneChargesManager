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
using Utilities;
using Convert = System.Convert;

namespace Sim_Web.pages
{
    public partial class HoaDon : Page
    {
        private readonly KhBus _khBus = new KhBus();
        private readonly HdBus _hdBus = new HdBus();
        private readonly SdBus _sdBus = new SdBus();
        private int selectedReceiptId = -1;
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        private void gvHoaDonChiTiet_GetData(int maHd)
        {

            gvHoaDonChiTiet.DataSource = _sdBus.TatCa().Where(m => m.MaHd == maHd)
                .Select(m=>new
                {m.MaSd,
                 m.MaHd,
                 m.MaSim,
                 m.Sim.SoSim,
                 m.TgBd,
                 m.TgKt,
                 m.TongTien

                })
                .ToList();
            gvHoaDonChiTiet.DataBind();
            if (gvHoaDonChiTiet != null && gvHoaDonChiTiet.Rows.Count > 0)
            {
                lbHoaDonChiTiet.Text = "";
            }
            else
            {
                lbHoaDonChiTiet.Text = "Không có dữ liệu";
            }
        }

        private void gvLogSmsBind()
        {
            var dskq = from sd in SimHelper.ReadFromTextLog()
                       select new
                       {
                           sd.MaSim,
                           sd.Sim.SoSim,
                           sd.TgBd,
                           sd.TgKt,
                           MaKh = sd.Sim?.HdDk != null ? sd.Sim.HdDk.MaKh + "" : ""
                       };
            gvLogSms.DataSource = dskq.ToList();
            gvLogSms.DataBind();

            rdlKh.DataSource = (from kh in _khBus.TatCa()
                                join kq in dskq.Where(m => m.MaKh != "") on kh.MaKh equals int.Parse(kq.MaKh)
                                select new { kh.MaKh, kh.TenKh }).Distinct();
            rdlKh.DataTextField = "MaKh";
            rdlKh.DataValueField = "MaKh";
            rdlKh.DataBind();
            drlLogSmsKh_GetData();

        }
        protected void btnLogSms_Click(object sender, EventArgs e)
        {
            gvLogSmsBind();

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
                         sd.Sim.SoSim,
                         sd.TgBd,
                         sd.TgKt,
                         Money = $"{SimHelper.CaculateSmsMoney(new List<Sd> { sd }):n0}"
                     };


            if (ViewState["vsLogSmsKh"] != null && JsonConvert.SerializeObject(kq) == (string)ViewState["vsLogSmsKh"])
            {
                var data = (string)ViewState["vsLogSmsKh"];
                var definition = new[] { new { MaSim = 0, SoSim = "", TgBd = new DateTime(), TgKt = new DateTime(), Money = "0" } };
                var dynObject = JsonConvert.DeserializeAnonymousType(data, definition);

                gvLogSmsKh.DataSource = dynObject.ToList();
            }
            else
            {
                var data = JsonConvert.SerializeObject(kq);
                gvLogSmsKh.DataSource = kq.ToList();
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
            int tongTien = 0;
            foreach (var x in dynObject)
            {

                tongTien += int.Parse(x.Money.Replace(",", ""));
            }
            _hdBus.Them(new Hd { MaKh = int.Parse(rdlKh.SelectedValue), TongTien = tongTien.ToString() });

            foreach (var m in dynObject)
                _sdBus.Them(new Sd
                {
                    MaSim = m.MaSim,
                    TgBd = m.TgBd,
                    TgKt = m.TgKt,
                    MaHd = _hdBus.TatCa().Last().MaHd,
                    TongTien = m.Money
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
            if (ViewState["selectedMahd"] == null)
                ViewState["selectedMahd"] = maHd;
            gvHoaDonChiTiet_GetData(maHd);
        }


        protected void btnSendMail_Click(object sender, EventArgs e)
        {

            var hd = _hdBus.TatCa().FirstOrDefault(m => m.MaHd == Convert.ToInt32(iptMaHd.Value));
            string chiTietHoaDon = "";
            foreach (var sd in hd.Sd)
            {
                chiTietHoaDon += $"{sd.MaSd} , {sd.TgBd}, {sd.TgKt}, {sd.TongTien} <br/>";
            }



            Email.SendGmail("nomad1234vn@gmail.com", "ma8635047", iptEmail.Value, "Thông báo thanh toán",
                $"Chào {hd.Kh.TenKh} <br/> thông tin hóa đơn {hd.MaHd}<br/>Tổng tiền {hd.TongTien} <br/> Chi tiết hóa đơn <br/>{chiTietHoaDon}");
        }

        protected void btnLogSmsRandom_Click(object sender, EventArgs e)
        {
            SimHelper.GenerateLogs(100);
        }

        protected void gvLogSms_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLogSms.PageIndex = e.NewPageIndex;
            gvLogSmsBind();
        }

        protected void gvHoaDonChiTiet_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvHoaDonChiTiet.PageIndex = e.NewPageIndex;
            gvHoaDonChiTiet_GetData(Convert.ToInt32(ViewState["selectedMahd"]));

        }

        protected void gvLogSmsKh_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvLogSmsKh.PageIndex = e.NewPageIndex;
            drlLogSmsKh_GetData();
        }
    }
}