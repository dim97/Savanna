using Savanna.Interfaces.Services;
using System.Threading;
using Unity;

namespace Savanna.Services
{
    public class Game : IGame
    {
        IUnityContainer _container { get; set; }

        private IMovementHandler _movementHandler;
        private IGlobalKeyHandler _globalKeyHandler;
        private IConsoleWriter _consoleWriter;

        public Game(IMovementHandler movementHandler, IGlobalKeyHandler globalKeyHandler, IConsoleWriter consoleWriter)
        {
            _movementHandler = movementHandler;
            _globalKeyHandler = globalKeyHandler;
            _consoleWriter = consoleWriter;
        }

        public void Play()
        {
            Thread keyHandler = new Thread(() => _globalKeyHandler.HandleKeys());
            keyHandler.Start();
            _consoleWriter.DrawFieldToConsole();

            while (true)
            {
                _movementHandler.HandleMovement();
            }
        }

    }
}
