using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
  public  class PositionDTO:POSITION
    {
        public string DepartmentName { get; set; }
        public int OldDepartmentID { get; set; }
    }
}
