using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DAO
{
    public class PositionDAO : EmployeeContext
    {
        public static void AddPosition(POSITION position)
        {
			try
			{
				db.POSITIONs.InsertOnSubmit(position);
				db.SubmitChanges();
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static List<PositionDTO> GetPositions()
        {
			try
			{
				var list = (from p in db.POSITIONs
							join d in db.DEPARTMENTs on p.DepartmentID equals d.ID
							select new
							{
								positionID = p.ID,
								positionName = p.PositionName,
								departmentName = d.DepartmentName,
								departmentID = p.DepartmentID
							}).OrderBy(x => x.positionID).ToList();

				List<PositionDTO> positionList = new List<PositionDTO>();
				foreach (var item in list)
				{
					PositionDTO dto = new PositionDTO();
					dto.ID = item.positionID;
					dto.PositionName = item.positionName;
					dto.DepartmentName = item.departmentName;
					dto.DepartmentID = item.departmentID;
					positionList.Add(dto);
				}
				return positionList;
			}
			catch (Exception ex)
			{

				throw ex;
			}
        }

        public static void DeletePosition(int iD)
        {
			try
			{
				POSITION position = db.POSITIONs.First(x => x.ID == iD);
				db.POSITIONs.DeleteOnSubmit(position);
				db.SubmitChanges();
			}
			catch (Exception)
			{

				throw;
			}
        }

        public static void UpdatePosition(POSITION position)
        {
			try
			{
				POSITION pst = db.POSITIONs.First(x => x.ID == position.ID);
				pst.PositionName = position.PositionName;
				pst.DepartmentID = position.DepartmentID;
				db.SubmitChanges();
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
