GymApp gymApp = new();
gymApp.Start();

public class WorkoutsMenu {
    public void Start(WorkoutsRepository workoutsRepo, LoggedWorkoutsRepository loggedWorkoutsRepo) {
        bool exited = false;

        while (!exited) {
            Console.WriteLine("--------------------------");
            Console.WriteLine("---- Current Workouts ----");
            //foreach (var (workoutID, workoutObj) in workoutsRepo.WorkoutsDict) {
            //    Console.WriteLine($"{workoutID}| {workoutObj.ToString()}");
            //}
            Console.WriteLine("---- Workouts Menu ----");
            Console.WriteLine("1: Make Workout");
            Console.WriteLine("2: Delete Workout");
            Console.WriteLine("3: Log Workout For Now");
            Console.WriteLine("4: Exit Menu");
            Console.WriteLine("-----------------------");
            string userStringInput = Console.ReadLine();
            if (int.TryParse(userStringInput, out int userInput) && userInput >= 1 && userInput <= 4) {
                switch (userInput) {
                    case 1:
                        MakeWorkout(workoutsRepo);
                        break;
                    case 2:
                        DeleteWorkout(workoutsRepo);
                        break;
                    case 3:
                        LogWorkout();
                        break;
                    case 4:
                        exited = true;
                        break;
                }
            }
            else {
                Console.WriteLine("Invalid option");
            }
        }
    }

    private void MakeWorkout(WorkoutsRepository workoutsRepo) {
        Console.WriteLine("Enter a workout ID for this new workout:");
        string newID = Console.ReadLine();
        foreach (string workoutID in workoutsRepo.WorkoutIDs) {
            if (newID == workoutID) {
                Console.WriteLine($"ID: {newID} already in use!");
                return;
            }
        }
        Console.WriteLine($"Made new workout with ID: {newID}");
        // print exercises, make exercises repo and class, it has name and changeable reps and sets per object
    }

    private void DeleteWorkout(WorkoutsRepository workoutsRepo) {
        Console.WriteLine("Enter the workout ID corresponding to the workout you want to delete:");
        string ID = Console.ReadLine();
        foreach (string workoutID in workoutsRepo.WorkoutIDs) {
            if (workoutID == ID) {
                workoutsRepo.WorkoutIDs.Remove(ID);
            }
        }
    }

    private void LogWorkout() {
        Console.WriteLine("Enter the workout ID corresponding to the workout you would like to log:");
        Console.WriteLine("hi");
    }
}
public class LoggedWorkoutsMenu {
    public void Start(LoggedWorkoutsRepository loggedWorkoutsRepo, WorkoutsRepository workoutsRepo) {

    }
}
public class PersonalRecordsMenu {
    public void Start(PersonalRecordsRepository personalRecordsRepo) {

    }
}
public class PersonalProfileMenu {
    public void Start(PersonalProfileRepository personalProfileRepo) {

    }
}
public class Repositories {
    public WorkoutsRepository WorkoutsRepo { get; }
    public LoggedWorkoutsRepository LoggedWorkoutsRepo { get; }
    public PersonalRecordsRepository PersonalRecordsRepo { get; }
    public PersonalProfileRepository PersonalProfileRepo { get; }

    public Repositories(string dataDirectory) {
        WorkoutsRepo = new WorkoutsRepository(dataDirectory + "");
        LoggedWorkoutsRepo = new LoggedWorkoutsRepository(dataDirectory + "");
        PersonalRecordsRepo = new PersonalRecordsRepository(dataDirectory + "");
        PersonalProfileRepo = new PersonalProfileRepository(dataDirectory + "");
    }
}
public class GymApp {
    private bool _exited = false;
    private Repositories Repos = new("");
    private WorkoutsMenu workoutsMenu = new();
    private LoggedWorkoutsMenu loggedWorkoutsMenu = new();
    private PersonalRecordsMenu personalRecordsMenu = new();
    private PersonalProfileMenu personalProfileMenu = new();
    public void Start() {
        while (!_exited) {
            Console.WriteLine("-----------------");
            Console.WriteLine("---- Gym App ----");
            Console.WriteLine("1: Workouts");
            Console.WriteLine("2: Logged Workouts");
            Console.WriteLine("3: PRs");
            Console.WriteLine("4: Personal Profile");
            Console.WriteLine("5: Exit App");
            Console.WriteLine("------------------");
            string userInputString = Console.ReadLine();
            if (int.TryParse(userInputString, out int userInput) && userInput <= 5 && userInput >= 1) {
                switch (userInput) {
                    case 1:
                        workoutsMenu.Start(Repos.WorkoutsRepo, Repos.LoggedWorkoutsRepo);
                        break;
                    case 2:
                        loggedWorkoutsMenu.Start(Repos.LoggedWorkoutsRepo, Repos.WorkoutsRepo);
                        break;
                    case 3:
                        personalRecordsMenu.Start(Repos.PersonalRecordsRepo);
                        break;
                    case 4:
                        personalProfileMenu.Start(Repos.PersonalProfileRepo);
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
public class Exercise {
    public string Name { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }

    public Exercise(string name, int sets, int reps) {
        Name = name;
        Sets = sets;
        Reps = reps;
    }
}
public class Workout {
    public string ID { get; init; }
    public List<Exercise> Exercises { get; private set; }
    public Workout(string id, List<Exercise> exercises) {
        ID = id;
        Exercises = exercises;
    }
}
public class WorkoutsRepository : DataHandler {
    public override string FilePath { get; init; }
    public List<string> WorkoutIDs { get; private set; } = new List<string>();
    public Dictionary<string, Workout> WorkoutsDict { get; private set; }
    public WorkoutsRepository(string filePath) {
        FilePath = filePath;
        Load();
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

