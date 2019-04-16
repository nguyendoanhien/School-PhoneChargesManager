using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhoneChargesManager
{
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void btn_KH_Click(object sender, EventArgs e)
        {
            KhachHang KH = new KhachHang();
            KH.Show();

        }

        private void btn_Sim_Click(object sender, EventArgs e)
        {
            SIM sim = new SIM();
            sim.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_HD_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.ShowDialog();
        }
    }
}
