using System.Text.Json;

namespace TaskTracker;

public class TaskHandler
{
    List<Task> taskList = new List<Task>();
    
    
    public void SaveTasks()
    {
        string json = JsonSerializer.Serialize(taskList, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("tasks.json", json);
    }

    public void LoadTasks()
    {
        
        if (!File.Exists("tasks.json"))
        {
            taskList = new List<Task>();
            return;
        } 
        
        string textReader = File.ReadAllText("tasks.json");

        if (string.IsNullOrWhiteSpace(textReader))
        {
            taskList = new List<Task>();
        }
        else
        {
            taskList = JsonSerializer.Deserialize<List<Task>>(textReader);
            if (taskList is null)
            {
                taskList = new List<Task>();
            }
            
            if (taskList.Count > 0)
            {
                int maxId = taskList.Max(t => t.taskId);
                Task.SetNextId(maxId + 1);
            }
            else
            {
                Console.WriteLine("No tasks found");
            }
        }
    }

    public void AddTask(string taskName)
    {
        Task task = new Task(taskName);
        taskList.Add(task);
        SaveTasks();
    }

    public void UpdateTask(int id, string description)
    {
        foreach (Task task in taskList)
        {
            if (id == task.taskId)
            {
                task.SetDescription(description);
                task.SetUpdatedAt();
                SaveTasks();
                break;
            }
        }
    }

    public void SetTaskStatus(string status, int id)
    {
        Task? taskToSetStatus = null;
        Status statusToSet;
        
        foreach (Task task in taskList)
        {
            if (id == task.taskId)
            {
                taskToSetStatus = task;
                break;
            }
        }

        if (taskToSetStatus != null)
        {
            if (Enum.TryParse(status, true, out statusToSet))
            {
                taskToSetStatus.SetStatus(statusToSet);
                taskToSetStatus.SetUpdatedAt();
                SaveTasks();
            }
            else
            {
                Console.WriteLine("Status " + status + " does not exist");
            }
        }
        else
        {
            Console.WriteLine("Task with id " + id + " does not exist");
        }
    }

    public void DeleteTask(int id)
    {
        Task? taskToRemove = null;
        
        foreach (Task task in taskList)
        {
            if (id == task.taskId)
            {
                taskToRemove = task;
                break;
            }
        }

        if (taskToRemove != null)
        {
            taskList.Remove(taskToRemove);
            SaveTasks();
            Console.WriteLine("Task with id " + id + " has been deleted");
        }
        else
        {
            Console.WriteLine("Task with id " +  id + " does not exist");
        }
    }

    public void ListTaskByStatus(string status)
    {
        Task? taskToList = null;
        Status statusToList;

        if (Enum.TryParse(status, true, out statusToList))
        {
            foreach (Task task in taskList)
            {
                if (task.GetStatus() == statusToList)
                {
                    Console.WriteLine(task.ToString());
                }

            }
        }
        else
        {
            Console.WriteLine("Status " + status + " does not exist");
        }
    }

    public void ListTasks()
    {
        foreach (Task task in taskList)
        {
            Console.WriteLine(task.ToString());
        }
    }
}