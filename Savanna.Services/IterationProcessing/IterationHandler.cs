using Savanna.Enums;
using Savanna.Interfaces.Services;
using System.Threading;

namespace Savanna.Services
{
    public class IterationHandler : IIterationHandler
    {
        private IMovementHandler _movementHandler;
        private IHealthHandler _healthHandler;
        private IPointsMonitor _pointsMonitor;
        private IConsoleWriter _consoleWriter;
        public int FullIterationDuration { get; set; } = 500;

        public IterationHandler
            (
            IMovementHandler movementHandler,
            IHealthHandler healthHandler,
            IPointsMonitor pointsMonitor,
            IConsoleWriter consoleWriter
            )
        {
            _healthHandler = healthHandler;
            _pointsMonitor = pointsMonitor;
            _consoleWriter = consoleWriter;
            _movementHandler = movementHandler;
        }

        public void HandleIteration()
        {

            //To do : encapsulate in one method
            _movementHandler.MoveAnimals(AnimalType.Carnivore);
            Thread.Sleep(FullIterationDuration / 2);
            _consoleWriter.DrawPointsFromList(_pointsMonitor.GetPointsToRedraw());

            _movementHandler.MoveAnimals(AnimalType.Herbivore);
            Thread.Sleep(FullIterationDuration / 2);
            _consoleWriter.DrawPointsFromList(_pointsMonitor.GetPointsToRedraw());

            _healthHandler.HandleAllAnimalHealthDecrease();
        }
    }
}
