using System;
using System.Collections.Generic;
using Interfaces.Parts;
using Models;

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
                if (car.CurrentSpeed == 0)
                {
                    menuMain.Add("Выход");
                }

                int choice = UIHelper.DrawMenu(menuMain);
                switch (choice)
                {
                    case 1:
                        car.Accelerate(UIHelper.GetInt("Сила нажатия педали 1-100", 1, 100));
                        break;
                    case 2:
                        car.Break(UIHelper.GetInt("Сила нажатия педали 1-100", 1, 100));
                        break;
                    case 3:
                        car.LightSwitch();
                        break;
                    case 4:
                        car.GearUp();
                        break;
                    case 5:
                        car.GearDown();
                        break;
                    case 6:
                        car.TurnLeft(UIHelper.GetInt("Угол поворота 1-360", 1, 360));
                        break;
                    case 7:
                        car.TurnRight(UIHelper.GetInt("Угол поворота 1-360", 1, 360));
                        break;
                    case 8:
                        Dictionary<EPanelData, string> report = car.PanelData();
                        foreach (var val in report)
                        {
                            Console.WriteLine("{0} - {1}", val.Key, val.Value);
                        }
                        Console.WriteLine("Далее");
                        Console.ReadLine();
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