using Savanna.Models.Animals;
using System;

namespace Savanna.Services
{
    public static class GlobalKeyHandler
    {
        static ConsoleKeyInfo keyinfo;

        public static void HandleKeys()
        {
            while (true)
            {
                HandleGameKeys();
                HandleAnimalKeys();
            }
        }

        private static void HandleGameKeys()
        {
            keyinfo = Console.ReadKey();
            switch (keyinfo.Key)
            {
                case (ConsoleKey.Escape): { Environment.Exit(0); break; }
            }
        }
        private static void HandleAnimalKeys()
        {
            keyinfo = Console.ReadKey();

            if (char.ToUpper(keyinfo.KeyChar) == new Antilope().Sign)
            {
                FieldHandler.PlaceAnimalInField(new Antilope());
            }
            if (char.ToUpper(keyinfo.KeyChar) == new Lion().Sign)
            {
                FieldHandler.PlaceAnimalInField(new Lion());
            }
        }
    }
}
