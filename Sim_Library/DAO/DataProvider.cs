using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Library.DAO
{
    public static class DataProvider
    {
        private static SimDBContext _instance = null;
        public static SimDBContext Instance => _instance ?? new SimDBContext();
    }
}
