using Savanna.Enums;
using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using System.Drawing;

namespace Savanna.Services
{
    public class PositionChecker : IPositionChecker
    {
        private IField _field;

        public PositionChecker(IField field)
        {
            _field = field;
        }

        public bool CheckEmpty(Point position)
        {
            if (_field.Animals[position.Y, position.X] != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckSuitability(Point position, AnimalType animalType)
        {
            if (CheckEmpty(position))
            {
                return true;
            }
            else if (_field.Animals[position.Y, position.X].Type != AnimalType.Carnivore)
            {
                return false;
            }
            else if (_field.Animals[position.Y, position.X].Type == AnimalType.Herbivore)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CheckFieldBorders(Point position)
        {
            if ((position.X < 0) || (position.Y < 0) || (position.X >= _field.Width) || (position.Y >= _field.Heigth))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
