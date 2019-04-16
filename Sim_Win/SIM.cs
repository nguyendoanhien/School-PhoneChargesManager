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
        }
        SimModelDataContext db = new SimModelDataContext();

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
                                  Mã_Sim = a.MaSim,
                                  Số_Sim = a.SoSim,
                                  Mã_HDDK = c.MaHdDk,
                                  Tên_Khách_hàng = b.TenKh
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
                int mahddk = Convert.ToInt32(txt_MaHDDK.Text);
                if (Convert.ToInt32(sosim) == 0)
                {
                    MessageBox.Show("Số sim không hợp lệ!");
                }
                else
                {
                    Sim add = new Sim();
                    add.SoSim = sosim;
                    add.MaHdDk = mahddk;
                    db.Sims.InsertOnSubmit(add);
                    db.SubmitChanges();
                }

                SIM_Load(sender, e);
                Clear();
            }
            catch
            {
                MessageBox.Show("Dữ liệu không hợp lệ hoặc chưa tồn tại!");
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
            txt_Sosim.Text = dtgv_SIM.Rows[e.RowIndex].Cells["Số_Sim"].FormattedValue.ToString();
            txt_MaHDDK.Text = dtgv_SIM.Rows[e.RowIndex].Cells["Mã_HDDK"].FormattedValue.ToString();
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            Sim del = new Sim();
            int masim = Convert.ToInt32(dtgv_SIM.SelectedCells[0].OwningRow.Cells["Mã_Sim"].Value.ToString());
            del = db.Sims.Where(p => p.MaSim.Equals(masim)).SingleOrDefault();
            db.Sims.DeleteOnSubmit(del);
            db.SubmitChanges();
            SIM_Load(sender, e);
            Clear();
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            int masim = Convert.ToInt32(dtgv_SIM.SelectedCells[0].OwningRow.Cells["Mã_Sim"].Value.ToString());
            string sosim = txt_Sosim.Text;
            int mahddk = Convert.ToInt32(txt_MaHDDK.Text);
            Sim edit = db.Sims.Where(p => p.MaSim.Equals(masim)).SingleOrDefault();
            edit.SoSim = sosim;
            edit.MaHdDk = mahddk;

            db.SubmitChanges();
            SIM_Load(sender, e);
            Clear();
        }
        public void find(DataGridView data, string test)
        {
            data.DataSource = from a in db.Sims
                              from b in db.Khs
                              from c in db.HdDks
                              where a.MaHdDk == c.MaHdDk && b.MaKh == c.MaKh && a.SoSim == test
                              select new
                              {
                                  Mã_Sim = a.MaSim,
                                  Số_Sim = a.SoSim,
                                  Mã_HDDK = c.MaHdDk,
                                  Mã_Khách_Hàng = b.MaKh
                              };

        }
        private void btn_Find_Click(object sender, EventArgs e)
        {
            find(dtgv_SIM, txt_Find.Text);
            Clear();
        }
    }
}
