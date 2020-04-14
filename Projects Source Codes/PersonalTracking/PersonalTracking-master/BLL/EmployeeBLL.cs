using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DAO;
using DAL;

namespace BLL
{
    public class EmployeeBLL
    {
        public static EmployeeDTO GetAll()
        {
            EmployeeDTO dto = new EmployeeDTO();
            dto.Departments = DepartmentDAO.GetDepartments();
            dto.Positions = PositionDAO.GetPositions();
            dto.Employees = EmployeeDAO.GetEmployees();
            return dto;

        }

        public static void AddEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.AddEmployee(employee);
        }

        public static bool isUnique(int v)
        {
            List<EMPLOYEE> list = EmployeeDAO.GetUsers(v);
            if (list.Count > 0)
                return false;
            else
                return true;
           
        }

        public static List<EMPLOYEE> GetEmployees(int v, string text)
        {
            return EmployeeDAO.GetEmployees(v, text);
        }

        public static void UpdateEmployee(EMPLOYEE employee)
        {
            EmployeeDAO.UpdateEmployee(employee);
        }

        public static void DeleteEmployee(int employeeID)
        {
            EmployeeDAO.DeleteEmployee(employeeID);

        }
    }
}
