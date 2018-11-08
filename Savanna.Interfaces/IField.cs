namespace Savanna.Interfaces.Models
{
    public interface IField
    {
        int Width { get; set; }
        int Heigth { get; set; }
        IAnimal[,] Animals { get; set; }
    }
}
