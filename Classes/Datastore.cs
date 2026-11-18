using System;
using System.Collections.Generic;
using System.Text;

namespace GymWorkoutManager.Classes
{
    public class Datastore<T> 
    {
        List<T> Items = new();
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
            //skapas senare med logger klassen
        }

        //Laddar in existerande information som finns sparat på json filen
        public void LoadFromJson()
        {
            //skapas senare med logger klassen
        }
    }
}
