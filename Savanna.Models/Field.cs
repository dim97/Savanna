using Savanna.Interfaces;
using Savanna.Models.Animals;
using System;
using System.Text;

namespace Savanna.Models
{
    public class Field
    {
        public static int DefaultWidth = 10;
        public static int DefaultHeigth = 10;

        public int Width;
        public int Heigth;
        public IAnimal[,] Animals;
    }
}
