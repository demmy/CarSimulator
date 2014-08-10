using System;
using System.Collections.Generic;

namespace Domain
{
    internal class Car
    {
        private readonly AbstractCar car;

        //состояния
        private readonly double fuel;
        private int currentGear;
        private double currentRudderDegree;
        private bool headLight;
        private double speed;

        public Car(IFactory factory)
        {
            car = factory.CreateCar();
            fuel = car.tank.Capacity;
        }

        #region power

        /// <summary>
        ///     Ускорение
        /// </summary>
        /// <param name="pedalPressPower">Сила нажатия педали газа в процентах</param>
        /// <returns></returns>
        public void Accelerate(int pedalPressPower)
        {
            if (pedalPressPower < 0 || pedalPressPower > 100)
            {
                throw new ArgumentOutOfRangeException("Педаль можно нажать от нуля до 100%");
            }

            double accelerate = 10*(1/(pedalPressPower - car.pedal.Reaction));

            if (speed + accelerate < car.engine.MaxSpeed)
            {
                speed += accelerate;
            }
        }

        /// <summary>
        ///     Торможение
        /// </summary>
        /// <param name="pedalPressPower">Сила нажатия педали тормоз в процентах</param>
        /// <returns></returns>
        public void PressBreak(int pedalPressPower)
        {
            if (pedalPressPower < 0 || pedalPressPower > 100)
            {
                throw new ArgumentOutOfRangeException("Педаль можно нажать от нуля до 100%");
            }

            double deccelerate = 10*(1/(pedalPressPower - car.pedal.Reaction));

            if (speed - deccelerate > 0)
            {
                speed -= deccelerate;
            }
            else
            {
                speed = 0;
            }
        }

        #endregion

        #region Turns

        /// <summary>
        ///     Поворот в лево
        /// </summary>
        /// <param name="degree">Угол поворота в градусах</param>
        /// <returns></returns>
        public void TurnLeft(int degree)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException("Руль нужно повернуть");
            }
            double tmpDegree = currentRudderDegree - (degree - car.rudder.Luft);

            if (tmpDegree < 0)
            {
                // прибавляя отрицательный угол к 360 мы по факту отнимаем модуль
                tmpDegree = 360 + tmpDegree;
            }
            currentRudderDegree = tmpDegree;
        }

        /// <summary>
        ///     Поворот в право
        /// </summary>
        /// <param name="degree">Угол поворота в градусах</param>
        /// <returns></returns>
        public void TurnRight(int degree)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException("Руль нужно повернуть");
            }
            double tmpDegree = currentRudderDegree + (degree - car.rudder.Luft);

            if (tmpDegree > 360)
            {
                currentRudderDegree -= 360;
            }
        }

        #endregion

        #region Transmission

        public void GearUp()
        {
            if (++currentGear > car.transmission.maxGear)
            {
                currentGear = car.transmission.maxGear;
            }
        }

        public void GearDown()
        {
            if (--currentGear < 0)
            {
                currentGear = 0;
            }
        }

        #endregion

        /// <summary>
        ///     Фары
        /// </summary>
        public void LightSwitch()
        {
            headLight = !headLight;
        }

        /// <summary>
        ///     Показания приборной панели
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> Panel()
        {
            var report = new Dictionary<string, string>
            {
                {"speed", speed.ToString()},
                {"fuel", fuel.ToString()},
                {"degree", currentRudderDegree.ToString()},
                {"gear", currentGear.ToString()},
                {"light", headLight.ToString()},
                {"max-speed", car.engine.MaxSpeed.ToString()},
                {"pedal-luft", car.pedal.Reaction.ToString()},
                {"rudder-luft", car.rudder.Luft.ToString()},
                {"max-gear", car.transmission.maxGear.ToString()}
            };

            return report;
        }
    }
}