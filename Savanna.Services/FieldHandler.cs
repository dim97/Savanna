using Savanna.Interfaces;
using Savanna.Models;
using Savanna.Models.Animals;
using System;
using System.Text;

namespace Savanna.Services
{
    public static class FieldHandler
    {
        public static Field field = new Field()
        {
            Heigth = Field.DefaultHeigth,
            Width = Field.DefaultWidth,
            Animals = new IAnimal[Field.DefaultHeigth, Field.DefaultWidth]
        };

        public static bool IsFull
        {
            get
            {
                bool flag = true;
                for (int i = 0; i < field.Heigth; i++)
                {
                    for (int j = 0; j < field.Width; j++)
                    {
                        if (field.Animals[i, j] == null)
                        {
                            flag = false;
                        }
                    }
                };
                return flag;
            }
            set { }
        }

        public static void setRandomAnimals()
        {
            Random random = new Random();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    switch (random.Next(3))
                    {
                        case 0: { field.Animals[i, j] = null; break; }
                        case 1: { field.Animals[i, j] = new Antilope(); break; }
                        case 2: { field.Animals[i, j] = new Lion(); break; }
                    }
                }
            }
        }

        public static void PlaceAnimalInField(IAnimal animalToAdd)
        {
            Random random = new Random();

            int randomX = random.Next(field.Width);
            int randomY = random.Next(field.Heigth);

            while ((field.Animals[randomY, randomX] != null)&&!IsFull)
            {
                randomX = random.Next(field.Width);
                randomY = random.Next(field.Heigth);
            }

            field.Animals[randomY, randomX] = animalToAdd;
        }

        public static string GetFieldInString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append('╔');
            for (int i = 0; i < field.Width * 2; i++)
            {
                stringBuilder.Append('═');
            }
            stringBuilder.Append('╗');
            stringBuilder.Append(Environment.NewLine);
            for (int i = 0; i < field.Heigth; i++)
            {
                stringBuilder.Append('║');
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Animals[i, j] != null)
                    {
                        stringBuilder.Append(field.Animals[i, j].Sign);
                    }
                    else
                    {
                        stringBuilder.Append(' ');
                    }
                    stringBuilder.Append(' ');
                }
                stringBuilder.Append('║');
                stringBuilder.Append(Environment.NewLine);
            }
            stringBuilder.Append('╚');
            for (int i = 0; i < field.Width * 2; i++)
            {
                stringBuilder.Append('═');
            }
            stringBuilder.Append('╝');
            stringBuilder.Append(Environment.NewLine);
            return stringBuilder.ToString();
        }

        public static void DrawFieldToConsole()
        {
            Console.Write(GetFieldInString());
        }

    }
}
