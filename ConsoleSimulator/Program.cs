using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using VW;
using ZAZ;

namespace ConsoleSimulator
{
    class Program
    {
        

        private static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            bool isExit = false;
            
            do
            {
                switch (UIHelper.DrawMenu(new List<string> {"Создать автомобиль", "Покататься", "Выход"}))
                {
                    case 1:
                        CreateNewCar(cars);
                        break;
                    case 2:
                        //TODO:remove this!
                        //only in develop!!!
                        Ride.Start(new Car(new VWFactory()){Name = "Test"});
                        break;

                        if (cars.Capacity<1)
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
            int supplier = UIHelper.DrawMenu(Enum.GetNames(typeof(Suppliers)).ToList());
            Car car;

            switch (supplier)
            {
                case (int) Suppliers.VW:
                    car = new Car(new VWFactory());
                    break;
                case (int) Suppliers.ZAZ:
                    car = new Car(new ZAZFactory());
                    break;
                default:
                    return;
            }
            car.Name = UIHelper.GetString("Введите имя машины");
            cars.Add(car);
        }
    }
}