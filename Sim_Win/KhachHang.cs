using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;

namespace PhoneChargesManager
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        SimModelDataContext db = new SimModelDataContext();
        private void KhachHang_Load(object sender, EventArgs e)
        {

            View(dtgv_KH);
        }
        public void View( DataGridView data)
        {
            data.DataSource = from a in db.Khs
                              select new
                              {
                                  Mã_Khách_Hàng = a.MaKh,
                                  Tên_Khách_Hàng = a.TenKh,
                                  Nghề_Nghiệp = a.NgheNghiep,
                                  Chức_Vụ = a.ChucVu,
                                  Địa_Chỉ = a.DiaChi,
                              };
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Kh kh = new Kh();
            int makh = Convert.ToInt32(dtgv_KH.SelectedCells[0].OwningRow.Cells["Mã_Khách_Hàng"].Value.ToString());
            kh = db.Khs.Where(p => p.MaKh.Equals(makh)).SingleOrDefault();
            db.Khs.DeleteOnSubmit(kh);
            db.SubmitChanges();
            KhachHang_Load(sender, e);


        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void dtgv_KH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            string tenkh = txt_TenKH.Text;
            string nnghiep = txt_NN.Text;
            string cvu = txt_CV.Text;
            string dchi = txt_DC.Text;

            Kh add = new Kh();
          
                    add.TenKh = tenkh;
                    add.NgheNghiep = nnghiep;
                    add.ChucVu = cvu;
                    add.DiaChi = dchi;
                    db.Khs.InsertOnSubmit(add);
                    db.SubmitChanges();
            KhachHang_Load(sender, e);
            Clear();
        }
        private void Clear()
        {
            Action<Control.ControlCollection> function = null;
            function = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        function(control.Controls);

            };
            function(Controls);
        }

        private void dtgv_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_KH.CurrentRow.Selected = true;
            txt_TenKH.Text = dtgv_KH.Rows[e.RowIndex].Cells["Tên_Khách_Hàng"].FormattedValue.ToString();
            txt_NN.Text = dtgv_KH.Rows[e.RowIndex].Cells["Nghề_Nghiệp"].FormattedValue.ToString();
            txt_CV.Text = dtgv_KH.Rows[e.RowIndex].Cells["Chức_Vụ"].FormattedValue.ToString();
            txt_DC.Text = dtgv_KH.Rows[e.RowIndex].Cells["Địa_Chỉ"].FormattedValue.ToString();


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int makh =Convert.ToInt32(dtgv_KH.SelectedCells[0].OwningRow.Cells["Mã_Khách_Hàng"].Value.ToString());
            string tenkh = txt_TenKH.Text;
            string nnghiep = txt_NN.Text ;
            string cvu = txt_CV.Text; 
            string dchi = txt_DC.Text; 
            Kh edit = db.Khs.Where(p => p.MaKh.Equals(makh)).SingleOrDefault();
            edit.TenKh = tenkh;
            edit.NgheNghiep = nnghiep;
            edit.ChucVu = cvu;
            edit.DiaChi = dchi;

            db.SubmitChanges();
            KhachHang_Load(sender, e);
            Clear();
        }

        public void Find(DataGridView data,string test)
        {
            data.DataSource = from b in db.Khs
                              where b.TenKh==test || b.NgheNghiep== test || b.ChucVu== test
                              select new
                              {
                                  Mã_Khách_Hàng = b.MaKh,
                                  Tên_Khách_Hàng = b.TenKh,
                                  Nghề_Nghiệp = b.NgheNghiep,
                                  Chức_Vụ = b.ChucVu,
                                  Địa_Chỉ = b.DiaChi,
                              };
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            Find(dtgv_KH, txt_Find.Text);
            Clear();

        }
    }
}
