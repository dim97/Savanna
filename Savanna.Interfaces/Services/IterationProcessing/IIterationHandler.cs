using Savanna.Enums;
using Savanna.Interfaces.Services;
using System.Threading;

namespace Savanna.Interfaces.Services
{
    public interface IIterationHandler
    {
        int FullIterationDuration { get; set; }

        void HandleIteration();
    }
}
