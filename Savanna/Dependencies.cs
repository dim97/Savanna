using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models;
using Savanna.Services;
using Unity;

namespace Savanna
{
    public class Dependencies
    {
        public UnityContainer GetDependencyContainer()
        {
            UnityContainer Container = new UnityContainer();

            Container.RegisterSingleton<IGame, Game>();
            Container.RegisterSingleton<IField, Field>();
            Container.RegisterSingleton<IFieldHandler, FieldHandler>();
            Container.RegisterSingleton<IConsoleWriter, ConsoleWriter>();
            Container.RegisterSingleton<IHealthHandler, HealthHandler>();
            Container.RegisterSingleton<IGlobalKeyHandler, GlobalKeyHandler>();

            Container.RegisterType<IAnimalCreator, AnimalCreator>();
            Container.RegisterType<IAnimalPlacer, AnimalPlacer>();
            Container.RegisterType<IMovementHandler, MovementHandler>();
            Container.RegisterType<IDistanceHandler, DistanceHandler>();
            Container.RegisterType<IAnimalFinder, AnimalFinder>();
            Container.RegisterType<IPositionChecker, PositionChecker>();
            Container.RegisterType<IPositionHandler, PositionHandler>();
            Container.RegisterType<IPointReplacer, PointReplacer>();
            Container.RegisterType<IPointsMonitor, PointsMonitor>();
            Container.RegisterType<IPathHandler, PathHandler>();

            return Container;
        }
    }
}
