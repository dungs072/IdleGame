using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffManager : MonoBehaviour
{
    [SerializeField] private List<Staff> staffs;
    private TaskManager taskManager;
    private void Start()
    {
        taskManager = TaskManager.Instance;
    }
    public void ClearTask()
    {
        foreach (var staff in staffs)
        {
            staff.ClearTask();
        }
    }
    private void Update()
    {
        AssignTask();
        HandleTask();
    }

    private void AssignTask()
    {
        if (!taskManager.HasTask()) { return; }


        foreach (var staff in staffs)
        {
            if (!staff.IsFinishedTaskBefore()) { continue; }
            var task = taskManager.GetCurrentTask(staff.transform.position, staff.TaskType);
            if (task == null) { return; }
            staff.SetTask(task);
            taskManager.RemoveTask(task);
        }
    }
    private void HandleTask()
    {
        foreach (var staff in staffs)
        {
            if (staff.CurrentTask == null) { continue; }

            if (staff.IsReachDestination())
            {
                if (staff.staffStatus == Staff.StaffStatus.MainTask)
                {
                    if (staff.CurrentTask.NeedToMoveNextPlace)
                    {
                        staff.SetStatus(Staff.StaffStatus.Needed);
                    }
                    else
                    {
                        return;
                    }
                    if (staff.CurrentTask.NeededPlaceToFinishTask.TryGetComponent(out Holder holder))
                    {
                        if (holder.HolderPositionForAI != null)
                        {
                            staff.SetDestination(holder.HolderPositionForAI.position);
                        }
                        else
                        {
                            staff.SetDestination(staff.CurrentTask.NeededPlaceToFinishTask.position);
                        }
                    }
                    else
                    {
                        staff.SetDestination(staff.CurrentTask.NeededPlaceToFinishTask.position);
                    }


                }
                else if (staff.staffStatus == Staff.StaffStatus.Needed)
                {
                    Task currentTask = staff.CurrentTask;
                    if (currentTask.NeededPlaceToFinishTask.TryGetComponent(out Task task))
                    {
                        staff.SetTask(task);

                    }
                    else
                    {
                        staff.SetTask(null);
                    }

                }
            }

        }
    }
}
