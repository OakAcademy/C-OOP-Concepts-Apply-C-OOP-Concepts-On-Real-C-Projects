using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;

namespace BLL
{
    public class DepartmentBLL
    {
        public static void AddDepartment(DEPARTMENT department)
        {
            DepartmentDAO.AddDepartment(department);
        }

        public static List<DEPARTMENT> GetDepartments()
        {
            return DepartmentDAO.GetDepartments();
        }

        public static void UpdateDepartment(DEPARTMENT department)
        {
            DepartmentDAO.UpdateDepartment(department);
        }

        public static void DeleteDepartment(int iD)
        {
            DepartmentDAO.DeleteDepartment(iD);
        }
    }
}
