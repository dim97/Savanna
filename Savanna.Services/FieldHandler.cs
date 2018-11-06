using Savanna.Interfaces;
using Savanna.Models;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Services
{
    public class FieldHandler
    {
        public Field field = new Field()
        {
            Heigth = Field.DefaultHeigth,
            Width = Field.DefaultWidth,
            Animals = new IAnimal[Field.DefaultHeigth, Field.DefaultWidth]
        };
        public bool IsFull
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
                if (flag == true)
                {
                    return flag;
                }
                return flag;
            }
            set { }
        }

        public List<string> GetFieldInStringList()
        {
            List<string> lines = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            DrawingSymbols drawingSymbols = new DrawingSymbols();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Animals[i, j] != null)
                    {
                        stringBuilder.Append(field.Animals[i, j].Sign);
                    }
                    else
                    {
                        stringBuilder.Append(drawingSymbols.EmptySpace);
                    }
                    stringBuilder.Append(' ');
                }

                lines.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }

            return lines;
        }

    }
}
