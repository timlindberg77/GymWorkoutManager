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

        public Datastore<Workout> workoutStore; // Kopplar datastore för att komma åt alla pass

        public WorkoutLogMenu(Datastore<Workout> store) // Tar emot Datastore med alla pass och sparar den i fältet
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
                            $"{workout.Name} - {workout.WorkoutDate:yyyy-MM-dd HH:mm}")
                        .AddChoices(sortedWorkouts)
                );

                Console.Clear();

                // Vad vill användaren göra?
                string choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title(
                        $"Selected workout: [yellow]{selectedWorkout.Name} - {selectedWorkout.WorkoutDate:yyyy-MM-dd HH:mm}[/]"
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

                        // Steg 1: välj övning
                        Exercise selectedExercise = AnsiConsole.Prompt(
                            new SelectionPrompt<Exercise>()
                                .Title("Select an exercise:")
                                .UseConverter(exercise => exercise.Name)
                                .AddChoices(selectedWorkout.Exercises)
                        );

                        // Ett cardioset har km eller tid, ett styrkeset har vikt och reps
                        bool isCardio = selectedExercise.Sets.Any(set => set.Km > 0 || set.Time > 0);

                        // Steg 2: välj set (olika text för cardio och styrka)
                        WorkSet selectedSet = AnsiConsole.Prompt(
                            new SelectionPrompt<WorkSet>()
                                .Title("Select a set:")
                                .UseConverter(set => isCardio
                                    ? $"{set.Km} km in {set.Time} minutes"
                                    : $"{set.Weight} kg x {set.RepCount}")
                                .AddChoices(selectedExercise.Sets)
                        );

                        // Steg 3: fråga efter nya värden och skriv över setet
                        if (isCardio)
                        {
                            double newKm = AnsiConsole.Ask<double>("Enter new distance in km:");
                            double newTime = AnsiConsole.Ask<double>("Enter new time in minutes:");

                            selectedSet.Km = newKm;
                            selectedSet.Time = newTime;
                        }
                        else
                        {
                            double newWeight = AnsiConsole.Ask<double>("Enter new weight in kg:");
                            int newReps = AnsiConsole.Ask<int>("Enter new number of reps:");

                            selectedSet.Weight = newWeight;
                            selectedSet.RepCount = newReps;
                        }

                        // Steg 4: spara ändringen till filen
                        workoutStore.SaveToJson();

                        AnsiConsole.MarkupLine("[green]Your workout has been updated![/]");
                        AnsiConsole.MarkupLine("Press any key to continue...");
                        Console.ReadKey();
                        break;

                    case "Delete workout":

                        // Frågar med pilval så att man inte raderar av misstag
                        string answer = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                                .Title("Are you sure you want to delete this workout?")
                                .AddChoices("No", "Yes"));

                        if (answer == "Yes")
                        {
                            // Tar bort passet ur listan
                            workoutStore.RemoveItem(selectedWorkout);

                            // Sparar ändringen till filen
                            workoutStore.SaveToJson();

                            AnsiConsole.MarkupLine("[green]Your workout has been deleted![/]");
                            AnsiConsole.MarkupLine("Press any key to continue...");
                            Console.ReadKey();
                        }
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