using System.Text.Json;
using TaskTracker;
using Task = TaskTracker.Task;

TaskHandler taskHandler = new TaskHandler();

taskHandler.LoadTasks();

if (args.Length == 0)
{
    Console.WriteLine("No command provided");
    return;
}

string command = args[0];

if (args.Length == 1)
{
    if (command.Equals("list"))
    {
        taskHandler.ListTasks();
    }
    else
    {
        Console.WriteLine("Unknown command");
        return;
    }
} else if (args.Length == 2)
{
    if (command.Equals("add"))
    {
        string description = string.Join(" ", args.Skip(1));
        taskHandler.AddTask(description);
    } else if (command.Equals("delete"))
    {
        int id = int.Parse(args[1]);
        taskHandler.DeleteTask(id);
    }
    else if (command.Equals("list"))
    {
        string status = args[1];
        taskHandler.ListTaskByStatus(status);
    }
    else
    {
        Console.WriteLine("Unknown command");
        return;
    }
} else if (args.Length == 3)
{
    if (command.Equals("update"))
    {
        string description = string.Join(" ", args.Skip(2));
        int id = int.Parse(args[1]);
        taskHandler.UpdateTask(id, description);
    } else if (command.Equals("mark"))
    {
        string status = args[1];
        int id = int.Parse(args[2]);
        taskHandler.SetTaskStatus(status, id);
    }
} 
else
{
    Console.WriteLine("Unknown command");
}
