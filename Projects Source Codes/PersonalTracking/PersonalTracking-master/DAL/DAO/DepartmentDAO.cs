using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class DepartmentDAO : EmployeeContext
    {
        public static void AddDepartment(DEPARTMENT department)
        {
            try
            {
                db.DEPARTMENTs.InsertOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public static List<DEPARTMENT> GetDepartments()
        {
            return db.DEPARTMENTs.ToList();
        }

        public static void UpdateDepartment(DEPARTMENT department)
        {
            try
            {
                DEPARTMENT dpt = db.DEPARTMENTs.First(x => x.ID == department.ID);
                dpt.DepartmentName = department.DepartmentName;
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteDepartment(int iD)
        {
            try
            {
                DEPARTMENT department = db.DEPARTMENTs.First(x => x.ID == iD);
                db.DEPARTMENTs.DeleteOnSubmit(department);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
