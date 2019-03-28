using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Win.interfaces
{
    interface IBaseFrm
    {
        void Them(object sender, System.EventArgs e);
        void Sua(object sender, System.EventArgs e);
        void Xoa(object sender, System.EventArgs e);
        void LayDanhSach(object sender, System.EventArgs e);
    }
}
