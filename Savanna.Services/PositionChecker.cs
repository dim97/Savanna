using Savanna.Enums;
using Savanna.Models;
using System.Drawing;

namespace Savanna.Services
{
    public class PositionChecker
    {
        public bool CheckEmpty(Field field, Point position)
        {
            if (field.Animals[position.Y, position.X] != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CheckSuitability(Field field, Point position, AnimalType animalType)
        {
            if (CheckEmpty(field, position))
            {
                return true;
            }
            else if (field.Animals[position.Y, position.X].Type != AnimalType.Carnivore)
            {
                return false;
            }
            else if (field.Animals[position.Y, position.X].Type == AnimalType.Herbivore)
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        public bool CheckFieldBorders(Field field, Point position)
        {
            if ((position.X < 0) || (position.Y < 0) || (position.X >= field.Width) || (position.Y >= field.Heigth))
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
