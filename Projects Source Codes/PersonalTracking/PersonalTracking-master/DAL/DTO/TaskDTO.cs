using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO
{
    public class TaskDTO
    {
        public List<EmployeeDetailDTO> Employees { get; set; }
        public List<DEPARTMENT> Departments { get; set; }
        public List<PositionDTO> Positions { get; set; }
        public List<TASKSTATE> TaskStates { get; set; }
        public List<TaskDetailDTO> Tasks { get; set; }

    }
}
