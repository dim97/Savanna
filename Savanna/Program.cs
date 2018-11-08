using Savanna.Interfaces.Services;
using Unity;

namespace Savanna
{
    class Program
    {
        static void Main(string[] args)
        {
            Dependencies dependencies = new Dependencies();
            UnityContainer unityContainer = dependencies.GetDependencyContainer();
            IGame game = unityContainer.Resolve<IGame>();
            game.Play();
        }
    }
}
