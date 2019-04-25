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
    public partial class SIM : Form
    {
        public SIM()
        {
            InitializeComponent();
            simnull();
        }
        SimModelDataContext db = new SimModelDataContext();
        public void simnull()
        {
            dgvNull.DataSource = from p in db.Sims
                                 where p.TrangThai == false
                                 select new
                                 {
                                     NumberPhone = p.SoSim,
                                     Status = "Chưa kích hoạt!"
                                 };
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        public void View(DataGridView data)
        {
            data.DataSource = from a in db.Sims
                              from b in db.Khs
                              from c in db.HdDks
                              where a.MaHdDk == c.MaHdDk && b.MaKh == c.MaKh
                              select new 
                              {
                                  ID = a.MaSim,
                                  NumberPhone = a.SoSim,
                                  IDSign = a.MaHdDk,
                                  Customer = b.TenKh
                              };
        }
        private void SIM_Load(object sender, EventArgs e)
        {
            View(dtgv_SIM);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                string sosim = txt_Sosim.Text;
                var test = int.TryParse(sosim, out int n);
                //int mahddk = Convert.ToInt32(txt_MaHDDK.Text);
                if (sosim.Length < 9 || sosim.Length >= 11 || test == false )
                {
                    MessageBox.Show("Số sim không hợp lệ!");
                }
                else
                {
                    Sim add = new Sim();
                    add.SoSim = sosim;
                    add.MaHdDk = null;
                    add.TrangThai = false;
                    db.Sims.InsertOnSubmit(add);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm sim thành công!");
                }

                SIM_Load(sender, e);
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
        }

        private void dtgv_SIM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_SIM.CurrentRow.Selected = true;
            txt_Sosim.Text = dtgv_SIM.Rows[e.RowIndex].Cells["NumberPhone"].FormattedValue.ToString();
            //txt_MaHDDK.Text = dtgv_SIM.Rows[e.RowIndex].Cells["Mã_HDDK"].FormattedValue.ToString();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Sim del = new Sim();
            int masim = Convert.ToInt32(dtgv_SIM.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
            int madk = Convert.ToInt32(dtgv_SIM.SelectedCells[0].OwningRow.Cells["IDSign"].Value.ToString());
            del = db.Sims.Where(p => p.MaSim.Equals(masim)).SingleOrDefault();
            del.MaHdDk = null;
            del.TrangThai = false;
            //db.Sims.DeleteOnSubmit(del);
            db.SubmitChanges();
            SIM_Load(sender, e);
            simnull();
            Clear();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            try
            {
                int masim = Convert.ToInt32(dtgv_SIM.SelectedCells[0].OwningRow.Cells["ID"].Value.ToString());
                string sosim = txt_Sosim.Text;
                //int mahddk = Convert.ToInt32(txt_MaHDDK.Text);
                Sim edit = db.Sims.Where(p => p.MaSim.Equals(masim)).SingleOrDefault();
                if (sosim != "")
                {
                    edit.SoSim = sosim;
                    //edit.MaHdDk = mahddk;

                    db.SubmitChanges();
                    SIM_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được để trống dữ liệu");
                }
                Clear();
            }
            catch
            {
                MessageBox.Show("Kiểm tra lại thông tin!");
            }
        }
        public void find(DataGridView data, string test)
        {
            var t = int.TryParse(test, out int n);
            if (t)
            {
                data.DataSource = from a in db.Sims
                                  from b in db.Khs
                                  from c in db.HdDks
                                  where a.MaHdDk == c.MaHdDk && b.MaKh == c.MaKh && a.SoSim == test
                                  select new
                                  {
                                      ID = a.MaSim,
                                      NumberPhone = a.SoSim,
                                      Mã_HDDK = c.MaHdDk,
                                      Khách_hàng = b.TenKh
                                  };
            }
            else
            {
                data.DataSource = from a in db.Sims
                                  from b in db.Khs
                                  from c in db.HdDks
                                  where a.MaHdDk == c.MaHdDk && b.MaKh == c.MaKh && b.TenKh == test
                                  select new
                                  {
                                      ID = a.MaSim,
                                      NumberPhone = a.SoSim,
                                      Mã_HDDK = c.MaHdDk,
                                      Khách_hàng = b.TenKh
                                  };
            }

        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            find(dtgv_SIM, txt_Find.Text);
            Clear();
        }
    }
}
