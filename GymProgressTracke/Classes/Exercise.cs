namespace GymProgressTracker.Classes;   

public class Exercise {
    public string Name { get; private set; }
    public int Weight { get; private set; }
    public string WeightUnit { get; private set; }

    public Exercise(string exerciseName, int weight, string weightUnit) {
        Name = exerciseName;
        Weight = weight;
        WeightUnit = weightUnit;
    }

    public override string ToString() {
        return $"{Name} - {Weight}{WeightUnit}";
    }

    public void UpdateWeight(int newWeight) {
        Weight = newWeight;
    }
}

