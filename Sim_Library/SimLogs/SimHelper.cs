using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sim_Library.SimLogs
{
    public class SimHelper
    {
        public static List<Tuple<int, DateTime, DateTime>> ReadFromTextLog(string filePath)
        {
            List<Tuple<int, DateTime, DateTime>> tup = new List<Tuple<int, DateTime, DateTime>>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var l in lines)
                {
                    string[] row = l.Split('\t');
                    tup.Add(new Tuple<int, DateTime, DateTime>(Int32.Parse(row[0]),
                        DateTime.ParseExact(row[1], "yyyy-MM-dd HH:mm:ss,fff",
                            System.Globalization.CultureInfo.InvariantCulture),
                        DateTime.ParseExact(row[2], "yyyy-MM-dd HH:mm:ss,fff",
                            System.Globalization.CultureInfo.InvariantCulture)));
                }
            }
            catch (Exception)
            {
                return null;
            }

            return tup;
        }
    }
}
