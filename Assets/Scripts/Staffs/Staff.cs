using UnityEngine;

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
    private Task task;
    public Task CurrentTask=>task;
    public StaffStatus staffStatus=> status;
    public void SetTask(Task task)
    {
        this.task = task;
        if(task==null){return;}
        SetDestination(task.transform.position);
        status = StaffStatus.MainTask;
    }
    public void SetStatus(StaffStatus status)
    {
        this.status = status;
    }
    public bool IsFinishedTaskBefore()
    {
        return task==null;
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
