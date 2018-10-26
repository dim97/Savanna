using System;

namespace Savanna
{
    public static class Menu
    {
        static string _message = string.Empty;
        static string _errorMessage = string.Empty;
        static string _input = string.Empty;

        public static void ShowMenu()
        {
            Console.Write(_message);
            _input = Console.ReadLine();

            //switch (input)
            //{
            //    case "1":
            //        {
            //            Console.Clear();
            //            SelectedOption = OneGameSelected;
            //            RequestGameOptions();
            //            GamesHandler.StartOneGame();
            //            break;
            //        }
            //    case "2":
            //        {
            //            Console.Clear();
            //            SelectedOption = ThousandGamesSelected;
            //            RequestGameOptions();
            //            GamesHandler.StartThousandGamesAndShowOne();
            //            break;
            //        }
            //    case "3":
            //        {
            //            Console.Clear();
            //            SelectedOption = EightGamesSelected;
            //            RequestGameOptions();
            //            GamesHandler.StartThousandGamesAndShowEight();
            //            break;
            //        }
            //    case "4":
            //        {
            //            Console.Clear();
            //            SelectedOption = AllGamesSelected;
            //            RequestGameOptions();
            //            GamesHandler.StartThousandGamesAndShowAll();
            //            break;
            //        }
            //    case "5":
            //        {
            //            Console.Clear();
            //            SelectedOption = LoadGameSelected;
            //            GamesHandler.LoadGameFromFile();
            //            break;
            //        }
            //    default:
            //        {
            //            Console.Clear();
            //            Console.Write(errorMessage);
            //            ShowMenu();
            //            break;
            //        }

            //    }
            //}

            //public static void RequestGameOptions()
            //{
            //    string inputWidth, inputHeigth;

            //    Console.Write("Please enter width of field (in range: 1-200)  -> ");
            //    inputWidth = Console.ReadLine();
            //    while (!(int.TryParse(inputWidth, out Game.Width) && (Game.Width >= 1) && (Game.Width <= 200)))
            //    {
            //        Console.Write("\nEntered width is incorrect. Please enter a positive integer number (in range: 1-200) -> ");
            //        inputWidth = Console.ReadLine();
            //    }

            //    Console.Write("Please enter heigth of field (in range: 1-200)  -> ");
            //    inputHeigth = Console.ReadLine();

            //    while (!(int.TryParse(inputHeigth, out Game.Heigth) && (Game.Heigth >= 1) && (Game.Heigth <= 200)))
            //    {
            //        Console.Write("\nEntered heigth is incorrect. Please enter a positive integer number (in range: 1-200) -> ");
            //        inputHeigth = Console.ReadLine();
            //    }
            //    Console.Clear();
            //}
        }
    }
}


