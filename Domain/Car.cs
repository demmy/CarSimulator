using System;
using System.Collections.Generic;
using Domain.Parts;

namespace Domain
{
    public class Car
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


        //TODO: перенести всю логику связанную с деталями в AbstractCar
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

            double accelerate = car.Accelerate(pedalPressPower);

            if (speed + accelerate < car.engine.MaxSpeed)
            {
                speed += accelerate;
            }
            else
            {
                speed = car.engine.MaxSpeed;
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

            double deccelerate = car.Break(pedalPressPower);

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
            if (degree < 0 || degree > 360)
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
        public Dictionary<PanelData, string> Panel()
        {
            var report = new Dictionary<PanelData, string>
            {
                {PanelData.Type, car.GetType().Name},
                {PanelData.Speed, speed.ToString()},
                {PanelData.Fuel, fuel.ToString()},
                {PanelData.Degree, currentRudderDegree.ToString()},
                {PanelData.Gear, currentGear.ToString()},
                {PanelData.Light, headLight.ToString()},
                {PanelData.MaxSpeed, car.engine.MaxSpeed.ToString()},
                {PanelData.PedalLuft, car.pedal.Reaction.ToString()},
                {PanelData.RudderLuft, car.rudder.Luft.ToString()},
                {PanelData.MaxGear, car.transmission.maxGear.ToString()}
            };

            return report;
        }
    }
}