using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using Sim_Library.BUS;
using Sim_Library.DAO;

namespace Sim_Library.SimLogs
{
    public class SimHelper
    {
        private static SimBus _simBus = new SimBus();
        public static List<Sd> ReadFromTextLog()
        {
            string filePath = HostingEnvironment.MapPath("~") + "SimLog.txt";
            List<Sd> listSd = new List<Sd>();
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (var l in lines)
                {


                    string[] row = l.Split(',');




                    listSd.Add(
                        new Sd()
                        {
                            MaSim = Int32.Parse(row[0]),
                            TgBd = DateTime.Parse(row[1]),
                            TgKt = DateTime.Parse(row[2]),
                            Sim = _simBus.TatCa().FirstOrDefault(m => m.MaSim.Equals(int.Parse(row[0])))
                        });

                }
            }
            catch (Exception e)
            {
                return null;
            }

            return listSd;
        }

        public static double CaculateSmsMoney(List<Sd> sdList)
        {
            double money = 0;
            List<Tuple<int, int, double>> range = new List<Tuple<int, int, double>>();
            range.Add(new Tuple<int, int, double>(7, 23, 200));
            range.Add(new Tuple<int, int, double>(23, 7, 150));

            foreach (var sd in sdList)
            {
                TimeSpan tp = (sd.TgKt.Value).Subtract(sd.TgBd.Value);
                if (sd.TgBd.Value.Hour >= range[0].Item1)
                {
                    if (sd.TgKt.Value.Hour < range[0].Item2)
                        money += range[0].Item3 * (tp.TotalSeconds / 60);

                    if (sd.TgKt.Value.Hour >= range[0].Item2)
                    {
                        TimeSpan temp = new TimeSpan(range[0].Item2, 0, 0);
                        TimeSpan before = temp.Subtract(sd.TgBd.Value.TimeOfDay);
                        TimeSpan after = sd.TgKt.Value.TimeOfDay.Subtract(temp);
                        money += range[0].Item3 * (before.TotalMilliseconds / 60);
                        money += range[1].Item3 * (after.TotalMilliseconds / 60);
                    }
                }
                if (sd.TgBd.Value.Hour >= range[1].Item1)
                {
                    if (sd.TgKt.Value.Hour < range[1].Item2)
                        money += range[1].Item3 * (tp.TotalSeconds / 60);

                    if (sd.TgKt.Value.Hour >= range[1].Item2)
                    {
                        TimeSpan temp = new TimeSpan(range[1].Item2, 0, 0);
                        TimeSpan before = temp.Subtract(sd.TgBd.Value.TimeOfDay);
                        TimeSpan after = sd.TgKt.Value.TimeOfDay.Subtract(temp);
                        money += range[1].Item3 * (before.TotalMilliseconds / 60);
                        money += range[0].Item3 * (after.TotalMilliseconds / 60);
                    }
                }

            }

            return Math.Ceiling(money);
        }
    }
}
