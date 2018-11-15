using Savanna.Interfaces;
using Savanna.Interfaces.Services;
using System;

namespace Savanna.Services
{
    public class GlobalKeyHandler : IGlobalKeyHandler
    {
        private IAnimalPlacer _animalPlacer;
        private IAnimalCreator _animalCreator;
        private IFieldHandler _fieldHandler;

        public ConsoleKeyInfo keyinfo { get; set; }

        public GlobalKeyHandler(IFieldHandler fieldHandler, IAnimalCreator animalCreator, IAnimalPlacer animalPlacer)
        {
            _animalPlacer = animalPlacer;
            _animalCreator = animalCreator;
            _fieldHandler = fieldHandler;
        }

        public void HandleKeys()
        {
            while (true)
            {
                keyinfo = Console.ReadKey(true);
                HandleGameKeys(keyinfo);
                HandleAnimalKeys(keyinfo);
            }
        }

        public void HandleGameKeys(ConsoleKeyInfo key)
        {
            switch (keyinfo.Key)
            {
                case (ConsoleKey.Escape): { Environment.Exit(0); break; }
            }
        }

        public void HandleAnimalKeys(ConsoleKeyInfo key)
        {

            IAnimal antilope = _animalCreator.CreateAntilope();
            IAnimal lion = _animalCreator.CreateLion();

            if (char.ToUpper(keyinfo.KeyChar) == antilope.Sign)
            {
                _animalPlacer.PlaceAnimalInRandomPlace(antilope );
            }
            if (char.ToUpper(keyinfo.KeyChar) == lion.Sign)
            {
                _animalPlacer.PlaceAnimalInRandomPlace(lion);
            }
        }
    }
}
