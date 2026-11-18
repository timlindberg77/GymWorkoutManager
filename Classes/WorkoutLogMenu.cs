using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace GymWorkoutManager.Classes
{
    public class WorkoutLogMenu
    {
        public SpectreLogos spectReLogos = new SpectreLogos();

        public Datastore<Workout> workoutStore;

        public WorkoutLogMenu(Datastore<Workout> store)
        {
            workoutStore = store;
        }

        public bool workoutLogMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine(SpectreLogos.WorkoutLogMenyLogo());

                // Hämta alla workouts
                var workouts = workoutStore.GetAll();

                // Om det inte finns några workouts
                if (workouts.Count == 0)
                {
                    Console.WriteLine("No workouts saved yet.");
                    Console.WriteLine("Press ENTER to return to the menu");
                    Console.ReadLine();
                    Console.Clear();
                    return false;
                }

                // Sortera workouts efter datum
                var sortedWorkouts = workouts
                    .OrderByDescending(workout => workout.WorkoutDate)
                    .ToList();

                // Välj workout med piltangenterna
                Workout selectedWorkout = AnsiConsole.Prompt(
                    new SelectionPrompt<Workout>()
                        .Title("Select a workout:")
                        .PageSize(10)
                        .UseConverter(workout =>
                            $"{workout.WorkoutDate:yyyy-MM-dd HH:mm}")
                        .AddChoices(sortedWorkouts)
                );

                Console.Clear();

                // Vad vill användaren göra?
                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title(
                            $"Selected workout: [yellow]{selectedWorkout.WorkoutDate:yyyy-MM-dd HH:mm}[/]"
                        )
                        .AddChoices(
                            "Update workout",
                            "Delete workout",
                            "Back",
                            "Exit"
                        )
                );

                switch (choice)
                {


                    case "Update workout":
                        Console.WriteLine("Update workout selected.");
                        Console.ReadLine();
                        break;

                    case "Delete workout":
                        Console.WriteLine("Delete workout selected.");
                        Console.ReadLine();
                        break;

                    case "Back":
                        return false;

                    case "Exit":
                        Console.Clear();
                        Console.WriteLine("Thank you for using RepRange!");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}