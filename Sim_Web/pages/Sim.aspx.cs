using System;
using System.Linq;
using System.Web.UI;
using Sim_Library.BUS;
using Sim_Library.DAO;

namespace Sim_Web.pages
{
    public partial class PageSim : Page
    {
        private SimBus _simBus = new SimBus();
        private KhBus _khBus = new KhBus();
        private HdDkBus _hdDkBus = new HdDkBus();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Load_gvSims();
                Load_rdlKh();

            }
        }

        private void Load_gvSims()
        {
            gvSims.DataSource = _simBus.TatCa();
            gvSims.DataBind();
        }

        private void Load_rdlKh()
        {
            rdlKh.DataSource = _khBus.TatCa().ToList();
            rdlKh.DataValueField = "MaKh";
            rdlKh.DataTextField = "TenKh";
            rdlKh.DataBind();
        }
        protected void btnThemSim_Click(object sender, EventArgs e)
        {
            _simBus.Them(new Sim() { SoSim = txtSoSim.Text });
            Load_gvSims();
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            var simIds = Array.ConvertAll(txtSims.Text.Split(','), s => int.TryParse(s, out var i) ? i : 0);

            _hdDkBus.Them(new HdDk()
            {
                MaKh = Convert.ToInt32(rdlKh.SelectedValue),
                ChiPhiDk = "50000"
            });
            int maHdDk = _hdDkBus.TatCa().Last().MaHdDk;
            foreach (var id in simIds)
            {
                Sim editSim = _simBus.TatCa().FirstOrDefault(m => m.MaSim == id);
                editSim.MaHdDk = maHdDk;
                _simBus.Sua(editSim);
            }

            Load_gvSims();
        }
    }
}