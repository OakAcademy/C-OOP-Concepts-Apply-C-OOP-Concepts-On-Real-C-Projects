using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class SalaryDAO : EmployeeContext
    {
        public static List<MONTH> GetMonths()
        {
            return db.MONTHs.ToList();
        }

        public static void AddSalary(SALARY salary)
        {
            try
            {
                db.SALARies.InsertOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<SalaryDetailDTO> GetSalaries()
        {
            List<SalaryDetailDTO> salaryList = new List<SalaryDetailDTO>();
            var list = (from s in db.SALARies
                        join e in db.EMPLOYEEs on s.EmployeeID equals e.ID
                        join m in db.MONTHs on s.MonthID equals m.ID
                        select new
                        {
                            UserNo = e.UserNo,
                            name = e.Name,
                            surname = e.Surname,
                            EmployeeID = s.EmployeeID,
                            amount = s.Amount,
                            year = s.Year,
                            monthName = m.MonthName,
                            monthID = s.MonthID,
                            salaryID = s.ID,
                            departmentID = e.DepartmentID,
                            positionID = e.PositionID

                        }).OrderBy(x => x.year).ToList();
            foreach (var item in list)
            {
                SalaryDetailDTO dto = new SalaryDetailDTO();
                dto.UserNo = item.UserNo;
                dto.Name = item.name;
                dto.Surname = item.surname;
                dto.EmployeeID = item.EmployeeID;
                dto.SalaryAmount = item.amount;
                dto.SalaryYear = item.year;
                dto.MonthName = item.monthName;
                dto.MonthID = item.monthID;
                dto.SalaryID = item.salaryID;
                dto.DepartmentID = item.departmentID;
                dto.PositionID = item.positionID;
                dto.oldSalary = item.amount;
                salaryList.Add(dto);
                
            }
            return salaryList;
        }

        public static void DeleteSalary(int salaryID)
        {
            try
            {
                SALARY salary = db.SALARies.First(x => x.ID == salaryID);
                db.SALARies.DeleteOnSubmit(salary);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateSalary(SALARY salary)
        {
            try
            {
                SALARY sl = db.SALARies.First(x => x.ID == salary.ID);
                sl.Amount = salary.Amount;
                sl.Year = salary.Year;
                sl.MonthID = salary.MonthID;
                db.SubmitChanges();


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
