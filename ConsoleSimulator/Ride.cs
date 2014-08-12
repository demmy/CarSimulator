using System;
using System.Collections.Generic;
using Domain;

namespace ConsoleSimulator
{
    public static class Ride
    {
        public static void Start(Car car)
        {
            bool isEnd = false;
            do
            {
                var menuMain = new List<string>
                {
                    "Нажать газ",
                    "Нажать тормоз",
                    "Переключить фары",
                    "Повысить передачу",
                    "Понизить передачу",
                    "Повернуть налево",
                    "Повернуть направо",
                    "Данные с приборной панели",
                };
                if (car.GetSpeed() == 0)
                {
                    menuMain.Add("Выход");
                }

                int choice = UIHelper.DrawMenu(menuMain);
                switch (choice)
                {
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        isEnd = true;
                        break;
                    default:
                        Console.WriteLine("OOPS!");
                        break;
                }
            } while (!isEnd);
        }
    }
}