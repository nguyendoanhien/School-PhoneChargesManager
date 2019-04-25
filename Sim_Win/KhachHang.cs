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
            txbPhi.Text = "50000";
            LoadCombo();
        }
        SimModelDataContext db = new SimModelDataContext();
        private void KhachHang_Load(object sender, EventArgs e)
        {
            View(dtgv_KH);
        }
        private void LoadCombo()
        {
            var s = from p in db.Sims where p.TrangThai == false select new { p.SoSim };
            cbxSosim.DataSource = s;
            cbxSosim.DisplayMember = "SoSim";
            cbxSosim.ValueMember = "SoSim";
        }
        public void View( DataGridView data)
        {
            data.DataSource = from a in db.Khs
                              select new
                              {
                                  ID = a.MaKh,
                                  Name = a.TenKh,
                                  Work = a.NgheNghiep,
                                  Post= a.ChucVu,
                                  Address = a.DiaChi,
                                  Email = a.Email
                              };
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Kh kh = new Kh();
            int makh = Convert.ToInt32(dtgv_KH.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
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
            try
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
                add.Email = tbxEmail.Text;
                db.Khs.InsertOnSubmit(add);
                db.SubmitChanges();
                KhachHang_Load(sender, e);
                Clear();
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc đã tồn tại!");
            }
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
            txbPhi.Text = "50000";
        }

        private void dtgv_KH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_KH.CurrentRow.Selected = true;
            txt_TenKH.Text = dtgv_KH.Rows[e.RowIndex].Cells["Name"].FormattedValue.ToString();
            txt_NN.Text = dtgv_KH.Rows[e.RowIndex].Cells["Work"].FormattedValue.ToString();
            txt_CV.Text = dtgv_KH.Rows[e.RowIndex].Cells["Post"].FormattedValue.ToString();
            txt_DC.Text = dtgv_KH.Rows[e.RowIndex].Cells["Address"].FormattedValue.ToString();
            tbxEmail.Text = dtgv_KH.Rows[e.RowIndex].Cells["Email"].FormattedValue.ToString();


        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int makh = Convert.ToInt32(dtgv_KH.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
                string tenkh = txt_TenKH.Text;
                string nnghiep = txt_NN.Text;
                string cvu = txt_CV.Text;
                string dchi = txt_DC.Text;
                Kh edit = db.Khs.Where(p => p.MaKh.Equals(makh)).SingleOrDefault();
                if (tenkh != "" && nnghiep != "" && cvu != "" && dchi != "" && tbxEmail.Text != "")
                {
                    edit.TenKh = tenkh;
                    edit.NgheNghiep = nnghiep;
                    edit.ChucVu = cvu;
                    edit.DiaChi = dchi;
                    edit.Email = tbxEmail.Text;

                    db.SubmitChanges();
                    KhachHang_Load(sender, e);
                    Clear();
                }
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin vừa nhập!");
            }
        }

        public void Find(DataGridView data,string test)
        {

            data.DataSource = from b in db.Khs
                              where b.TenKh==test || b.NgheNghiep== test || b.ChucVu== test
                              select new
                              {
                                  ID = b.MaKh,
                                  Name = b.TenKh,
                                  Work = b.NgheNghiep,
                                  Post= b.ChucVu,
                                  Address = b.DiaChi,
                                  Email = b.Email
                              };
        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            Find(dtgv_KH, txt_Find.Text);
            Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                HdDk dk = new HdDk();
                dk.MaKh = Convert.ToInt32(dtgv_KH.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
                dk.ChiPhiDk = txbPhi.Text;
                db.HdDks.InsertOnSubmit(dk);
                db.SubmitChanges();

                Sim newsim = db.Sims.Where(p => p.SoSim.Equals(cbxSosim.Text)).SingleOrDefault();
                newsim.MaHdDk = Convert.ToInt32(db.HdDks.Max(q => q.MaHdDk));
                newsim.TrangThai = true;
                db.SubmitChanges();
                LoadCombo();
                MessageBox.Show("Đăng kí thành công!");
            }
            catch
            {
                MessageBox.Show("Thông tin nhập vào lỗi!");
            }
        }
    }
}
