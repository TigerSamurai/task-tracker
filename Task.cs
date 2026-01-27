using System.Runtime.CompilerServices;

namespace TaskTracker;

public class Task
{
    private static int idCounter = 1;
    public int taskId { get; }
    public string description { get; set;}
    public Status status { get; set; }
    public DateTime createdAt { get; }
    public DateTime? updatedAt { get; set; }

    public Task(string description)
    {
        this.description = description;
        taskId = idCounter;
        idCounter++;
        createdAt = DateTime.UtcNow;
        status = Status.TODO;
    }

    public static void SetNextId(int nextId)
    {
        idCounter = nextId;
    }

    public DateTime GetCreatedAt()
    {
        return createdAt;
    }

    public DateTime? GetUpdatedAt()
    {
        return updatedAt;
    }

    public void SetUpdatedAt()
    {
        updatedAt = DateTime.UtcNow;
    }

    public Status GetStatus()
    {
        return status;
    }

    public void SetStatus(Status statusToSet)
    {
        this.status = statusToSet;
    }

    public string GetDescription()
    {
        return description;
    }

    public void SetDescription(string description)
    { 
        this.description = description;
    }
    
    public override string ToString()
    {
        return "ID: " +  taskId + ", Description: " + description +  ", Status: " + status
            + " CreatedAt: " + createdAt + ", UpdatedAt: " + updatedAt;
    }
}