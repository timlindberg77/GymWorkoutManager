using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace GymWorkoutManager.Classes
{
    public class Datastore<T> 
    {
        List<T> Items = new();

        private readonly string Filepath; //Gör så att bara datastore kommer åt filen

        public Datastore(string Filename) //konstruktor som bestämmer vilken fil datstore sparar data
        {
            Filepath = Path.Combine(GetProjectDirectory(), Filename);
        }
        public void AddItem(T item)
        {
            Items.Add(item);
        }
        public void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public void FindItem(T item)
        {
            //hittar workoutsen
        }

        public List<T> GetAll()
        {
            return Items;
        }
       
        //Sparar informationen från programmet till Json filen
        public void SaveToJson()
        {
            try //försöker spara
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(Items, options);
                File.WriteAllText(Filepath, json);

                AnsiConsole.MarkupLine($"Saved workout");
            }
            catch (Exception ex) //felhantering, fångar fel
            {
                AnsiConsole.MarkupLine($"Could not save workout"); 
            }
        }

        //Laddar in existerande information som finns sparat på json filen
        public void LoadFromJson()
        {
            try
            {
                string Json = File.ReadAllText(Filepath); //Läser in informationen från json filen

                List<T>? loadedItems = JsonSerializer.Deserialize<List<T>>(Json);
                Items = loadedItems ?? new List<T>();
            }
            catch (JsonException ex)
            {
                AnsiConsole.MarkupLine($"Save file could not be read: {Markup.Escape(ex.Message)}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"Could not load data: {Markup.Escape(ex.Message)}");
                Console.ReadKey();
            }
        }

        private static string GetProjectDirectory() //Nemos metod för att slippa öppna bin för att se json filen
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && dir.GetFiles("*.csproj").Length == 0)
                dir = dir.Parent;

            // om projektmappen inte hittas används bin-mappen istället
            return dir?.FullName ?? AppContext.BaseDirectory;
        }
    }
}
