using System;
using System.Windows.Forms;
using Sim_Win.interfaces;

namespace Sim_Win
{
    class FrmHd:Form,IFrmHd
    {
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FrmHd
            // 
            this.ClientSize = new System.Drawing.Size(866, 580);
            this.Name = "FrmHd";
            this.ResumeLayout(false);

        }

        public void Them(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Sua(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Xoa(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LayDanhSach(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
