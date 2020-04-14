using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
   public class TaskDetailDTO
    {
       
        public string Title { get; set; }
        public int UserNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
   
        public DateTime? TaskStartDate { get; set; }
        public DateTime? TaskDeliveryDate { get; set; }
        public string TaskStateName { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public int DepartmentID { get; set; }
        public int PositionID { get; set; }
        public int TaskID { get; set; }
        public int EmployeeID { get; set; }
        public string Content { get; set; }
      
        public int taskStateID { get; set; }



    }
}
