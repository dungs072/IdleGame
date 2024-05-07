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
    [SerializeField] private TaskType taskType = TaskType.CashRegister;
    private Task task;
    private Task previousTask;
    public Task CurrentTask => task;
    public StaffStatus staffStatus => status;
    public TaskType TaskType => taskType;
    public HoldingHandler HoldingHandler => holdingHandler;
    private void Start()
    {
        holdingHandler.ItemAdded += OnItemAdded;
        holdingHandler.ItemRemovedAll+=OnItemRemovedAll;
    }
    private void OnDestroy()
    {
        holdingHandler.ItemAdded -= OnItemAdded;
        holdingHandler.ItemRemovedAll-=OnItemRemovedAll;
    }
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
            if(!task.ForceToMoveThisTask&&task.Holder.HolderPositionForAI!=null)
            {
                SetDestination(task.Holder.HolderPositionForAI.position);
            }
            else
            {
                SetDestination(task.transform.position);
            }
            
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
    public void AddSpeed(float amount)
    {
        aIController.AddSpeed(amount);
    }



    public bool IsReachDestination()
    {
        return aIController.IsReachDestination();
    }
    public void SetDestination(Vector3 destination)
    {
        aIController.SetDestination(destination);
    }
    public void SetLocomotionValue(float desireValue)
    {
        float value = Mathf.Lerp(aIController.GetLocomotionValue(), desireValue, Time.deltaTime * 5);
        aIController.SetLocomotionValue(value);
    }
    public void SetCarryingAnimation(bool state)
    {
        aIController.SetCarryingAnimation(state);
    }
    public void SetStop(bool state)
    {
        aIController.Stop(state);
    }
    public void SetTaskType(TaskType taskType)
    {
        this.taskType = taskType;
    }
    private void OnItemAdded()
    {
        SetCarryingAnimation(true);
    }
    private void OnItemRemovedAll()
    {
        SetCarryingAnimation(false);
    }

}
