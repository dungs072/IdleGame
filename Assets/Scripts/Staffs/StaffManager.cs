using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaffManager : MonoBehaviour
{
    [SerializeField] private Staff staffPrefab;
    [SerializeField] private Transform spawnStaffPos;
    [SerializeField] private List<Staff> staffs;
    private TaskManager taskManager;
    private void Start()
    {
        taskManager = TaskManager.Instance;
    }
    public void AddStaff(Staff staff)
    {
        if (staffs.Contains(staff)){return;}
        staffs.Add(staff);
    }
    private void Update()
    {
        AssignTask();
        HandleTask();
    }

    public void AddSpeedToStaff(float speed)
    {
        foreach (var staff in staffs)
        {
            staff.AddSpeed(speed);
        }
    }
    public void IncreaseStackSize(int amount)
    {
        foreach(var staff in staffs)
        {
            staff.HoldingHandler.AddHoldingSize(amount);
        }
    }
    public void SpawnStaff(TaskType taskType)
    {
        var staffInstance = Instantiate(staffPrefab,spawnStaffPos.position,Quaternion.identity);
        staffInstance.SetTaskType(taskType);
        AddStaff(staffInstance);
    }

    private void AssignTask()
    {
        if (!taskManager.HasTask()) { return; }
        foreach (var staff in staffs)
        {
            if (!staff.IsFinishedTaskBefore()) { continue; }
            var task = taskManager.GetCurrentTask(staff.transform.position, staff.TaskType);
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
                staff.SetLocomotionValue(0f);
                if (staff.staffStatus == Staff.StaffStatus.MainTask)
                {
                    if (staff.CurrentTask.NeedToMoveNextPlace)
                    {
                        staff.SetStatus(Staff.StaffStatus.Needed);
                    }
                    else
                    {
                        continue;
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
            else
            {
                staff.SetLocomotionValue(1f);
                
            }

        }
    }
}
