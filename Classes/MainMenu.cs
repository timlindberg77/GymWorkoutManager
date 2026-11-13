using System;
using System.Threading;
using System.Security.Cryptography;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace GymWorkoutManager.Classes
{
    public class MainMenu
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 1. HUVUDMENY
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ShowMainMenu()
        {
            ShowStartLogo();
            Console.WriteLine("Press ENTER to start");
            Console.ReadLine();
            Console.Clear();

            // laddningsbar innan huvudmenyn visas
            AnsiConsole.Progress()
                .Columns(
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn
                    {
                        CompletedStyle = new Style(Color.Blue),
                        RemainingStyle = new Style(Color.Grey)
                    },
                    new PercentageColumn(),
                    new SpinnerColumn())
                .Start(ctx =>
                {
                    var task = ctx.AddTask("Loading RepRange...", maxValue: 100);

                    while (!ctx.IsFinished)
                    {
                        task.Increment(2);      // hur mycket baren fylls per steg
                        Thread.Sleep(50);       // paus i millisekunder
                    }
                });

            Console.Clear();

            bool menuKeepRunning = true;

            while (menuKeepRunning)
            {
                ShowMenuLogo();

                string choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Welcome to RepRange")
                        .AddChoices("New Workout", "WorkoutLog", "Exit"));

                Console.Clear();

                switch (choice)
                {
                    case "New Workout":
                        // true = användaren valde Exit längre ner
                        bool exitProgram = NewWorkoutMenu();
                        if (exitProgram)
                        {
                            menuKeepRunning = false;
                        }
                        break;
                    case "WorkoutLog":
                        Console.WriteLine("WorkoutLog");
                        CleanConsole();
                        break;
                    case "Exit":
                        menuKeepRunning = false;
                        break;
                }
            }

            Console.WriteLine("You chose to end the program.");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 2. NEW WORKOUT
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // true = avsluta programmet, false = gå tillbaka
        private bool NewWorkoutMenu()
        {
            while (true)
            {
                ShowNewWorkOutLogo();

                string choiceNewWork = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Add an exercise")
                        .AddChoices("Strength training", "Cardio", "Back", "Exit"));

                switch (choiceNewWork)
                {
                    case "Strength training":
                        Console.Clear();
                        bool exitFromStrengthTrainig = StrengthTrainingMenu();
                        if (exitFromStrengthTrainig)
                        {
                            return true;
                        }
                        break;
                    case "Cardio":
                        Console.Clear();
                        bool exitFromCardio = CardioMenu();
                        if (exitFromCardio)
                        {
                            return true;
                        }
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 3. STRENGTH TRAINING
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // väljer muskelgrupp
        private bool StrengthTrainingMenu()
        {
            while (true)
            {
                ShowStrengthTrainingMenuLogo();

                string choiceMuscleGroup = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose a muscle group")
                        .AddChoices("Chest", "Back Muscles", "Shoulders", "Biceps", "Triceps", "Abs", "Legs", "Back", "Exit"));

                switch (choiceMuscleGroup)
                {
                    case "Chest":
                        Console.Clear();
                        bool exitFromStrengthTrainigChest = StrengthTrainingChestMenu();
                        if (exitFromStrengthTrainigChest)
                        {
                            return true;
                        }
                        break;
                    case "Back Muscles":
                        Console.Clear();
                        bool exitFromStrengthTrainigBackMuscles = StrengthTrainingBackMusclesMenu();
                        if (exitFromStrengthTrainigBackMuscles)
                        {
                            return true;
                        }
                        break;
                    case "Shoulders":
                        Console.Clear();
                        bool exitFromStrengthTrainigShoulders = StrengthTrainingShouldersMenu();
                        if (exitFromStrengthTrainigShoulders)
                        {
                            return true;
                        }
                        break;
                    case "Biceps":
                        Console.Clear();
                        bool exitFromStrengthTrainigBiceps = StrengthTrainingBicepsMenu();
                        if (exitFromStrengthTrainigBiceps)
                        {
                            return true;
                        }
                        break;
                    case "Triceps":
                        Console.Clear();
                        bool exitFromStrengthTrainigTriceps = StrengthTrainingTricepsMenu();
                        if (exitFromStrengthTrainigTriceps)
                        {
                            return true;
                        }
                        break;
                    case "Abs":
                        Console.Clear();
                        bool exitFromStrengthTrainigAbs = StrengthTrainingAbsMenu();
                        if (exitFromStrengthTrainigAbs)
                        {
                            return true;
                        }
                        break;
                    case "Legs":
                        Console.Clear();
                        bool exitFromStrengthTrainigLegs = StrengthTrainingLegsMenu();
                        if (exitFromStrengthTrainigLegs)
                        {
                            return true;
                        }
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // bröst
        private bool StrengthTrainingChestMenu()
        {
            while (true)
            {
                ShowStrengthTrainingChestMenuLogo();

                string choiceMuscleGroupChest = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Bench Press", "Pec Deck", "Dumbbell Press", "Chest Press", "Push-Ups", "Back", "Exit"));

                switch (choiceMuscleGroupChest)
                {
                    case "Bench Press":
                        RegisterStrengthWorkout("Bench Press");
                        CleanConsole();
                        break;
                    case "Pec Deck":
                        RegisterStrengthWorkout("Pec Deck");
                        CleanConsole();
                        break;
                    case "Dumbbell Press":
                        RegisterStrengthWorkout("Dumbbell Press");
                        CleanConsole();
                        break;
                    case "Chest Press":
                        RegisterStrengthWorkout("Chest Press");
                        CleanConsole();
                        break;
                    case "Push-Ups":
                        RegisterStrengthWorkout("Push-Ups");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // rygg
        private bool StrengthTrainingBackMusclesMenu()
        {
            while (true)
            {
                ShowStrengthTrainingBackMusclesMenuLogo();

                string choiceMuscleGroupBackMuscles = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Lat Pulldown", "Pull-Up", "Barbell Row", "Deadlift", "Cable Row", "Back", "Exit"));

                switch (choiceMuscleGroupBackMuscles)
                {
                    case "Lat Pulldown":
                        RegisterStrengthWorkout("Lat Pulldown");
                        CleanConsole();
                        break;
                    case "Pull-Up":
                        RegisterStrengthWorkout("Pull-Up");
                        CleanConsole();
                        break;
                    case "Barbell Row":
                        RegisterStrengthWorkout("Barbell Row");
                        CleanConsole();
                        break;
                    case "Deadlift":
                        RegisterStrengthWorkout("Deadlift");
                        CleanConsole();
                        break;
                    case "Cable Row":
                        RegisterStrengthWorkout("Cable Row");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // axlar
        private bool StrengthTrainingShouldersMenu()
        {
            while (true)
            {
                ShowStrengthTrainingShouldersMenuLogo();

                string choiceMuscleGroupShoulders = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Lateral raise", "Shoulder press", "Upright Row", "Face Pull", "Military press", "Back", "Exit"));

                switch (choiceMuscleGroupShoulders)
                {
                    case "Lateral raise":
                        RegisterStrengthWorkout("Lateral raise");
                        CleanConsole();
                        break;
                    case "Shoulder press":
                        RegisterStrengthWorkout("Shoulder press");
                        CleanConsole();
                        break;
                    case "Upright Row":
                        RegisterStrengthWorkout("Upright Row");
                        CleanConsole();
                        break;
                    case "Face Pull":
                        RegisterStrengthWorkout("Face Pull");
                        CleanConsole();
                        break;
                    case "Military press":
                        RegisterStrengthWorkout("Military press");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // biceps
        private bool StrengthTrainingBicepsMenu()
        {
            while (true)
            {
                ShowStrengthTrainingBicepsMenuLogo();

                string choiceMuscleGroupBiceps = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Dumbbell curl", "Cable curl", "Barbell curl", "Preacher curl", "Spider curl", "Back", "Exit"));

                switch (choiceMuscleGroupBiceps)
                {
                    case "Dumbbell curl":
                        RegisterStrengthWorkout("Dumbbell curl");
                        CleanConsole();
                        break;
                    case "Cable curl":
                        RegisterStrengthWorkout("Cable curl");
                        CleanConsole();
                        break;
                    case "Barbell curl":
                        RegisterStrengthWorkout("Barbell curl");
                        CleanConsole();
                        break;
                    case "Preacher curl":
                        RegisterStrengthWorkout("Preacher curl");
                        CleanConsole();
                        break;
                    case "Spider curl":
                        RegisterStrengthWorkout("Spider curl");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // triceps
        private bool StrengthTrainingTricepsMenu()
        {
            while (true)
            {
                ShowStrengthTrainingTricepsMenuLogo();

                string choiceMuscleGroupTriceps = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Tricep pushdown", "Tricep extension", "Overhead press", "Skull crusher", "Dips", "Back", "Exit"));

                switch (choiceMuscleGroupTriceps)
                {
                    case "Tricep pushdown":
                        RegisterStrengthWorkout("Tricep pushdown");
                        CleanConsole();
                        break;
                    case "Tricep extension":
                        RegisterStrengthWorkout("Tricep extension");
                        CleanConsole();
                        break;
                    case "Overhead press":
                        RegisterStrengthWorkout("Overhead press");
                        CleanConsole();
                        break;
                    case "Skull crusher":
                        RegisterStrengthWorkout("Skull crusher");
                        CleanConsole();
                        break;
                    case "Dips":
                        RegisterStrengthWorkout("Dips");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // mage
        private bool StrengthTrainingAbsMenu()
        {
            while (true)
            {
                ShowStrengthTrainingAbsMenuLogo();

                string choiceMuscleGroupAbs = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Crunch", "Cable crunch", "Leg raise", "Sit ups", "Plank", "Back", "Exit"));

                switch (choiceMuscleGroupAbs)
                {
                    case "Crunch":
                        RegisterStrengthWorkout("Crunch");
                        CleanConsole();
                        break;
                    case "Cable crunch":
                        RegisterStrengthWorkout("Cable crunch");
                        CleanConsole();
                        break;
                    case "Leg raise":
                        RegisterStrengthWorkout("Leg raise");
                        CleanConsole();
                        break;
                    case "Sit ups":
                        RegisterStrengthWorkout("Sit ups");
                        CleanConsole();
                        break;
                    case "Plank":
                        RegisterStrengthWorkout("Plank");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ben
        private bool StrengthTrainingLegsMenu()
        {
            while (true)
            {
                ShowStrengthTrainingLegsMenuLogo();

                string choiceMuscleGroupLegs = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Leg press", "Squats", "Leg extension", "Leg curl", "RDL", "Back", "Exit"));

                switch (choiceMuscleGroupLegs)
                {
                    case "Leg press":
                        RegisterStrengthWorkout("Leg press");
                        CleanConsole();
                        break;
                    case "Squats":
                        RegisterStrengthWorkout("Squats");
                        CleanConsole();
                        break;
                    case "Leg extension":
                        RegisterStrengthWorkout("Leg extension");
                        CleanConsole();
                        break;
                    case "Leg curl":
                        RegisterStrengthWorkout("Leg curl");
                        CleanConsole();
                        break;
                    case "RDL":
                        RegisterStrengthWorkout("RDL");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // frågar efter vikt och reps
        private void RegisterStrengthWorkout(string workoutType)
        {
            Console.Clear();

            AnsiConsole.MarkupLine($"[bold yellow]{workoutType}[/]");
            Console.WriteLine();

            // vikt i kg
            double weight = AnsiConsole.Ask<double>("Enter weight in kg:");

            // antal reps
            int reps = AnsiConsole.Ask<int>("Enter number of reps:");

            // Här ska en lista för träningspassen skapas senare
            // Träningspasset ska sparas i listan här
            // Exempel: workouts.Add($"{workoutType}: {weight} kg, {reps} repetitioner");

            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]Workout successfully registered![/]");

            Console.ReadKey();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 4. CARDIO
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // väljer typ av cardio
        private bool CardioMenu()
        {
            while (true)
            {
                ShowCardioMenuLogo();

                string cardioExercise = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Running", "Cycling", "Rowing", "Swimming", "Back", "Exit"));

                switch (cardioExercise)
                {
                    case "Running":
                        RegisterCardioWorkout("Running");
                        CleanConsole();
                        break;
                    case "Cycling":
                        RegisterCardioWorkout("Cycling");
                        CleanConsole();
                        break;
                    case "Rowing":
                        RegisterCardioWorkout("Rowing");
                        CleanConsole();
                        break;
                    case "Swimming":
                        RegisterCardioWorkout("Swimming");
                        CleanConsole();
                        break;
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // frågar efter distans och tid
        private void RegisterCardioWorkout(string workoutType)
        {
            Console.Clear();

            AnsiConsole.MarkupLine($"[bold yellow]{workoutType}[/]");
            Console.WriteLine();

            // distans i km
            double km = AnsiConsole.Ask<double>("Enter distance in km:");

            // tid i minuter
            double time = AnsiConsole.Ask<double>("Enter time in minutes:");

            // Här ska en lista för träningspassen skapas senare
            // Träningspasset ska sparas i listan här
            // Exempel: workouts.Add($"{workoutType}: {km} km, {time} minuter");

            Console.WriteLine();
            AnsiConsole.MarkupLine("[green]Workout successfully registered![/]");

            Console.ReadKey();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 5. HJÄLPMETOD
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // väntar på ENTER och rensar skärmen
        private void CleanConsole()
        {
            Console.WriteLine("Press ENTER to return to the menu");
            Console.ReadLine();
            Console.Clear();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 6. LOGOTYPER
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        // startlogon
        private void ShowStartLogo()
        {
            Console.WriteLine("\u001b[0;34m▄▄\u001b[0;37m \u001b[0;34m▄▄\u001b[0;37m \u001b[0;34m▄▄\u001b[0;37m  \u001b[0;34m▄▄▄\u001b[0;37m  \u001b[0;34m▓█\u001b[0;37m     \u001b[0;34m▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m  \u001b[0;34m▄▄▄▄\u001b[0;37m \u001b[0;34m▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m       \u001b[0;34m▓█▄\u001b[0;37m    \u001b[0;34m▄▄▄\u001b[0;37m       \u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m  \u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄▄\u001b[0;37m \u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄▄\u001b[0;37m  \u001b[0;34m▄▄▄\u001b[0;37m \u001b[0m\r\n\u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m    \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m      \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;34m▄▄\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m      \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0m\r\n\u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m    \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0;37m      \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m      \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0m\r\n\u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m      \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m      \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m    \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m    \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;34m▀▀▀\u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0m\r\n\u001b[0;37m \u001b[0;34m▀▀▀\u001b[0;37m \u001b[0;34m▀▀▀\u001b[0;37m  \u001b[0;34m▀▀▀▀\u001b[0;37m \u001b[0;94m▀\u001b[0;34m▀▀▀▀\u001b[0;37m  \u001b[0;34m▀▀▀\u001b[0;37m   \u001b[0;34m▀▀▀\u001b[0;37m  \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m  \u001b[0;34m▀▀▀▀\u001b[0;37m      \u001b[0;94m▀\u001b[0;34m▀▀▀\u001b[0;37m   \u001b[0;34m▀▀▀\u001b[0;37m       \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m     \u001b[0;34m▀▀▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀\u001b[0;37m  \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m     \u001b[0;34m▀▀▀▀\u001b[0;37m \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m  \u001b[0;34m▀▀▀▀\u001b[0m\r\n\u001b[0;37m                                                                                  \u001b[0;34m▀▀\u001b[0;37m                       \u001b[0;34m▀▀▀▀\u001b[0;37m      \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // huvudmenyn
        private void ShowMenuLogo()
        {
            Console.WriteLine("\u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄\u001b[0;37m  \u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄▄\u001b[0;37m \u001b[0;34m▄▄▄▄\u001b[0;37m   \u001b[0;34m▄▄▄▄\u001b[0;37m  \u001b[0;34m▄▄▄\u001b[0;37m \u001b[0m\r\n\u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0m\r\n\u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀▀\u001b[0m\r\n\u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m    \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m    \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m \u001b[0;34m▀▀▀\u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓\u001b[0;34m▓\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0m\r\n\u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m     \u001b[0;34m▀▀▀▀\u001b[0;37m \u001b[0;94;44m▒\u001b[0;34m█▀▀\u001b[0;37m  \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m     \u001b[0;34m▀▀▀▀\u001b[0;37m \u001b[0;94m▀\u001b[0;34m▀\u001b[0;37m \u001b[0;34m▀▀\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;37m \u001b[0;94;44m▓░\u001b[0;37m  \u001b[0;34m▀▀▀▀\u001b[0m\r\n\u001b[0;37m            \u001b[0;34m▀▀\u001b[0;37m                       \u001b[0;34m▀▀▀▀\u001b[0;37m      \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // new workout
        private void ShowNewWorkOutLogo()
        {
            Console.WriteLine("\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m     \u001b[0;94;44m███\u001b[0;37m      \u001b[0;94;44m███\u001b[0;37m     \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m█████▓▓██\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;94m█▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94m▄▄▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m      \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94m▄▄▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;94m▄▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m    \u001b[0;94;44m█▓▓\u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m▒▒▓\u001b[0;94m▀\u001b[0;94;44m██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒░▒\u001b[0;37m \u001b[0;94;44m▓▓▒\u001b[0;37m      \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒░▒\u001b[0;37m \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▒▓▓██▓\u001b[0;94m█\u001b[0;37m  \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m    \u001b[0;94;44m▒▒▒\u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;94;44m░\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m      \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░\u001b[0;34m█\u001b[0;94;44m░\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m    \u001b[0;94;44m░░ \u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░  \u001b[0;34m█▀\u001b[0;94;44m     \u001b[0;37m      \u001b[0;94;44m░░  \u001b[0;34m█▀\u001b[0;94;44m     \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m    \u001b[0;94;44m░  \u001b[0;37m   \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // strength training
        private void ShowStrengthTrainingMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m█████▓▓██\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m   \u001b[0;94;44m█████▓▓██\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m      \u001b[0;94;44m█████▓▓██\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m  \u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m          \u001b[0;94;44m█▓▓\u001b[0;37m    \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;94m█▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m          \u001b[0;94;44m█▓▓\u001b[0;37m    \u001b[0;94;44m▓▓█\u001b[0;94m▄▄▄\u001b[0;94;44m█▓▓\u001b[0;37m         \u001b[0;94;44m█▓▓\u001b[0;37m    \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;94m█▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;94m█▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m    \u001b[0;94;44m▒▒▒\u001b[0;37m    \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▒▓\u001b[0;94m▀\u001b[0;94;44m██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m \u001b[0;94;44m▒█▓▓▒\u001b[0;37m    \u001b[0;94;44m▒▒▒\u001b[0;37m    \u001b[0;94;44m▒▒▓▓██▓▓▒\u001b[0;37m         \u001b[0;94;44m▒▒▒\u001b[0;37m    \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;94m▀\u001b[0;94;44m██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;94m▀\u001b[0;94;44m██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m \u001b[0;94;44m▒█▓▓▒\u001b[0m\r\n\u001b[0;37m      \u001b[0;94;44m░░▒\u001b[0;37m    \u001b[0;94;44m░░ \u001b[0;37m    \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m    \u001b[0;94;44m░░ \u001b[0;37m    \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m         \u001b[0;94;44m░░ \u001b[0;37m    \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m█\u001b[0;37m    \u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m         \u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░ \u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m█\u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // bröst
        private void ShowStrengthTrainingChestMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m█████▓▓██\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;94m▄▄▄\u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m          \u001b[0;94;44m█▓▓\u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▒▓▓██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m    \u001b[0;94;44m▒▒▒\u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m           \u001b[0;94;44m░░▒\u001b[0;37m    \u001b[0;94;44m░░ \u001b[0;37m   \u001b[0m\r\n\u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m░  \u001b[0;37m   \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // rygg
        private void ShowStrengthTrainingBackMusclesMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m \u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m      \u001b[0;94;44m███\u001b[0;94m██▄██\u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m     \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;94m▄▄\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m      \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▒▓▒\u001b[0;37m \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m       \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▒▓▓██▓\u001b[0;94m█\u001b[0;37m       \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m░▒░\u001b[0;37m \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m  \u001b[0;94m▀\u001b[0;94;44m░░▒\u001b[0;37m      \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;34m▀▀▀\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m       \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m           \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░      \u001b[0;34m▀\u001b[0;37m \u001b[0;94;44m░░ \u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m      \u001b[0;94;44m░░ \u001b[0;37m     \u001b[0;94;44m   \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // axlar
        private void ShowStrengthTrainingShouldersMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m   \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m     \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m       \u001b[0;94;44m▓▓█\u001b[0;94m▄▄▄\u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓▓██▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;37m      \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m       \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m \u001b[0;94;44m░░       \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m▀\u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // biceps
        private void ShowStrengthTrainingBicepsMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▒▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m             \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░      \u001b[0;34m▀\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░░\u001b[0;37m       \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // triceps
        private void ShowStrengthTrainingTricepsMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m█████▓▓██\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m    \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;37m   \u001b[0;94;44m▒▒▒\u001b[0;37m    \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▒▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;37m   \u001b[0;94;44m░░ \u001b[0;37m    \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m░░▒\u001b[0;37m             \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m    \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░░\u001b[0;37m       \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // mage
        private void ShowStrengthTrainingAbsMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m       \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░ \u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m▀\u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ben
        private void ShowStrengthTrainingLegsMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m███\u001b[0;37m     \u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m███████\u001b[0;37m   \u001b[0;94;44m█████████\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m       \u001b[0;94;44m▓▓█\u001b[0;37m      \u001b[0m\r\n\u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓▓▒\u001b[0;37m   \u001b[0;94;44m▒▓▓\u001b[0;37m \u001b[0;94;44m▒█▓▓▒\u001b[0;37m \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0m\r\n\u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m       \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m█\u001b[0;37m \u001b[0;94;44m░░ \u001b[0;34m███\u001b[0;94;44m░  \u001b[0m");
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // cardio
        private void ShowCardioMenuLogo()
        {
            Console.WriteLine("\u001b[0;94;44m███████\u001b[0;37m \u001b[0;94;44m█████████\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m█\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m██\u001b[0;94m▄\u001b[0;37m \u001b[0;94;44m███\u001b[0;37m \u001b[0;94;44m███\u001b[0;94m███\u001b[0;94;44m███\u001b[0m\r\n\u001b[0;94;44m▓▓█\u001b[0;37m     \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m \u001b[0;94;44m▓▓█\u001b[0;37m   \u001b[0;94;44m█▓▓\u001b[0m\r\n\u001b[0;94;44m▒▓▓\u001b[0;37m     \u001b[0;94;44m▒▓▓▓▒░▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓▓▒░▓▓\u001b[0;37m  \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m \u001b[0;94;44m▒▒▓\u001b[0;37m   \u001b[0;94;44m▓▓▒\u001b[0m\r\n\u001b[0;94;44m▒▒░\u001b[0;37m     \u001b[0;94;44m▒▒░\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m \u001b[0;94;44m░░▒\u001b[0;37m   \u001b[0;94;44m░░▒\u001b[0m\r\n\u001b[0;94;44m░░     \u001b[0;37m \u001b[0;94;44m░░ \u001b[0;37m   \u001b[0;94;44m░  \u001b[0;37m \u001b[0;94;44m░░░\u001b[0;37m   \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░      \u001b[0;34m▀\u001b[0;37m \u001b[0;94;44m ░░\u001b[0;37m \u001b[0;94;44m░░       \u001b[0m");
        }

    }
}