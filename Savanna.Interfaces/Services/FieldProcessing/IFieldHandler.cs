using Savanna.Interfaces.Models;
using System.Collections.Generic;

namespace Savanna.Interfaces.Services
{
    public interface IFieldHandler
    {
        IField GameField { get; set; }
        bool IsFull { get; }

        List<string> GetFieldInStringList();
    }
}
