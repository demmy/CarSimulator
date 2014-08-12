using System;
using System.Collections.Generic;
using System.Linq;
using BMW;
using Interfaces;
using Models;

namespace ConsoleSimulator
{
    internal class Program
    {
        private static void Main()
        {
            var cars = new List<ICar>();
            bool isExit = false;

            do
            {
                switch (UiHelper.DrawMenu(new List<string> {"Создать автомобиль", "Покататься", "Выход"}))
                {
                    case 1:
                        CreateNewCar(cars);
                        break;
                    case 2:
                        if (cars.Capacity < 1)
                        {
                            break;
                        }
                        List<string> names = cars.Select(o => o.Name).ToList();
                        int concreteCar = UiHelper.DrawMenu(names) - 1;
                        Ride.Start(cars[concreteCar]);
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        Console.WriteLine("Oops!");
                        break;
                }
            } while (!isExit);
            Console.ReadLine();
        }

        private static void CreateNewCar(List<ICar> cars)
        {
            int supplier = UiHelper.DrawMenu(Enum.GetNames(typeof (Suppliers)).ToList());
            Car car;

            switch (supplier)
            {
                case (int) Suppliers.Bmw:
                    car = new Car(new CarFactory());
                    break;
                case (int) Suppliers.Zaz:
                    car = new Car(new ZAZ.CarFactory());
                    break;
                default:
                    return;
            }
            car.Name = UiHelper.GetString("Введите имя машины");
            cars.Add(car);
        }
    }
}