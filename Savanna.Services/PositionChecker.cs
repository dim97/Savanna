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
