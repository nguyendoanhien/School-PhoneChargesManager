using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
                            Sim = _simBus.TatCa().Where(m => m.MaSim.Equals(int.Parse(row[0]))).FirstOrDefault()


                        });

                }
            }
#pragma warning disable 0168
            catch (Exception e)
#pragma warning restore 0168

            {
                return null;
            }

            return listSd;
        }

        public static double CaculateSmsMoney(List<Sd> sdList)
        {
            double money = 0;
            var listKg = new KgBUS() { }.TatCa();

            foreach (var kg in listKg)
            {
                foreach (var sd in sdList)
                {
                    TimeSpan durationKg = kg.GioKt.Value.Subtract(kg.GioBd.Value);
                    TimeSpan durationKgOk = (durationKg.CompareTo(TimeSpan.Zero) < 0) ? durationKg.Add(new TimeSpan(24, 0, 0)) : durationKg;

                    TimeSpan durationSd = sd.TgKt.Value.TimeOfDay.Subtract(sd.TgBd.Value.TimeOfDay);
                    TimeSpan durationSdOk = (durationSd.CompareTo(TimeSpan.Zero) < 0) ? durationSd.Add(new TimeSpan(24, 0, 0)) : durationSd;

                    bool hasZero = durationKg.CompareTo(TimeSpan.Zero) < 0 ? true : false;
                    TimeSpan left = new TimeSpan();
                    TimeSpan right = new TimeSpan();
                    bool isOk = false;
                    if (hasZero)
                    {
                        if (sd.TgBd.Value.TimeOfDay.CompareTo(kg.GioBd.Value) < 0 &&
                            sd.TgBd.Value.TimeOfDay.CompareTo(kg.GioKt.Value) > 0)
                        {
                        }
                        else
                        {
                            left = sd.TgBd.Value.TimeOfDay.Subtract(kg.GioBd.Value);
                            if (left.CompareTo(TimeSpan.Zero) < 0) left = left.Add(new TimeSpan(24, 0, 0));
                            isOk = true;

                        }

                        if (sd.TgKt.Value.TimeOfDay.CompareTo(kg.GioKt.Value) > 0 && sd.TgKt.Value.TimeOfDay.CompareTo(kg.GioBd.Value) < 0)
                        {

                        }
                        else
                        {

                            right = kg.GioKt.Value.Subtract(sd.TgKt.Value.TimeOfDay);
                            if (right.CompareTo(TimeSpan.Zero) < 0) right = right.Add(new TimeSpan(24, 0, 0));
                            isOk = true;
                        }

                    }
                    else
                    {
                        if (sd.TgBd.Value.TimeOfDay.CompareTo(kg.GioBd.Value) > 0 && sd.TgBd.Value.TimeOfDay.CompareTo(kg.GioKt.Value) < 0)
                        {
                            left = sd.TgBd.Value.TimeOfDay.Subtract(kg.GioBd.Value);
                            isOk = true;
                        }
                        if (sd.TgKt.Value.TimeOfDay.CompareTo(kg.GioBd.Value) > 0 && sd.TgKt.Value.TimeOfDay.CompareTo(kg.GioKt.Value) < 0)
                        {

                            right = kg.GioKt.Value.Subtract(sd.TgKt.Value.TimeOfDay);
                            isOk = true;
                        }
                    }

                    if (isOk)
                        money += (durationKgOk.Subtract(left).Subtract(right).TotalSeconds / 60) * double.Parse(kg.GiaCuoc);
                }
            }

            //foreach (var sd in sdList)
            //{
            //    TimeSpan tp = (sd.TgKt.Value).Subtract(sd.TgBd.Value);
            //    if (sd.TgBd.Value.Hour >= listKg[0].GioBd.Value.Hours)
            //    {
            //        if (sd.TgKt.Value.Hour < listKg[0].GioKt.Value.Hours)
            //            money += double.Parse(listKg[0].GiaCuoc) * (tp.TotalSeconds / 60);

            //        if (sd.TgKt.Value.Hour >= listKg[0].GioKt.Value.Hours)
            //        {
            //            TimeSpan temp = new TimeSpan(listKg[0].GioKt.Value.Hours, 0, 0);
            //            TimeSpan before = temp.Subtract(sd.TgBd.Value.TimeOfDay);
            //            TimeSpan after = sd.TgKt.Value.TimeOfDay.Subtract(temp);
            //            money += double.Parse(listKg[0].GiaCuoc) * (before.TotalMilliseconds / 60);
            //            money += double.Parse(listKg[1].GiaCuoc) * (after.TotalMilliseconds / 60);
            //        }
            //    }
            //    if (sd.TgBd.Value.Hour >= listKg[1].GioBd.Value.Hours)
            //    {
            //        if (sd.TgKt.Value.Hour < listKg[1].GioKt.Value.Hours)
            //            money += double.Parse(listKg[1].GiaCuoc) * (tp.TotalSeconds / 60);

            //        if (sd.TgKt.Value.Hour >= listKg[1].GioKt.Value.Hours)
            //        {
            //            TimeSpan temp = new TimeSpan(listKg[1].GioKt.Value.Hours, 0, 0);
            //            TimeSpan before = temp.Subtract(sd.TgBd.Value.TimeOfDay);
            //            TimeSpan after = sd.TgKt.Value.TimeOfDay.Subtract(temp);
            //            money += double.Parse(listKg[1].GiaCuoc) * (before.TotalMilliseconds / 60);
            //            money += double.Parse(listKg[0].GiaCuoc) * (after.TotalMilliseconds / 60);
            //        }
            //    }

            //}

            return Math.Ceiling(money);
        }
    }
}
