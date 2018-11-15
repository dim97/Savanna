using Savanna.Interfaces.Services;
using System.Threading;

namespace Savanna.Services
{
    public class Game : IGame
    {
        private IIterationHandler _iterationHandler;
        private IGlobalKeyHandler _globalKeyHandler;
        private IConsoleWriter _consoleWriter;

        public Game(IIterationHandler iterationHandler, IGlobalKeyHandler globalKeyHandler, IConsoleWriter consoleWriter)
        {
            _iterationHandler = iterationHandler;
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
                _iterationHandler.HandleIteration();
            }
        }

    }
}
