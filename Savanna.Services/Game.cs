using System.Threading;

namespace Savanna.Services
{
    public class Game
    {
        MovementHandler movementHandler = new MovementHandler();

        public void Play()
        {
            GlobalKeyHandler globalKeyHandler = new GlobalKeyHandler();
            Thread keyHandler = new Thread(() => globalKeyHandler.HandleKeys(movementHandler.fieldHandler));
            keyHandler.Start();

            movementHandler.consoleWriter.DrawFieldToConsole(movementHandler.fieldHandler);

            while (true)
            {
                movementHandler.HandleMovement();
            }
        }

    }
}
