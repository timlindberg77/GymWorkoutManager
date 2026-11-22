using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;
using Spectre.Console.Rendering;
using System.Threading;

namespace GymWorkoutManager.Classes
{
    public class SpectreFunktion 
    {
        // laddningsbar innan huvudmenyn visas
        public void ShowLoadingBar()
        {
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
                        task.Increment(5);
                        Thread.Sleep(50);
                    }
                });
        }

        // Laddningbar som visas när en workout är sparad
        public void ShowSaveProgress()
        {
            AnsiConsole.Progress()
                .Columns(
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new PercentageColumn(),
                    new SpinnerColumn())
                .Start(ctx =>
                {
                    var task = ctx.AddTask("Saving workout...", maxValue: 100);

                    while (!ctx.IsFinished)
                    {
                        task.Increment(5);
                        Thread.Sleep(50);
                    }
                });

            AnsiConsole.MarkupLine("[green]Workout saved successfully![/]");
        }
    }
}

