using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.UI;
using Sim_Library.BUS;
using Sim_Library.DAO;

namespace Sim_Library.SimLogs
{

    public class SimHelper
    {
        private static SimBus _simBus = new SimBus();
        private static string path = HostingEnvironment.MapPath("~") + "SimLog.txt";
        public static List<Sd> ReadFromTextLog()
        {

            List<Sd> listSd = new List<Sd>();
            try
            {
                string[] lines = File.ReadAllLines(path);
                foreach (var l in lines)
                {


                    string[] row = l.Split(',');




                    listSd.Add(
                        new Sd()
                        {
                            MaSim = _simBus.TatCa().FirstOrDefault(m => m.SoSim == row[0]).MaSim,
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
        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public static double CaculateSmsMoney_TamAnDi(List<Sd> sdList)
        {
            double money = 0;
            var listKg = new KgBUS() { }.TatCa();

            foreach (var kg in listKg)
            {
                foreach (var sd in sdList)
                {
                    foreach (DateTime date in EachDay(sd.TgBd.Value, sd.TgKt.Value))
                    {
                        TimeSpan fromDate = new TimeSpan();
                        TimeSpan toDate = new TimeSpan();
                        if (date.Date == sd.TgBd.Value.Date && date.Date == sd.TgKt.Value.Date)
                        {
                            fromDate = sd.TgBd.Value.TimeOfDay;
                            toDate = sd.TgKt.Value.TimeOfDay;
                        }
                        else if (date.Date == sd.TgBd.Value.Date)
                        {
                            fromDate = sd.TgBd.Value.TimeOfDay;
                            toDate = new TimeSpan(23, 59, 59);
                        }
                        else if (date.Date == sd.TgKt.Value.Date)
                        {
                            fromDate = new TimeSpan(0, 0, 0);
                            toDate = sd.TgKt.Value.TimeOfDay;
                        }
                        else
                        {
                            fromDate = new TimeSpan(0, 0, 0);
                            toDate = new TimeSpan(23, 59, 59);
                        }

                        TimeSpan durationKg = kg.GioKt.Value.Subtract(kg.GioBd.Value);
                        TimeSpan durationKgOk = (durationKg.CompareTo(TimeSpan.Zero) < 0)
                            ? durationKg.Add(new TimeSpan(24, 0, 0))
                            : durationKg;


                        bool hasZero = durationKg.CompareTo(TimeSpan.Zero) < 0 ? true : false;
                        TimeSpan left = new TimeSpan();
                        TimeSpan right = new TimeSpan();
                        bool isOk = false;

                        if (hasZero)
                        {
                            if (toDate.CompareTo(fromDate) > 0)
                            {
                                if (toDate.CompareTo(kg.GioBd.Value) >= 0)
                                {
                                    left = new TimeSpan(24, 0, 0).Subtract(toDate);

                                    if (toDate.Equals(kg.GioBd))
                                        left = left.Add(new TimeSpan(0, 0, 0, -1));
                                    isOk = true;
                                }
                                if (fromDate.CompareTo(kg.GioKt.Value) <= 0)
                                {
                                    right = fromDate.Subtract(TimeSpan.Zero);
                                    isOk = true;
                                }



                            }
                            else
                            {
                                if (fromDate.CompareTo(kg.GioKt.Value) <= 0)
                                {
                                    right = kg.GioKt.Value.Subtract(fromDate);
                                    isOk = true;

                                }

                                if (toDate.CompareTo(kg.GioBd.Value) > 0)
                                {

                                    left = toDate.Subtract(kg.GioBd.Value);
                                    isOk = true;
                                }
                            }
                        }
                        else
                        {
                            if (fromDate.CompareTo(kg.GioBd.Value) > 0)
                            {
                                left = fromDate.Subtract(kg.GioBd.Value);
                                isOk = true;
                            }

                            if (toDate.CompareTo(kg.GioKt.Value) <= 0)
                            {

                                right = kg.GioKt.Value.Subtract(toDate);
                                isOk = true;
                            }

                            if (fromDate.CompareTo(kg.GioBd.Value) < 0 && toDate.CompareTo(kg.GioKt.Value) > 0)
                            {
                                isOk = true;
                            }
                        }

                        if (isOk)
                            money += (durationKgOk.Subtract(left.Equals(TimeSpan.Zero) ? left.Add(new TimeSpan(0, 0, 1)) : left).Subtract(right).TotalSeconds / 60) * double.Parse(kg.GiaCuoc);
                        else money += 0;


                    }
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

        public static void GenerateLogs(int line)
        {

            var avlbSims = _simBus.TatCa().Select(m => m.SoSim).ToArray();
            StringBuilder sb = new StringBuilder();
            try
            {
                Random rd = new Random();
                for (int i = 1; i <= line; i++)
                {
                    string sim = avlbSims[rd.Next(0, avlbSims.Length)];
                    DateTime fromDate = RandomFromDate(2018, 2019, rd);
                    DateTime toDate = RandomToDate(fromDate, rd);
                    sb.Append(sim + "," + fromDate.ToString() + "," + toDate.ToString() + Environment.NewLine);

                }

                File.WriteAllText(path, sb.ToString());
            }
            catch (Exception ex)
            {

            }
        }

        private static DateTime RandomFromDate(int fromYear, int toYear, Random r)
        {
            try
            {
                DateTime from = new DateTime(fromYear, 1, 1);
                DateTime to = DateTime.Now;
                int rYear = r.Next(fromYear, toYear);
                int rMonth = r.Next(1, 13);
                int maxDayNr = DateTime.DaysInMonth(rYear, rMonth);
                int rDate = r.Next(1, (maxDayNr + 1));

                DateTime dateTime = new DateTime(rYear, rMonth, rDate);
                //int rHour = r.Next(1, 24);
                //int rMinute = r.Next(1, 60);
                //int rSecond = r.Next(1, 60);
                TimeSpan range = new TimeSpan(to.Ticks - from.Ticks);
                return from + new TimeSpan((long)(range.Ticks * r.NextDouble()));
            }

            catch (Exception ex)
            {
                return DateTime.Now;
            }
        }
        private static DateTime RandomToDate(DateTime fromDate, Random r)
        {
            DateTime rToDate = fromDate;

            return rToDate.Add(new TimeSpan(0, 0, 0, r.Next(86400)));
        }

        public static double CaculateSmsMoney(List<Sd> sdList)
        {
            double money = 0;
            var listKg = new KgBUS() { }.TatCa();

            foreach (var kg in listKg)
            {
                foreach (var sd in sdList)
                {

                    foreach (DateTime date in EachDay(sd.TgBd.Value, sd.TgKt.Value))
                    {
                        TimeSpan fromDate = new TimeSpan();
                        TimeSpan toDate = new TimeSpan();
                        if (date.Date == sd.TgBd.Value.Date && date.Date == sd.TgKt.Value.Date)
                        {
                            fromDate = sd.TgBd.Value.TimeOfDay;
                            toDate = sd.TgKt.Value.TimeOfDay;
                        }
                        else if (date.Date == sd.TgBd.Value.Date)
                        {
                            fromDate = sd.TgBd.Value.TimeOfDay;
                            toDate = new TimeSpan(23, 59, 59);
                        }
                        else if (date.Date == sd.TgKt.Value.Date)
                        {
                            fromDate = new TimeSpan(0, 0, 0);
                            toDate = sd.TgKt.Value.TimeOfDay;
                        }
                        else
                        {
                            fromDate = new TimeSpan(0, 0, 0);
                            toDate = new TimeSpan(23, 59, 59);
                        }
                        TimeSpan time = new TimeSpan();

                        time = GetTimeSpanIntersect(kg.GioBd.Value.Add(new TimeSpan(0, 0, 1)), kg.GioKt.Value, fromDate, toDate);

                        money += ((double)time.TotalSeconds / 60) * double.Parse(kg.GiaCuoc);
                    }
                }
            }



            return Math.Ceiling(money);
        }
        public static TimeSpan GetTimeSpanIntersect(TimeSpan gioBd, TimeSpan gioKt, TimeSpan fromDate, TimeSpan toDate)
        {
            // Loopsback input from 23:59 - 00:00
            if (gioBd > gioKt)
                return GetTimeSpanIntersect(gioBd, TimeSpan.FromHours(24), fromDate, toDate) +
                       GetTimeSpanIntersect(TimeSpan.FromHours(0), gioKt, fromDate, toDate);

            // Loopsback Shift from 23:59 - 00:00
            if (fromDate > toDate)
                return GetTimeSpanIntersect(gioBd, gioKt, new TimeSpan(), toDate) +
                       GetTimeSpanIntersect(gioBd, gioKt, fromDate, TimeSpan.FromHours(24));
            if (gioKt < fromDate)
                return new TimeSpan();

            if (gioBd > toDate)
                return new TimeSpan(0, 0, 1);

            var actualfromDate = gioBd <= fromDate
                ? fromDate
                : gioBd;

            var actualtoDate = gioKt >= toDate
                ? toDate
                : gioKt;

            return actualtoDate - actualfromDate;
        }
    }
}
