using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Sim_Library.DAO.Interfaces;

namespace Sim_Library.DAO
{
    public class BaseTable<T> : IBaseTable<T> where T : class
    {
        public void Xoa(T obj)
        {
            DataProvider.Instance.Set<T>().Attach(obj);
            DataProvider.Instance.Set<T>().Remove(obj);
            DataProvider.Instance.SaveChanges();
        }

        public List<T> TatCa()
        {
            return DataProvider.Instance.Set<T>().ToList();
        }

        public void Them(T obj)
        {
            try
            {

                DataProvider.Instance.Set<T>().Add(obj);
                DataProvider.Instance.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public void Sua(T obj)
        {
            DataProvider.Instance.Set<T>().Attach(obj);
            DataProvider.Instance.Entry(obj).State = EntityState.Modified;
            DataProvider.Instance.SaveChanges();
        }
    }
}
