using System;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sim_Library;
using Sim_Library.BUS;
using Sim_Library.DAO;
using Sim_Web.pages.interfaces;
namespace Sim_Web.pages
{
    public partial class KhachHang : Page
    {
        Sim_Library.BUS.KhBus _khBus = new Sim_Library.BUS.KhBus();
        SimBus _simBus = new SimBus();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_gvKh();

            }
        }

        private void Load_gvKh()
        {
            gvKh.DataSource = _khBus.TatCa();
            gvKh.DataBind();
        }
        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            try
            {
                _khBus.Them(new Kh()
                {
                    TenKh = txtHoTen.Text.Trim(),
                    ChucVu = txtChucVu.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    NgheNghiep = txtNgheNhgiep.Text.Trim()
                });
                lbShowStatus.Text = "Thêm thành công";
            }
            catch (Exception ex)
            {
                lbShowStatus.Text = "Thêm thất bại";
            }
            Load_gvKh();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearControl(this);
        }
        private void ClearControl(Control control)
        {
            var textbox = control as TextBox;
            if (textbox != null)
                textbox.Text = string.Empty;

            var dropDownList = control as DropDownList;
            if (dropDownList != null)
                dropDownList.SelectedIndex = 0;

            foreach (Control childControl in control.Controls)
            {
                ClearControl(childControl);
            }
        }
        private void Load_gvSims(int maKh)
        {
            gvSims.DataSource = _simBus.TatCa().Where(m => m.HdDk.MaKh == maKh);
            gvSims.DataBind();
        }
        protected void gvKh_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var row = gvKh.Rows[e.RowIndex];
            int maKh = int.Parse(row.Cells[1].Text);
            _khBus.Xoa(_khBus.TatCa().FirstOrDefault(m => m.MaKh == maKh));
            Load_gvKh();
        }

        protected void gvSims_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //var row = gv.Rows[e.NewSelectedIndex];
            //var index = GridViewHelper.GetColumnIndexByName(row, "MaHd");
            //var maKh = int.Parse(row.Cells[index].Text);
            //Load_gvSims(maKh);
        }

        protected void gvKh_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            var row = gvKh.Rows[e.NewSelectedIndex];
            var index = GridViewHelper.GetColumnIndexByName(row, "MaKh");
            var maKh = int.Parse(row.Cells[index].Text);
            Load_gvSims(maKh);
        }
    }
}