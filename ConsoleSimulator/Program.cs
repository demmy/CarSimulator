using System;
using System.Collections.Generic;
using System.Linq;
using BMW;
using Models;

namespace ConsoleSimulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var cars = new List<Car>();
            bool isExit = false;

            do
            {
                switch (UIHelper.DrawMenu(new List<string> {"Создать автомобиль", "Покататься", "Выход"}))
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
                        int concreteCar = UIHelper.DrawMenu(names) - 1;
                        Ride.Start(cars[concreteCar]);
                        break;
                    case 3:
                        isExit = true;
                        break;
                    default:
                        break;
                }
            } while (!isExit);
            Console.ReadLine();
        }

        private static void CreateNewCar(List<Car> cars)
        {
            int supplier = UIHelper.DrawMenu(Enum.GetNames(typeof (Suppliers)).ToList());
            Car car;

            switch (supplier)
            {
                case (int) Suppliers.BMW:
                    car = new Car(new BMWFactory());
                    break;
                default:
                    return;
            }
            car.Name = UIHelper.GetString("Введите имя машины");
            cars.Add(car);
        }
    }
}