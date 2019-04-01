using System;
using System.Drawing;
using System.Web.UI;
using Sim_Library.DAO;
using Sim_Web.pages.interfaces;
namespace Sim_Web.pages
{
    public partial class KhachHang : Page
    {
        Sim_Library.BUS.Kh _khBus = new Sim_Library.BUS.Kh();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


            }
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            _khBus.Them(new Kh()
            {
                TenKh = txtHoTen.Text.Trim(),
                ChucVu = txtChucVu.Text.Trim(),
                DiaChi = txtDiaChi.Text.Trim(),
                NgheNghiep = txtNgheNhgiep.Text.Trim()
            });
        }

     
    }
}