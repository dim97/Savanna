using Savanna.Interfaces.Models;
using Savanna.Interfaces.Services;
using Savanna.Models;
using System.Collections.Generic;
using System.Text;

namespace Savanna.Services
{
    public class FieldHandler : IFieldHandler
    {
        public IField GameField { get; set; }

        public bool IsFull
        {
            get
            {
                bool flag = true;
                for (int i = 0; i < GameField.Heigth; i++)
                {
                    for (int j = 0; j < GameField.Width; j++)
                    {
                        if (GameField.Animals[i, j] == null)
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

        public FieldHandler(IField field)
        {
            GameField = field;
        }

        public List<string> GetFieldInStringList()
        {
            List<string> lines = new List<string>();
            StringBuilder stringBuilder = new StringBuilder();
            DrawingSymbols drawingSymbols = new DrawingSymbols();

            for (int i = 0; i < GameField.Heigth; i++)
            {
                for (int j = 0; j < GameField.Width; j++)
                {
                    if (GameField.Animals[i, j] != null)
                    {
                        stringBuilder.Append(GameField.Animals[i, j].Sign);
                    }
                    else
                    {
                        stringBuilder.Append(drawingSymbols.EmptySpace);
                    }
                    stringBuilder.Append(drawingSymbols.EmptySpace);
                }

                lines.Add(stringBuilder.ToString());
                stringBuilder.Clear();
            }

            return lines;
        }

    }
}
