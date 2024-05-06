using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    private List<Task> toDoTasks = new List<Task>();

    public static TaskManager Instance { get; private set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this);
        }
    }
    public void AddTask(Task task)
    {
        if(toDoTasks.Contains(task)){return;}
        toDoTasks.Add(task);
        //task.Status = MyTaskStatus.Nothing;
    }
    public void RemoveTask(Task task)
    {
        //task.Status = MyTaskStatus.Nothing;
        toDoTasks.Remove(task);
    }
    public Task GetCurrentTask(Vector3 position, TaskType taskType)
    {
        if(toDoTasks.Count == 0){return null;}
        float minDistance = float.MaxValue;
        Task currentTask = null;
        foreach(Task task in toDoTasks)
        {
            if(taskType!=task.TaskType){continue;}
            float distance = (task.transform.position-position).sqrMagnitude;
            if(distance<minDistance)
            {
                minDistance = distance;
                currentTask = task;
            }
        }
        return currentTask;
    }
    public bool HasTask()
    {
        return toDoTasks.Count > 0; 
    }
    public int GetNumberTask()
    {
        return toDoTasks.Count; 
    }

}
