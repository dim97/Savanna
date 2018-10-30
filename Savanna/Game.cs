using Savanna.Services;
using System;
using System.Threading;

namespace Savanna
{
    public static class Game
    {

        public static void Play()
        {
            
            Thread keyHandler = new Thread(GlobalKeyHandler.HandleKeys);
            keyHandler.Start();

            while (true)
            {
                MovementHandler.HandleMovement(FieldHandler.field);
                Draw();
                Thread.Sleep(500);
            }
        }

        public static void Draw()
        {
            Console.Clear();
            FieldHandler.DrawFieldToConsole();
        }

    }
}
