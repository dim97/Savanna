using Savanna.Interfaces;
using Savanna.Models.Animals;
using System;
using System.Text;

namespace Savanna.Models
{
    public class Field
    {
        public static int DefaultWidth { get; set; } = 40;
        public static int DefaultHeigth { get; set; } = 40;

        public int Width { get; set; }
        public int Heigth { get; set; }
        public IAnimal[,] Animals { get; set; }
       
    }
}
