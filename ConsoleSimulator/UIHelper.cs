using System;
using System.Collections.Generic;

namespace ConsoleSimulator
{
    internal class UiHelper
    {
        public static int DrawMenu(List<string> mainMenu)
        {
            Console.Clear();
            int size = mainMenu.Count;

            for (int i = 1; i <= size; i++)
            {
                Console.WriteLine("[{0}] - {1}", i, mainMenu[i - 1]);
            }
            return GetInt("выберите пункт меню", 1, size);
        }

        public static int GetInt(string message, int minValue, int maxValue)
        {
            int result = int.MinValue;
            do
            {
                Console.WriteLine(message);
            } while (!int.TryParse(Console.ReadLine(), out result) || result < minValue || result > maxValue);
            return result;
        }

        public static string GetString(string message)
        {
            string result;
            do
            {
                Console.WriteLine(message);
                result = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(result));
            return result;
        }

        public static void DrawList(List<string> list)
        {
            Console.Clear();
            foreach (string item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}