using System.Reflection.Metadata.Ecma335;

TaskManager taskManager = new();
TaskApp taskApp = new(taskManager);

taskApp.Start();

Console.WriteLine("\nPress any key to exit");
Console.ReadKey();

public class Task {
    public string ID { get; private set; }
    public string Description { get; private set; }
    public Task(string id, string description) {
        ID = id;
        Description = description;
    }

    // changeID and changeDescription currently not in use
    public void ChangeID(string newID) {
        ID = newID;
    }

    public void ChangeDescription(string newDescription) {
        Description = newDescription;
    }

    public override string ToString() => $"{ID}: {Description}";
}

public class TaskApp {
    private readonly TaskManager _taskManager;
    public TaskApp(TaskManager taskManager) {
        _taskManager = taskManager;
    }

    public void Start() {
        bool exited = false;
        while (!exited) {
            Console.WriteLine("\n---- Task Manager App ----");
            Console.WriteLine("1: View Tasks");
            Console.WriteLine("2: Add Task");
            Console.WriteLine("3: Remove Task");
            Console.WriteLine("4: Exit App");
            var userStringInput = Console.ReadLine();
            switch (userStringInput) {
                case "1":
                    _taskManager.ViewTasks();
                    break;
                case "2":
                    string idToAdd = "";

                    do {
                        Console.WriteLine("\nEnter a task ID:");
                        idToAdd = Console.ReadLine().Trim();
                    }
                    while (_taskManager.TaskExists(idToAdd) && idToAdd != "nvm");

                    if (idToAdd == "nvm") {
                        Console.WriteLine("\nQuit adding without changes");
                        break;
                    }

                    Console.WriteLine("\nEnter the description for this task:");
                    var description = Console.ReadLine().Trim();

                    Task newTask = new(idToAdd, description);
                    _taskManager.AddTask(newTask);
                    Console.WriteLine($"\nMade new task | {newTask.ToString()}");
                    break;
                case "3":
                    if (_taskManager.HasNoTasks()) {
                        break;
                    }

                    string idToRemove;

                    do {
                        Console.WriteLine("\nEnter the task ID to remove");
                        idToRemove = Console.ReadLine().Trim();
                    }
                    while (!_taskManager.TaskExists(idToRemove) && idToRemove != "nvm");

                    if (idToRemove == "nvm") {
                        Console.WriteLine("\nQuit removal without changes");
                        break;
                    }

                    _taskManager.RemoveTask(idToRemove);
                    Console.WriteLine($"\nRemoved task with ID: {idToRemove}");
                    break;
                case "4":
                    exited = true;
                    break;
            }
        }
    }
}

public class TaskRepository {
    public string FilePath { get; init; } 
    public TaskRepository(string filePath) {
        FilePath = filePath;
    }
    public void Save(List<Task> Tasks) {

    }
    public List<Task> Load() {
        return new List<Task>();
    }
}   
public class TaskManager {
    private readonly TaskRepository _repo = new("dummy file path");
    public List<Task> Tasks { get; private set; } = new List<Task>();
    public TaskManager() {
        Tasks = _repo.Load();
    }

    public void AddTask(Task taskToAdd) {
        Tasks.Add(taskToAdd);
        _repo.Save(Tasks);
    }

    public void RemoveTask(string taskID) {
        foreach (var task in Tasks) {
            if (task.ID == taskID) {
                Tasks.Remove(task);
                break;
            }
        }
        _repo.Save(Tasks);

    }
    public void ViewTasks() {
        if (HasNoTasks()) {
            return;
        }
        Console.WriteLine("");
        foreach (var task in Tasks) {
            Console.WriteLine(task.ToString());
        }
    }

    public bool TaskExists(string taskID) {
        foreach (var task in Tasks) {
            if (task.ID == taskID) {
                return true;
            }
        }
        return false;
    }

    public bool HasNoTasks() {
        if (Tasks.Count == 0) {
            Console.WriteLine("\nTask list is empty!");
            return true;
        }
        return false; ;
    }
}