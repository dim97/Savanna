using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using System.Collections.Generic;
using Unity;

namespace Savanna.Interfaces.Services
{
    public interface IFieldHandler
    {
        IField GameField {get;set;}
        bool IsFull { get; set; }

        List<string> GetFieldInStringList();
    }
}
