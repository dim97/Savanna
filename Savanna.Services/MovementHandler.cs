using Savanna.Enums;
using Savanna.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Savanna.Services
{
    public class MovementHandler
    {
        
        List<Point> movedAnimals;
        int fullIterationDuration = 500;

        public FieldHandler fieldHandler = new FieldHandler();
        PositionHandler positionHandler = new PositionHandler();
        PositionChecker positionChecker = new PositionChecker();
        public ConsoleWriter consoleWriter = new ConsoleWriter(true);

        public void HandleMovement()
        {
            MoveAnimals(fieldHandler.field, AnimalType.Carnivore);
            Thread.Sleep(fullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
            MoveAnimals(fieldHandler.field, AnimalType.Herbivore);            
            Thread.Sleep(fullIterationDuration / 2);
            consoleWriter.DrawPointsFromList(fieldHandler);
        }

        void MoveAnimals(Field field, AnimalType type)
        {
            movedAnimals = new List<Point>();

            for (int i = 0; i < field.Heigth; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    if ((field.Animals[i, j] != null) && (field.Animals[i, j].Type == type))
                    {
                        int animalSpeed = field.Animals[i, j].Speed;
                        Point oldPosition = new Point(j, i);
                        Point newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animalSpeed);
                        Point nearestHerbivore = positionHandler.SelectNearestHerbivore(field, oldPosition, field.Animals[i, j].VisionRange);

                        if ((nearestHerbivore.X != -1) && (type == AnimalType.Carnivore))
                        {
                            newPosition = nearestHerbivore; //Temporary
                        }
                        else
                        {
                            newPosition = positionHandler.GetRandomNewPosition(field, oldPosition, animalSpeed);
                        }

                        if (MoveToPoint(field, oldPosition, newPosition))
                        {
                            movedAnimals.Add(newPosition);
                        }
                    }
                }
            }
        }

        bool MoveToPoint(Field field, Point oldPosition, Point newPosition)
        {
            if ((oldPosition != newPosition) && positionChecker.CheckFieldBorders(field, newPosition) && !movedAnimals.Contains(oldPosition))
            {
                field.Animals[newPosition.Y, newPosition.X] = field.Animals[oldPosition.Y, oldPosition.X];
                ConsoleWriter.PointsToDraw.Add(new DrawingPoint() {Position = newPosition, Sign = field.Animals[newPosition.Y, newPosition.X] .Sign}); 
                //consoleWriter.RedrawCell(newPosition, field.Animals[oldPosition.Y, oldPosition.X].Sign);
                field.Animals[oldPosition.Y, oldPosition.X] = null;
                ConsoleWriter.PointsToDraw.Add(new DrawingPoint() { Position = oldPosition, Sign = ConsoleWriter.EmptySpace });
                //consoleWriter.RedrawCell(oldPosition, ConsoleWriter.EmptySpace);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
