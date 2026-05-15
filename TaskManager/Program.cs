interface FileManager {
    void Save();
    void Load();
}
public class Task {
    public string ID { get; init; }
    // public string - find name for content of task, or use list of strings
    public Task(string id) {
        ID = id;
    }
}

public class TaskRepository {
    public List<string> TaskIDs;

}
public class TaskManager {
    public List<Task> Tasks { get; private set; }
    
    public TaskManager(List<Task> tasks) {
        Tasks = tasks;
    }
    public TaskManager() { }
    public void Start() {
        bool exited = false;
        Console.WriteLine("Start");
    }

    public void AddTask(Task taskToAdd) {
        Tasks.Add(taskToAdd);
    }

    public void RemoveTask(string taskID) {
        foreach (var task in Tasks) { 
            if (task.ID == taskID) {
                Tasks.Remove(task);
            }
        }
    }
}