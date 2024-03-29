using System;
using System.Data;
using Logger;

namespace Utilities
{
    public class Convert
    {
        public static DateTime NullDate = new DateTime(1900, 1, 1); //ngày 1/1/1900

        public static DateTime ConvertDateFromdateOfUsa(string dateOfUsa)
        {
            try
            {
                var tmp = DateArrayOfUsa(dateOfUsa);

                if (tmp == null) return NullDate;
                try
                {
                    return new DateTime(tmp[2], tmp[0], tmp[1]);
                }
                catch
                {
                    return NullDate;
                }
            }
            catch
            {
                return NullDate;
            }
        }

        public static DateTime ConvertDateFromdateOfVn(string dateOfVn)
        {
            try
            {
                var tmp = DateArrayOfVn(dateOfVn);

                if (tmp == null) return NullDate;
                try
                {
                    return new DateTime(tmp[2], tmp[1], tmp[0]);
                }
                catch
                {
                    return NullDate;
                }
            }
            catch
            {
                return NullDate;
            }
        }

        internal static string ToBase64String(byte[] resultArray, int v, int length)
        {
            throw new NotImplementedException();
        }

        public static string ConvertToDate(string sNgay)
        {
            try
            {
                var tmp = sNgay.Split('/');
                var ngay = tmp[0] + "/" + tmp[1] + "/" + tmp[2];
                var ngayConvert = DateTime.Parse(ngay);
                return ngayConvert.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                Log.info("convert.convertToDate: " + ex.Message);
                return "";
            }
        }

        public static string ConvertToDateVn(string sNgay)
        {
            try
            {
                var tmp = sNgay.Split('/');
                var ngay = tmp[1] + "/" + tmp[0] + "/" + tmp[2];
                var ngayConvert = DateTime.Parse(ngay);
                return ngayConvert.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                Log.info("convert.convertToDateVN: " + ex.Message);
                return "";
            }
        }

        private static int[] DateArrayOfUsa(string dateOfUsa)
        {
            //trả về 1 mảng các thông tin về ngày/tháng/năm của chuỗi truyền vào
            // 
            try
            {
                var tmp = dateOfUsa.Split('/');
                if (tmp.Length != 3) return null;

                var result = new int[3];
                for (var i = 0; i < 3; i++)
                {
                    tmp[i] = tmp[i].Trim();
                    if (tmp[i] == "") return null;
                    result[i] = GetInt(tmp[i]);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        private static int[] DateArrayOfVn(string dateOfVn)
        {
            //trả về 1 mảng các thông tin về ngày/tháng/năm của chuỗi truyền vào
            // 
            try
            {
                var tmp = dateOfVn.Split('/');
                if (tmp.Length != 3) return null;

                var result = new int[3];
                for (var i = 0; i < 3; i++)
                {
                    tmp[i] = tmp[i].Trim();
                    if (tmp[i] == "") return null;
                    result[i] = GetInt(tmp[i]);
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string FormatToDate(string strDate)
        {
            try
            {
                var mydate = DateTime.Parse(strDate);
                return mydate.ToShortDateString();
            }
            catch
            {
                return strDate;
            }
        }

        public static decimal FormatToNumber(string strNumber)
        {
            try
            {
                var myNumber = decimal.Parse(strNumber);
                return myNumber;
            }
            catch
            {
                return 0;
            }
        }

        public static string FristDateOfMonth(string monthYear)
        {
            //monthYear là chuỗi tháng năm dạng (MM/yyyy)
            //trả về ngày dầu tháng 
            try
            {
                var tmp = monthYear.Split('/');
                var ngay = tmp[0] + "/" + "1" + "/" + tmp[1];
                var ngayConvert = DateTime.Parse(ngay);
                return ngayConvert.ToString("MM/dd/yyyy");
            }
            catch (Exception ex)
            {
                Log.info("convert.fristDateOfMonth: " + ex.Message);
                return "";
            }
        }

        public static bool GetBool(DataTable dtb, int rowIndex, string colName)
        {
            bool ii;
            if (dtb.Rows[rowIndex].IsNull(colName))
                ii = false;
            else
                return bool.Parse(dtb.Rows[rowIndex][colName].ToString());
            return ii;
        }

        public static bool GetBool(object obj)
        {
            bool ii;
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                ii = false;
            else
                return bool.Parse(obj.ToString());
            return ii;
        }

        public static DateTime GetDateTime(DataTable dtb, int rowIndex, string colName)
        {
            DateTime ii;
            if (dtb.Rows[rowIndex].IsNull(colName))
                ii = NullDate;
            else
                ii = DateTime.Parse(dtb.Rows[rowIndex][colName].ToString());
            return ii;
        }

        public static DateTime GetDateTime(object sDate)
        {
            DateTime ii;
            if (sDate == DBNull.Value)
                ii = NullDate;
            else
                try
                {
                    ii = DateTime.Parse(sDate.ToString());
                    ii = new DateTime(ii.Year, ii.Month, ii.Day);
                }
                catch
                {
                    ii = NullDate;
                }

            return ii;
        }

        //
        public static decimal GetDecimal(DataTable dtb, int rowIndex, string colName)
        {
            decimal ii;
            if (dtb.Rows[rowIndex].IsNull(colName))
                ii = 0;
            else
                ii = decimal.Parse(dtb.Rows[rowIndex][colName].ToString());
            return ii;
        }

        public static decimal GetDecimal(object obj)
        {
            decimal ii;
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                ii = 0;
            else
                try
                {
                    ii = decimal.Parse(obj.ToString());
                }
                catch
                {
                    //ii = decimal.MinValue;
                    ii = 0;
                }

            return ii;
        }

        public static int GetInt(DataTable dtb, int rowIndex, string colName)
        {
            int ii;
            if (dtb.Rows[rowIndex].IsNull(colName))
                ii = 0;
            else
                ii = int.Parse(dtb.Rows[rowIndex][colName].ToString());
            return ii;
        }

        public static int GetInt(object obj)
        {
            int ii;
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                ii = 0;
            else
                try
                {
                    ii = int.Parse(obj.ToString());
                }
                catch
                {
                    //ii = int.MinValue;
                    ii = 0;
                }

            return ii;
        }

        public static int GetMonth(DateTime date1, DateTime date2)
        {
            try
            {
                if (date1 > date2)
                {
                    var tmp = date1;
                    date1 = date2;
                    date2 = tmp;
                }

                var year = date2.Year - date1.Year;
                var month = date2.Month - date1.Month;
                return year * 12 + month;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static string GetString(object obj)
        {
            var str = "";
            if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                str = "";
            else
                return obj.ToString().Trim();
            return str;
        }

        public static string GetString(DataTable dtb, int rowIndex, string colName)
        {
            var str = "";
            if (dtb.Rows[rowIndex].IsNull(colName))
                str = "";
            else
                return dtb.Rows[rowIndex][colName].ToString().Trim();
            return str;
        }

        public static bool IsDate(string strDate)
        {
            try
            {
                var mydate = DateTime.Parse(strDate);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsnullDate(DateTime pmyDate)
        {
            if (pmyDate <= NullDate) return true;
            return false;
        }
    }
}