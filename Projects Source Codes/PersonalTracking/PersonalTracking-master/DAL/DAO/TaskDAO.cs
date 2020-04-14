using DAL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DTO;

namespace DAL.DAO
{
    public class TaskDAO : EmployeeContext
    {
        public static List<TASKSTATE> GettaskStates()
        {
            return db.TASKSTATEs.ToList();
        }

        public static void AddTask(TASK task)
        {
            try
            {
                db.TASKs.InsertOnSubmit(task);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static List<TaskDetailDTO> GetTasks()
        {
            List<TaskDetailDTO> tasklist = new List<TaskDetailDTO>();

            var list = (from t in db.TASKs
                        join s in db.TASKSTATEs on t.TaskState equals s.ID
                        join e in db.EMPLOYEEs on t.EmployeeID equals e.ID
                        join d in db.DEPARTMENTs on e.DepartmentID equals d.ID
                        join p in db.POSITIONs on e.PositionID equals p.ID
                        select new
                        {
                            taskID = t.ID,
                            title = t.TaskTitle,
                            content = t.TaskContent,
                            startdate = t.TaskStartDate,
                            deliveryDate = t.TaskDeliveryDate,
                            taskStateName = s.StateName,
                            taskStateID = t.TaskState,
                            UserNo = e.UserNo,
                            Name = e.Name,
                            EmployeeId = t.EmployeeID,
                            Surname = e.Surname,
                            positionName = p.PositionName,
                            departmanName = d.DepartmentName,
                            positionID = e.PositionID,
                            departmentId = e.DepartmentID


                        }).OrderBy(x => x.startdate).ToList();

            foreach (var item in list)
            {
                TaskDetailDTO dto = new TaskDetailDTO();
                dto.TaskID = item.taskID;
                dto.Title = item.title;
                dto.Content = item.content;
                dto.TaskStartDate = item.startdate;
                dto.TaskDeliveryDate = item.deliveryDate;
                dto.TaskStateName = item.taskStateName;
                dto.taskStateID = item.taskStateID;
                dto.UserNo = item.UserNo;
                dto.Name = item.Name;
                dto.Surname = item.Surname;
                dto.DepartmentName = item.departmanName;
                dto.PositionID = item.positionID;
                dto.PositionName = item.positionName;
                dto.EmployeeID = item.EmployeeId;
                tasklist.Add(dto);
                
            }
            return tasklist;
        }

        public static void ApproveTask(int taskID, bool isAdmin)
        {
            try
            {
                TASK tsk = db.TASKs.First(x => x.ID == taskID);
                if (isAdmin)
                    tsk.TaskState = TaskStates.Approved;
                else
                    tsk.TaskState = TaskStates.Delivered;
                tsk.TaskDeliveryDate = DateTime.Today;
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void DeleteTask(int taskID)
        {
            try
            {
                TASK ts = db.TASKs.First(x => x.ID == taskID);
                db.TASKs.DeleteOnSubmit(ts);
                db.SubmitChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static void UpdateTask(TASK task)
        {
            try
            {
                TASK ts = db.TASKs.First(x => x.ID == task.ID);
                ts.TaskTitle = task.TaskTitle;
                ts.TaskContent = task.TaskContent;
                ts.TaskState = task.TaskState;
                ts.EmployeeID = task.EmployeeID;
                db.SubmitChanges();


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
