using System;
using System.Collections.Generic;
using System.Text;

namespace GymWorkoutManager.Classes
{
    public class Workout
    {
        // Sätter datumet för workouts
        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        // Skapat en lista för att lagra alla Workouts
        public List<Exercise> Exercises { get; set; } = new();

    }
}
