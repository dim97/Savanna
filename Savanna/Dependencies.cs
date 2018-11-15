using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models;
using Savanna.Services;
using Savanna.Services.CoordinatesProcessing;
using Unity;

namespace Savanna
{
    public class Dependencies
    {
        public UnityContainer GetDependencyContainer()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterSingleton<IField, Field>();

            container.RegisterType<IGame, Game>();
            container.RegisterType<IFieldHandler, FieldHandler>();
            container.RegisterType<IConsoleWriter, ConsoleWriter>();
            container.RegisterType<IHealthHandler, HealthHandler>();
            container.RegisterType<IGlobalKeyHandler, GlobalKeyHandler>();
            container.RegisterType<IAnimalCreator, AnimalCreator>();
            container.RegisterType<IAnimalPlacer, AnimalPlacer>();
            container.RegisterType<IMovementHandler, MovementHandler>();
            container.RegisterType<IDistanceHandler, DistanceHandler>();
            container.RegisterType<IAnimalFinder, AnimalFinder>();
            container.RegisterType<IPositionChecker, PositionChecker>();
            container.RegisterType<IPositionHandler, PositionHandler>();
            container.RegisterType<IPointReplacer, PointReplacer>();
            container.RegisterType<IPointsMonitor, PointsMonitor>();
            container.RegisterType<IPathHandler, PathHandler>();
            container.RegisterType<IIterationHandler, IterationHandler>();

            return container;
        }
    }
}
