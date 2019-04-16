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
    public partial class Testgoi : Form
    {
        SimModelDataContext db = new SimModelDataContext();
        public Testgoi()
        {
            InitializeComponent();
            tbxName.Text = "SimLog.txt";
            var s = from p in db.Sims select new { p.SoSim };
            cbxNumbers.DataSource = s;
            cbxNumbers.DisplayMember = "SoSim";
            cbxNumbers.ValueMember = "SoSim";
        }
        DateTime now = DateTime.Now;
        private void btnCall_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            tbxStart.Text = now.ToShortDateString() + " " + now.ToLongTimeString().ToString();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime passTime = DateTime.Parse((DateTime.Now).ToString());
            txbEnd.Text = passTime.ToShortDateString() + " " + passTime.ToLongTimeString().ToString();
        }

        private void btnghi_Click(object sender, EventArgs e)
        {
            string text = cbxNumbers.Text + "," + tbxStart.Text + "," + txbEnd.Text;
            if(Ghifile.Instance.Write(tbxName.Text, text))
            {
                tbxStart.Clear();
                txbEnd.Clear();
                MessageBox.Show("Ghi file thành công!");
            }
            else
            {
                MessageBox.Show("Ghi file thất bại!");
            }
        }
    }
}
