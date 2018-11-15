using Savanna.Interfaces;
using Savanna.Interfaces.Models;
using System;

namespace Savanna.Models
{
    public class Field : IField
    {
        public int Width { get; set; }
        public int Heigth { get; set; }
        public IAnimal[,] Animals { get; set; }

        public Field()
        {
            Width = 40;
            Heigth = 40;
            Animals = new IAnimal[40, 40];
        }
    }
}
