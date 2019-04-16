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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
            LayDanhSach();
        }
        SimModelDataContext db = new SimModelDataContext();

        public void LayDanhSach()
        {
            Data.DataSource = from p in db.Hds
                              select new
                              {
                                  Mã_hóa_đơn = p.MaHd,
                                  Mã_khách = p.MaKh,
                                  Tổng_tiền = p.TongTien
                              };
        }
        private void Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Data.CurrentCell.Selected = true;
                TbxMahd.Text = Data.Rows[e.RowIndex].Cells["Mã_hóa_đơn"].FormattedValue.ToString();
            }
            catch
            {
                MessageBox.Show("Không chọn được!");
            }
        }

        private void BtnTimmhd_Click(object sender, EventArgs e)
        {
            try
            {
                Data.DataSource = from p in db.Sds
                                  from q in db.Sims
                                  from k in db.Khs
                                  from h in db.Hds
                                  where p.MaHd == Convert.ToInt32(TbxMahd.Text) &&
                                  p.MaSim == q.MaSim && h.MaHd == Convert.ToInt32(TbxMahd.Text) && k.MaKh == h.MaKh
                                  select new
                                  {
                                      Mã_sử_dụng = p.MaSd,
                                      Số_SIM = q.SoSim,
                                      Khách_hàng = k.TenKh,
                                      Thời_gian_sử_dụng = p.TgKt - p.TgBd,
                                      Tổng_tiền = p.TongTien
                                  };
            }
            catch
            {
                MessageBox.Show("Chọn hóa đơn cần xem!");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            LayDanhSach();
            this.TbxMahd.Clear();
        }

        private void BtnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
