using Savanna.Interfaces;
using System;

namespace Savanna.Services
{
    public class GlobalKeyHandler
    {
        ConsoleKeyInfo keyinfo { get; set; }

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

            AnimalPlacer animalPlacer = new AnimalPlacer();
            AnimalCreator animalCreator = new AnimalCreator();
            IAnimal antilope = animalCreator.CreateAntilope();
            IAnimal lion = animalCreator.CreateLion();

            if (char.ToUpper(keyinfo.KeyChar) == antilope.Sign)
            {
                animalPlacer.PlaceAnimalInRandomPlace(antilope, fieldHandler);
            }
            if (char.ToUpper(keyinfo.KeyChar) == lion.Sign)
            {
                animalPlacer.PlaceAnimalInRandomPlace(lion, fieldHandler);
            }
        }
    }
}
