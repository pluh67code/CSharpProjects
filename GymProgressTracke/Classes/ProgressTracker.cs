namespace GymProgressTracker.Classes;
public class ProgressTracker {
    public List<Exercise> Exercises { get; private set; }

    public ProgressTracker() {
        Exercises = new List<Exercise>();
    }
    public ProgressTracker(List<Exercise> exercises) {
        Exercises = exercises;
    }


    public void Add(string exerciseName, int weight, string weightUnit = "lbs") {
        foreach (var exercise in Exercises) {
            if (exercise.Name == exerciseName) {
                return;
            }
        }
        var newExercise = new Exercise(exerciseName, weight, weightUnit);
        Exercises.Add(newExercise);
        Console.WriteLine($"Added: {newExercise.ToString()}\n");
    }

    public void Remove(string exerciseName) {
        for (int i = 0; i < Exercises.Count; i++) {
            if (exerciseName == Exercises[i].Name) {
                Console.WriteLine($"Removed: {Exercises[i].ToString()}\n");
                Exercises.RemoveAt(i);
            }
        }
    }
    public void Update(string exerciseName, int newWeight) {
        for (int i = 0; i < Exercises.Count; i++) {
            if (exerciseName == Exercises[i].Name) {
                Exercises[i].UpdateWeight(newWeight);
                Console.WriteLine($"Updated {exerciseName}: {Exercises[i].ToString()}\n");
            }
        }
    }

    public void Show() {
        Console.WriteLine("Exercises:");
        foreach (var exercise in Exercises) {
            Console.WriteLine(exercise.ToString());
        }
        Console.WriteLine("");
    }
}

