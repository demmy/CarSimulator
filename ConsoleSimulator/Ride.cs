using System;
using System.Collections.Generic;
using Interfaces;
using Interfaces.Parts;

namespace ConsoleSimulator
{
    public static class Ride
    {
        public static void Start(ICar car)
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
                if (Math.Abs(car.CurrentSpeed) < 0)
                {
                    menuMain.Add("Выход");
                }

                int choice = UiHelper.DrawMenu(menuMain);
                switch (choice)
                {
                    case 1:
                        car.Accelerate(UiHelper.GetInt("Сила нажатия педали 1-100", 1, 100));
                        break;
                    case 2:
                        car.Break(UiHelper.GetInt("Сила нажатия педали 1-100", 1, 100));
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
                        car.TurnLeft(UiHelper.GetInt("Угол поворота 1-360", 1, 360));
                        break;
                    case 7:
                        car.TurnRight(UiHelper.GetInt("Угол поворота 1-360", 1, 360));
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