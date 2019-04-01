using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sim_Library.DAO;
using Sim_Library.DAO.Interfaces;


namespace Sim_Library.BUS
{
    public class BaseTable<T> : IBaseTable<T> where T : class
    {
        DAO.BaseTable<T> _dao = new DAO.BaseTable<T>();

        internal DAO.BaseTable<T> Dao { get => _dao; set => _dao = value; }

        public void Xoa(T obj)
        {
            Dao.Xoa(obj);
        }

        public List<T> TatCa()
        {
            return Dao.TatCa();
        }

        public void Them(T obj)
        {
            Dao.Them(obj);
        }

        public void Sua(T obj)
        {
            Dao.Sua(obj);
        }
    }
}
