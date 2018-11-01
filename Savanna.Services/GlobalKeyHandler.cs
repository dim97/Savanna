using Savanna.Models.Animals;
using System;

namespace Savanna.Services
{
    public class GlobalKeyHandler
    {
        ConsoleKeyInfo keyinfo;
        AnimalPlacer animalPlacer = new AnimalPlacer();

        public void HandleKeys(FieldHandler fieldHandler)
        {
            while (true)
            {

                keyinfo = Console.ReadKey(true);
                HandleGameKeys(keyinfo);
                HandleAnimalKeys(keyinfo, fieldHandler);
            }
        }

        private void HandleGameKeys(ConsoleKeyInfo key)
        {
            switch (keyinfo.Key)
            {
                case (ConsoleKey.Escape): { Environment.Exit(0); break; }
            }
        }

        private void HandleAnimalKeys(ConsoleKeyInfo key, FieldHandler fieldHandler)
        {
            if (char.ToUpper(keyinfo.KeyChar) == new Antilope().Sign)
            {
                animalPlacer.PlaceAnimalInRandomPlace(new Antilope(), fieldHandler);
            }
            if (char.ToUpper(keyinfo.KeyChar) == new Lion().Sign)
            {
                animalPlacer.PlaceAnimalInRandomPlace(new Lion(), fieldHandler);
            }
        }
    }
}
