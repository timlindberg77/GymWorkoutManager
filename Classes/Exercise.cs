using System;
using System.Collections.Generic;
using System.Text;

namespace GymWorkoutManager.Classes
{
    public class Exercise
    {
        public string Name { get; set; }

        // Lista på alla sets i en Workout
        public List<WorkSet> Sets = new List<WorkSet>();

    }
}
