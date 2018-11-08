using System;

namespace Savanna.Interfaces.Services
{
    public interface IGlobalKeyHandler
    {
        ConsoleKeyInfo keyinfo { get; set; }

        void HandleKeys();

        void HandleGameKeys(ConsoleKeyInfo key);

        void HandleAnimalKeys(ConsoleKeyInfo key);
    }
}
