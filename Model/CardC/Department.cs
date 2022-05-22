using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.CardC
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string? DepartmentName { get; set; }

        public static Department ConvertToModel(DataRow row)
        {
            return new Department
            {
                DepartmentId = row.Table.Columns.Contains("DepartmentId") ? Convert.ToInt32(row["DepartmentId"]) : 0,
                DepartmentName = row.Table.Columns.Contains("DepartmentName") ? Convert.ToString(row["DepartmentName"]) : string.Empty,
            };

        }
    }
}
