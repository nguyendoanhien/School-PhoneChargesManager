using DAO;
using Sim_Library.SimLogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Utilities;

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
                              from k in db.Khs
                              where p.MaKh == k.MaKh
                              select new
                              {
                                  ID = p.MaHd,
                                  Name = k.TenKh,
                                  Total = p.TongTien,
                                  Mail = k.Email,
                                  status = p.TrangThai != false ?  "Đã thanh toán" : "Chưa thanh toán"
                              };
        }
        private void Data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Data.CurrentCell.Selected = true;
                string s = Data.Rows[e.RowIndex].Cells["ID"].FormattedValue.ToString();
                TbxMahd.Text = s;
                //string s = Data.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString();
                tbxMail.Text = Data.Rows[e.RowIndex].Cells["Mail"].FormattedValue.ToString();
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
                                  where p.MaHd == System.Convert.ToInt32(TbxMahd.Text) &&
                                  p.MaSim == q.MaSim && h.MaHd == System.Convert.ToInt32(TbxMahd.Text) && k.MaKh == h.MaKh
                                  select new
                                  {
                                      ID = p.MaSd,
                                      NumberPhone = q.SoSim,
                                      Customer = k.TenKh,
                                      Buildday = h.Ngaylap,
                                      Payday = h.Ngaytra,
                                      Time = p.TgKt - p.TgBd,
                                      Total = p.TongTien
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var text = from p in db.Sds
                           from q in db.Sims
                           from k in db.Khs
                           from h in db.Hds
                           where p.MaHd == System.Convert.ToInt32(TbxMahd.Text) &&
                           p.MaSim == q.MaSim && h.MaHd == System.Convert.ToInt32(TbxMahd.Text) && k.MaKh == h.MaKh
                           select new
                           {
                               ID = p.MaSd,
                               NumberPhone = q.SoSim,
                               Customer = k.TenKh,
                               Buildday = h.Ngaylap,
                               Payday = h.Ngaytra,
                               Time = p.TgKt - p.TgBd,
                               Total = p.TongTien
                           };
                if(Data.SelectedCells[0].OwningRow.Cells["Status"].FormattedValue.ToString() != "Đã thanh toán")
                {
                    Email.SendGmail("mygmail@gmail.com", "mypasswd", tbxMail.Text, tbxTitle.Text, text.ToString());

                    MessageBox.Show("Gửi mail thành công!");
                }
                else
                {

                    MessageBox.Show("Hóa đơn đã thanh toán!");
                }
            }
            catch
            {
                MessageBox.Show("Chọn hóa đơn cần xem!");
            }
        }

        /*private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                int d1 = System.Convert.ToInt32(DateStart.Text);
                int d2 = System.Convert.ToInt32(DateEnd.Text);
                int m1 = System.Convert.ToInt32(mothStart.Text);
                int m2 = System.Convert.ToInt32(monthEnd.Text);
                int y1 = System.Convert.ToInt32(yearStart.Text);
                int y2 = System.Convert.ToInt32(yearEnd.Text);

                DateTime dateFrom = new DateTime(y1, m1, d1);
                DateTime dateTo = new DateTime(y2, m2, d2);

                if (dateTo.CompareTo(dateFrom) > 0)
                {
                    Data.DataSource = from s in db.Sds
                                      from h in db.Hds
                                      from k in db.Khs
                                      from _s in db.Sims
                                      where s.TgBd.Value.CompareTo(dateFrom)>=0
                                      && s.TgKt.Value.CompareTo(dateTo)<=0 && k.MaKh == h.MaKh
                                      select new
                                      {
                                          ID = s.MaSd,
                                          NumberPhone = _s.SoSim,
                                          Customer = k.TenKh,
                                          Buildday = h.Ngaylap,
                                          Payday = h.Ngaytra,
                                          Time = s.TgKt - s.TgBd,
                                          Total = s.TongTien
                                      };
                }
                else
                {
                    MessageBox.Show("Kiểm tra lại dữ liệu nhập");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }*/

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Data.SelectedCells[0].OwningRow.Cells["Status"].FormattedValue.ToString() == "Đã thanh toán")
                {
                    MessageBox.Show("Đã cập nhật rồi");
                }
                else
                {
                    //Hd hd = new db.Hds.Where(p => p.SoSim.Equals(cbxSosim.Text)).SingleOrDefault();
                    int a = System.Convert.ToInt32(Data.SelectedCells[0].OwningRow.Cells["ID"].FormattedValue.ToString());
                    Hd h = db.Hds.Where(p => p.MaHd.Equals(a)).SingleOrDefault();
                    h.TrangThai = true;
                    db.SubmitChanges();
                    MessageBox.Show("Cập nhật thành công!");
                    LayDanhSach();
                }
            }
            catch
            {
                MessageBox.Show("Lỗi!");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            //var data = dskq;
            //int tongTien = 0;
            //foreach (var x in data)
            //{
            //    tongTien += int.Parse(x.Money.Replace(",", ""));
            //}
            //Hd.Them(new Hd { MaKh = int.Parse(rdlKh.Selec   tedValue), TongTien = tongTien.ToString() });

            //foreach (var m in dynObject)
            //    _sdBus.Them(new Sd
            //    {
            //        MaSim = m.MaSim,
            //        TgBd = m.TgBd,
            //        TgKt = m.TgKt,
            //        MaHd = _hdBus.TatCa().Last().MaHd,
            //        TongTien = m.Money
            //    });
        }

        private void btnRead_Click(object sender, EventArgs e)
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
            Data.DataSource = dskq.ToList();            
        }

        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        List<DoiTuong> dskq = new List<DoiTuong>();
        private void btnTim_Click(object sender, EventArgs e)
        {
           
        }
    }
    public class DoiTuong
    {
        public Sd sd;
        public string Sosim;
        public DateTime? TgBd;
        public DateTime? TgKt;
        public double Monney;
        public string MaKh;
    }
}
