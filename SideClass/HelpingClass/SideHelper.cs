using Model.CardC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SideClass.HelpingClass
{
    public class SideHelper
    {
        public Task<string> DepartmentObjectStringBuilder(Department department,string message)
        {
            var JSONString = new StringBuilder();
            if (department != null)
            {

                JSONString.Append("{");
                JSONString.Append("\"" + "status" + "\":" + "\"" + message + "\",");
                JSONString.Append("\"" + "Department" + "\":{");
                JSONString.Append("\"DepartmentId\":" + "\"" + department.DepartmentId + "\",");
                JSONString.Append("\"DepartmentName\":" + "\"" + department.DepartmentName + "\"");
                JSONString.Append("}");
                JSONString.Append("},");
            }
            return Task.FromResult(JSONString.ToString());
        }

        public DataTable GetJSONToDataTableUsingMethod(string JSONData)
        {
            DataTable dtUsingMethodReturn = new DataTable();
            string[] jsonStringArray = Regex.Split(JSONData.Replace("[", "").Replace("]", ""), "},{");
            List<string> ColumnsName = new List<string>();
            foreach (string strJSONarr in jsonStringArray)
            {
                string[] jsonStringData = Regex.Split(strJSONarr.Replace("{", "").Replace("}", ""), ",");
                foreach (string ColumnsNameData in jsonStringData)
                {
                    try
                    {
                        int idx = ColumnsNameData.IndexOf(":");
                        string ColumnsNameString = ColumnsNameData.Substring(0, idx).Replace("\"", "").Trim();
                        if (!ColumnsName.Contains(ColumnsNameString))
                        {
                            ColumnsName.Add(ColumnsNameString);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                    }
                }
                break;
            }
            foreach (string AddColumnName in ColumnsName)
            {
                dtUsingMethodReturn.Columns.Add(AddColumnName);
            }
            foreach (string strJSONarr in jsonStringArray)
            {
                string[] RowData = Regex.Split(strJSONarr.Replace("{", "").Replace("}", ""), ",");
                DataRow nr = dtUsingMethodReturn.NewRow();
                foreach (string rowData in RowData)
                {
                    try
                    {
                        int idx = rowData.IndexOf(":");
                        string RowColumns = rowData.Substring(0, idx).Replace("\"", "").Trim();
                        string RowDataString = rowData.Substring(idx + 1).Replace("\"", "").Trim();
                        nr[RowColumns] = RowDataString;
                    }
                    catch (Exception ex)
                    {
                        continue;
                    }
                }
                dtUsingMethodReturn.Rows.Add(nr);
            }
            return dtUsingMethodReturn;
        }
        //public List<DateTime> GetDates(int year, int month)
        //{
        //    var dates = new List<DateTime>();
        //    for (var date = new DateTime(year, month, 1); date.Month == month; date = date.AddDays(1))
        //    {
        //        dates.Add(date);
        //    }
        //    DateTime minDate = DateTime.MaxValue;
        //    DateTime maxDate = DateTime.MinValue;
        //    foreach (DateTime dateString in dates)
        //    {
        //        DateTime date = dateString;
        //        if (date < minDate)
        //            minDate = date;
        //        if (date > maxDate)
        //            maxDate = date;
        //    }

        //    return dates;
        //}

        //public int getMonth(string Month)
        //{
        //    int month = 0;
        //    if (Month == "Feb")
        //    {
        //        month = 2;
        //    }
        //    return month;
        //}

    }
}
