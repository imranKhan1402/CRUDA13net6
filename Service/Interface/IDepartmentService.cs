using Model.CardC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IDepartmentService
    {
        Task<List<Department>> GetAllDepartments();
        Task<string> createDepartment(Department department);
        Task<Department> GetDepartmentByID(int id);
    }
}
