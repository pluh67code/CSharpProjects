GymApp gymApp = new();
gymApp.Start();
public class Repositories {
    public WorkoutRepository WorkoutsRepo { get; }
    public LoggedWorkoutsRepository LoggedWorkoutsRepo { get; }
    public PersonalRecordsRepository PersonalRecordsRepo { get; }
    public PersonalProfileRepository PersonalProfileRepo { get; }

    public Repositories(string dataDirectory) {
        WorkoutsRepo = new WorkoutRepository(dataDirectory + "");
        LoggedWorkoutsRepo = new LoggedWorkoutsRepository(dataDirectory + "");
        PersonalRecordsRepo = new PersonalRecordsRepository(dataDirectory + "");
        PersonalProfileRepo = new PersonalProfileRepository(dataDirectory + "");
    }
}
public class GymApp {
    private bool _exited = false;
    private Repositories Repos = new("");
    public void Start() {
        while (!_exited) {
            Console.WriteLine("==== Gym App ====");
            Console.WriteLine("1: Workouts");
            Console.WriteLine("2: Logged Workouts");
            Console.WriteLine("3: PRs");
            Console.WriteLine("4: Personal Profile");
            Console.WriteLine("5: Exit App");
            string userInputString = Console.ReadLine();
            if (int.TryParse(userInputString, out int userInput) && userInput <= 5 && userInput >= 1) {
                switch (userInput) {
                    case 1:
                        
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        _exited = true;
                        break;
                }
            }
            else {
                Console.WriteLine("Invalid option");
            }
        }
    }
}

public abstract class DataHandler {
    public abstract string FilePath { get; init; }
    public abstract void Save();
    public abstract void Load();
}

public class WorkoutRepository : DataHandler {
    public override string FilePath { get; init; }
    public List<string> WorkoutIDs { get; private set; }

    public WorkoutRepository(string filePath) {
        FilePath = filePath;
        this.Load();
    }

    public override void Save() {
        // save ids to filepath
        Console.WriteLine($"Saved to {FilePath}");
    }

    public override void Load() {
        // load from file into WorkoutIDs
        Console.WriteLine("load");
    }

    public override string ToString() {
        string result = "";
        foreach (string workoutID in WorkoutIDs) {
            result += workoutID + " ";
        }
        return result;
    }

    public void AddWorkout(string workoutIDToAdd) {
        foreach (string ID in WorkoutIDs) {
            if (ID == workoutIDToAdd) {
                Console.WriteLine($"ID: {workoutIDToAdd} already exists!");
                return;
            }
        }
        WorkoutIDs.Add(workoutIDToAdd);
    }

    public void RemoveWorkout(string workoutIDToRemove) {
        for (int i = 0; i < WorkoutIDs.Count; i++) {
            if (WorkoutIDs[i] == workoutIDToRemove) {
                WorkoutIDs.RemoveAt(i);
                Console.WriteLine($"Removed: {workoutIDToRemove}");
            }
        }
    }
}


public class LoggedWorkoutsRepository : DataHandler{
    public override string FilePath { get; init; }
    public LoggedWorkoutsRepository(string filePath) {
        FilePath = filePath;
    }

    public override void Save() {
        Console.WriteLine($"Saved to {FilePath}");
    }
    public override void Load() {
        Console.WriteLine("load");
    }

}

public class PersonalRecordsRepository : DataHandler {
    public override string FilePath { get; init; }

    public PersonalRecordsRepository(string filePath) {
        FilePath = filePath;
        
    }

    public override void Save() { 
        Console.WriteLine("save");
    }
    public override void Load() {
        Console.WriteLine("load");
    }
}

public class PersonalProfileRepository : DataHandler {
    public override string FilePath { get; init; }

    public PersonalProfileRepository(string filePath) {
        FilePath = filePath;
    }

    public override void Save() {
        Console.WriteLine("save"); 
    }
    public override void Load() {
        Console.WriteLine("load");
    }
}

