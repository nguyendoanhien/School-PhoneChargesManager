using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Library.DAO
{
    public class DataProvider
    {
        private static SimDBContext _instance;
        private static object _syncLock = new object();
        protected DataProvider()
        {
        }

        public static SimDBContext Instance
        {
            // Uses lazy initialization.

            // Note: this is not thread safe.
            get
            {

                if (_instance == null)
                {
                    lock (_syncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SimDBContext();
                        }
                    }
                }

                return _instance;
            }
        }
    }
}
