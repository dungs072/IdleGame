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
            var task = taskManager.GetCurrentTask(staff.transform.position);
            if (task == null) { continue; }
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
                    staff.SetDestination(staff.CurrentTask.NeededPlaceToFinishTaks.position);
                    staff.SetStatus(Staff.StaffStatus.Needed);
                }
                else if (staff.staffStatus == Staff.StaffStatus.Needed)
                {
                    staff.SetTask(null);
                }
            }

        }
    }
}
