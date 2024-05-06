using UnityEngine;
using UnityEngine.Animations;

public class Staff : MonoBehaviour
{
    public enum StaffStatus
    {
        MainTask,
        Needed,
    }
    [SerializeField] private AIController aIController;

    [SerializeField] private HoldingHandler holdingHandler;
    [SerializeField] private StaffStatus status;
    [SerializeField] private TaskType taskType;
    private Task task;
    private Task previousTask;
    public Task CurrentTask => task;
    public StaffStatus staffStatus => status;
    public TaskType TaskType => taskType;
    public void SetTask(Task task)
    {
        this.task = task;
        if (task == null)
        {
            if (previousTask != null)
            {
                previousTask.Holder.TaskFinished -= ClearTask;
            }
            aIController.Stop(true);
            status = StaffStatus.MainTask;
            return;
        }
        else
        {
            previousTask = task;
            task.Holder.TaskFinished += ClearTask;
            aIController.Stop(false);
            SetDestination(task.transform.position);
            status = StaffStatus.MainTask;
        }

    }
    public void ClearTask()
    {
        SetTask(null);
    }
    public void SetStatus(StaffStatus status)
    {
        this.status = status;
    }
    public bool IsFinishedTaskBefore()
    {
        return task == null;
    }



    public bool IsReachDestination()
    {
        return aIController.IsReachDestination();
    }
    public void SetDestination(Vector3 destination)
    {
        aIController.SetDestination(destination);
    }

}
