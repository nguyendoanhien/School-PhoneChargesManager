using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sim_Library.DAO.Interfaces;


namespace Sim_Library.BUS
{
    public class BaseTable<T> : IBaseTable<T> where T : class
    {
        DAO.BaseTable<T> _dao = new DAO.BaseTable<T>();
        public void Xoa(T obj)
        {
            _dao.Xoa(obj);
        }

        public List<T> TatCa()
        {
            return _dao.TatCa();
        }

        public void Them(T obj)
        {
            _dao.Them(obj);
        }

        public void Sua(T obj)
        {
            _dao.Sua(obj);
        }
    }
}
