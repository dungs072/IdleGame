using System.Collections;
using System.Collections.Generic;
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
        toDoTasks.Add(task);
    }
    public void RemoveTask(Task task)
    {
        toDoTasks.Remove(task);
    }
    public Task GetCurrentTask(Vector3 position)
    {
        if(toDoTasks.Count == 0){return null;}
        float minDistance = float.MaxValue;
        Task currentTask = null;
        foreach(Task task in toDoTasks)
        {
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

}
