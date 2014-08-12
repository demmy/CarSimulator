using System;
using System.Collections.Generic;
using Domain.Parts;

namespace Domain
{
    public class Car
    {
        private readonly AbstractCar car;
        public string Name;


        public Car(IFactory factory)
        {
            car = factory.CreateCar();
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
            car.Accelerate(pedalPressPower);
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

            car.PressBreak(pedalPressPower);
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
            car.TurnLeft(degree);
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
            car.TurnRight(degree);
        }

        #endregion

        #region Transmission

        public void GearUp()
        {
            car.GearUp();
        }

        public void GearDown()
        {
            car.GearDown();
        }

        #endregion

        //TODO: перенести всю логику связанную с деталями в AbstractCar

        /// <summary>
        ///     Фары
        /// </summary>
        public void LightSwitch()
        {
            car.LightSwitch();
        }

        /// <summary>
        ///     Показания приборной панели
        /// </summary>
        /// <returns></returns>
        public Dictionary<PanelData, string> Panel()
        {
            return car.Panel();
        }

        public int GetSpeed()
        {
            return (int) car.Speed;
        }
    }
}