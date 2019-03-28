using System.Windows.Forms;
using Sim_Win.interfaces;

namespace Sim_Win
{
    public partial class FrmChinh : Form,IFrmChinh
    {
        FrmHd _frmHd = new FrmHd();
        FrmKh _frmKh = new FrmKh();
        FrmSim _frmSim = new FrmSim();
        public FrmChinh()
        {
            InitializeComponent();
        }

        private void btnFrmSim_Click(object sender, System.EventArgs e)
        {
           _frmSim.Show();
        }

        private void btnFrmKh_Click(object sender, System.EventArgs e)
        {
            _frmKh.Show();
        }

        private void btnFrmHd_Click(object sender, System.EventArgs e)
        {
            _frmHd.Show();
        }
    }
}
