using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Library.BUS.Interfaces
{
    interface IBaseTable<T>
    {
        void Xoa(T obj);
        List<T> TatCa();
        void Them(T obj);
        void Sua(T obj);
    }
}
