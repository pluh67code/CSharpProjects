using GymProgressTracker.Classes;

var tracker = new ProgressTracker();
tracker.Add("Bench Press", 215);
tracker.Add("Snatch", 103, "kg");
tracker.Add("Clean & Jerk", 120, "kg");
tracker.Add("Back Squat", 175, "kg");




Console.WriteLine("Press any key to exit");
Console.ReadKey();

