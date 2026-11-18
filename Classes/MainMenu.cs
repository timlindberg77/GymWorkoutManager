using System;
using System.Threading;
using System.Security.Cryptography;
using Spectre.Console;
using Spectre.Console.Rendering;


namespace GymWorkoutManager.Classes
{
    public class MainMenu
    {
        public WorkoutLogMenu workoutmenu; 
        public Datastore<Workout> WorkoutStore = new();
        public SpectreFunktion spectreFunktion = new SpectreFunktion();
        public SpectreLogos spectreLogos = new SpectreLogos();
        private Workout? CurrentWorkout { get; set; } //passet som pågår just nu (null = inget pass)


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // 1. HUVUDMENY
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void ShowMainMenu()
        {
            workoutmenu = new(WorkoutStore);
            Console.WriteLine(SpectreLogos.LogoStart());
            Console.WriteLine("Press ENTER to start");
            Console.ReadLine();
            Console.Clear();


            spectreFunktion.ShowLoadingBar();

            Console.Clear();

            bool menuKeepRunning = true;

            while (menuKeepRunning)
            {
                Console.WriteLine(SpectreLogos.MenuLogo());

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
                        workoutmenu.workoutLogMenu();
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
                Console.WriteLine(SpectreLogos.NewWorkOutLogo());

                string choiceNewWork = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Add an exercise")
                        .AddChoices("Strength training", "Cardio", "Back", "Exit"));

                switch (choiceNewWork)
                {
                    case "Strength training":
                        Console.Clear();
                        CurrentWorkout = new Workout(); //skapar en ny workout
                        bool exitFromStrengthTrainig = StrengthTrainingMenu();
                        if (exitFromStrengthTrainig)
                        {
                            return true;
                        }
                        EndWorkoutStrength();
                        break;
                    case "Cardio":
                        Console.Clear();
                        CurrentWorkout = new Workout();
                        bool exitFromCardio = CardioMenu();
                        if (exitFromCardio)
                        {
                            return true;
                        }
                        //Lägg till spara funktionen
                        EndWorkoutCardio();
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
                Console.WriteLine(SpectreLogos.StrengthTrainingMenuLogo());

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
                Console.WriteLine(SpectreLogos.StrengthTrainingChestMenuLogo());

                string choiceMuscleGroupChest = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Bench Press", "Pec Deck", "Dumbbell Press", "Chest Press", "Push-Ups", "Back", "Exit"));

                switch (choiceMuscleGroupChest)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupChest); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // rygg
        private bool StrengthTrainingBackMusclesMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingBackMusclesMenuLogo());

                string choiceMuscleGroupBackMuscles = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Lat Pulldown", "Pull-Up", "Barbell Row", "Deadlift", "Cable Row", "Back", "Exit"));

                switch (choiceMuscleGroupBackMuscles)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupBackMuscles); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // axlar
        private bool StrengthTrainingShouldersMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingShouldersMenuLogo());

                string choiceMuscleGroupShoulders = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Lateral raise", "Shoulder press", "Upright Row", "Face Pull", "Military press", "Back", "Exit"));

                switch (choiceMuscleGroupShoulders)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupShoulders); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // biceps
        private bool StrengthTrainingBicepsMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingBicepsMenuLogo());

                string choiceMuscleGroupBiceps = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Dumbbell curl", "Cable curl", "Barbell curl", "Preacher curl", "Spider curl", "Back", "Exit"));

                switch (choiceMuscleGroupBiceps)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupBiceps); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // triceps
        private bool StrengthTrainingTricepsMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingTricepsMenuLogo());

                string choiceMuscleGroupTriceps = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Tricep pushdown", "Tricep extension", "Overhead press", "Skull crusher", "Dips", "Back", "Exit"));

                switch (choiceMuscleGroupTriceps)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupTriceps); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // mage
        private bool StrengthTrainingAbsMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingAbsMenuLogo());

                string choiceMuscleGroupAbs = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Crunch", "Cable crunch", "Leg raise", "Sit ups", "Plank", "Back", "Exit"));

                switch (choiceMuscleGroupAbs)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterStrengthWorkout(choiceMuscleGroupAbs); break;
                }
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // ben
        private bool StrengthTrainingLegsMenu()
        {
            while (true)
            {
                Console.WriteLine(SpectreLogos.StrengthTrainingLegsMenuLogo());

                string choiceMuscleGroupLegs = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Leg press", "Squats", "Leg extension", "Leg curl", "RDL", "Back", "Exit"));

                switch (choiceMuscleGroupLegs)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                        ;
                    default: RegisterStrengthWorkout(choiceMuscleGroupLegs); break;
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

            Workout? workout = CurrentWorkout;
            if (workout == null) return;

            Exercise? exercise = workout.Exercises.FirstOrDefault(existingExercise => existingExercise.Name == workoutType);
            if (exercise == null)
            {
                exercise = new Exercise { Name = workoutType };
                workout.Exercises.Add(exercise);
            }
            exercise.Sets.Add(new WorkSet { Weight = weight, RepCount = reps });

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
                Console.WriteLine(SpectreLogos.CardioMenuLogo());

                string cardioExercise = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Choose an exercise")
                        .AddChoices("Running", "Cycling", "Rowing", "Swimming", "Back", "Exit"));

                switch (cardioExercise)
                {
                    case "Back":
                        Console.Clear();
                        return false;
                    case "Exit":
                        return true;
                    default: RegisterCardioWorkout(cardioExercise); break;
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

            Workout? workout = CurrentWorkout;
            if (workout == null) return;

            Exercise? exercise = workout.Exercises.FirstOrDefault(existingExercise => existingExercise.Name == workoutType);
            if (exercise == null)
            {
                exercise = new Exercise { Name = workoutType };
                workout.Exercises.Add(exercise);
            }
            exercise.Sets.Add(new WorkSet { Time = time, Km = km });

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
        //metod som gör stänger workouten
        private void EndWorkoutStrength()
        {
            if (CurrentWorkout != null)
            {
                AnsiConsole.MarkupLine($"[bold]Pass: {CurrentWorkout.WorkoutDate}[/]");

                foreach (Exercise exercise in CurrentWorkout.Exercises)
                {
                    AnsiConsole.MarkupLine($"[yellow]{exercise.Name}[/]");

                    foreach (WorkSet set in exercise.Sets)
                    {
                        AnsiConsole.MarkupLine($"   {set.Weight} kg x {set.RepCount}");

                    }
                }
                if (CurrentWorkout.Exercises.Count > 0)    // spara inte tomma pass
                {
                    WorkoutStore.AddItem(CurrentWorkout);
                }

                CleanConsole();

            }

            CurrentWorkout = null;
        }

        private void EndWorkoutCardio()
        {
            if (CurrentWorkout != null)
            {
                AnsiConsole.MarkupLine($"[bold]Pass: {CurrentWorkout.WorkoutDate}[/]");

                foreach (Exercise exercise in CurrentWorkout.Exercises)
                {
                    AnsiConsole.MarkupLine($"[yellow]{exercise.Name}[/]");

                    foreach (WorkSet set in exercise.Sets)
                    {
                        AnsiConsole.MarkupLine($"   {set.Km} Km x {set.Time} Minutes ");
                    }
                }
                if (CurrentWorkout.Exercises.Count > 0)    // spara inte tomma pass
                {
                    WorkoutStore.AddItem(CurrentWorkout);
                }
                CleanConsole();
            }

            CurrentWorkout = null;
        }
        //private void EndWorkout() 
        //{
        //    CurrentWorkout = null;
        //}
    }
}