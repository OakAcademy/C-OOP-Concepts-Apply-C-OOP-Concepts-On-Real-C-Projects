using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class EmployeeDAO : EmployeeContext
    {
        public static void AddEmployee(EMPLOYEE employee)
        {
			try
			{
				db.EMPLOYEEs.InsertOnSubmit(employee);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

		public static List<EMPLOYEE> GetUsers(int v)
		{
			return db.EMPLOYEEs.Where(x => x.UserNo == v).ToList();
		}

        public static List<EmployeeDetailDTO> GetEmployees()
        {
			List<EmployeeDetailDTO> employeeList = new List<EmployeeDetailDTO>();
			var list = (from e in db.EMPLOYEEs
						join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
						join p in db.POSITIONs on e.PositionID equals p.ID
						select new
						{
							UserNo = e.UserNo,
							Name = e.Name,
							Surname = e.Surname,
							EmployeeID = e.ID,
							Password = e.Password,
							DepartmentName = d.DepartmentName,
							PositionName = p.PositionName,
							DepartmentID = e.DepartmentID,
							PositionId = e.PositionID,
							isAdmin = e.isAdmin,
							Salary = e.Salary,
							ImagePath = e.ImagePath,
							birthDay = e.BirthDay,
							Adress = e.Adress

						}).OrderBy(x => x.UserNo).ToList();
			foreach (var item in list)
			{
				EmployeeDetailDTO dto = new EmployeeDetailDTO();
				dto.Name = item.Name;
				dto.UserNo = item.UserNo;
				dto.Surname = item.Surname;
				dto.EmployeeID = item.EmployeeID;
				dto.Password = item.Password;
				dto.DepartmentID = item.DepartmentID;
				dto.DepartmentName = item.DepartmentName;
				dto.PositionID = item.PositionId;
				dto.PositionName = item.PositionName;
				dto.isAdmin = item.isAdmin;
				dto.Salary = item.Salary;
				dto.BhirtDay = item.birthDay;
				dto.Adress = item.Adress;
				dto.ImagePath = item.ImagePath;
				employeeList.Add(dto);
				

			}




			return employeeList;
        }

        public static void DeleteEmployee(int employeeID)
        {
			try
			{
				EMPLOYEE emp = db.EMPLOYEEs.First(x => x.ID == employeeID);
				db.EMPLOYEEs.DeleteOnSubmit(emp);
				db.SubmitChanges();
				
			}
			catch (Exception)
			{

				throw;
			}
        }

        public static void UpdateEmployee(POSITION position)
        {
			List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.PositionID == position.ID).ToList();
			foreach (var item in list)
			{
				item.DepartmentID = position.DepartmentID;
			}
			db.SubmitChanges();
        }

        public static void UpdateEmployee(EMPLOYEE employee)
        {
			try
			{
				EMPLOYEE emp = db.EMPLOYEEs.First(x => x.ID == employee.ID);
				emp.UserNo = employee.UserNo;
				emp.Name = employee.Name;
				emp.Surname = employee.Surname;
				emp.Password = employee.Password;
				emp.isAdmin = employee.isAdmin;
				emp.BirthDay = employee.BirthDay;
				emp.Adress = employee.Adress;
				emp.DepartmentID = employee.DepartmentID;
				emp.PositionID = employee.PositionID;
				emp.Salary = employee.Salary;
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static void UpdateEmployee(int employeeID, int amount)
        {
			try
			{
				EMPLOYEE employee = db.EMPLOYEEs.First(x => x.ID == employeeID);
				employee.Salary = amount;
				db.SubmitChanges();
			}
			catch (Exception)
			{

				throw;
			}
        }

        public static List<EMPLOYEE> GetEmployees(int v, string text)
		{
			try
			{
				List<EMPLOYEE> list = db.EMPLOYEEs.Where(x => x.UserNo == v && x.Password == text).ToList();
				return list;
			}
			catch (Exception)
			{

				throw;
			}
		}
	}
}
