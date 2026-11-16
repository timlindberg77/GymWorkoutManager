using System;
using System.Collections.Generic;
using System.Text;

namespace GymWorkoutManager.Classes
{
    public class Datastore<T> 
    {
        public void AddItem()
        {
            //metod för att lägga till workout
        }
        public void RemoveItem()
        {
            //metod för att radera en workout
        }

        public void FindItem()
        {
            //hittar workoutsen
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
