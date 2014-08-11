using System;
using System.Collections.Generic;
using Domain.Parts;

namespace Domain
{
    public class AbstractCar
    {
        //TODO:Расход бензина и заправка
        //запчасти
        private readonly AbstractEngine engine;
        private readonly double fuel;
        private readonly AbstractPedal pedal;
        private readonly AbstractRudder rudder;
        private readonly AbstractTransmission transmission;

        //состояния
        private int currentGear;
        private double currentRudderDegree;
        private bool headLight;
        private AbstractPanel panel;
        public double Speed;
        private AbstractTank tank;

        public AbstractCar(AbstractEngine engine, AbstractPanel panel, AbstractPedal pedal, AbstractRudder rudder,
            AbstractTank tank, AbstractTransmission transmission)
        {
            this.engine = engine;
            this.panel = panel;
            this.pedal = pedal;
            this.rudder = rudder;
            this.tank = tank;
            this.transmission = transmission;
            fuel = tank.Capacity;
        }

        #region power

        /// <summary>
        ///     Ускорение
        /// </summary>
        /// <param name="pedalPressPower">Сила нажатия педали газа в процентах</param>
        /// <returns></returns>
        public void Accelerate(int pedalPressPower)
        {
            double accelerate = 10d*((pedalPressPower - pedal.Reaction)/100d);

            if (Speed + accelerate < engine.MaxSpeed)
            {
                Speed += accelerate;
            }
            else
            {
                Speed = engine.MaxSpeed;
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

            double deccelerate = 10d*((pedalPressPower - pedal.Reaction)/100d);

            if (Speed - deccelerate > 0)
            {
                Speed -= deccelerate;
            }
            else
            {
                Speed = 0;
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
            double tmpDegree = currentRudderDegree - (degree - rudder.Luft);

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
            double tmpDegree = currentRudderDegree + (degree - rudder.Luft);

            if (tmpDegree > 360)
            {
                currentRudderDegree -= 360;
            }
        }

        #endregion

        #region Transmission

        public void GearUp()
        {
            if (++currentGear > transmission.maxGear)
            {
                currentGear = transmission.maxGear;
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
                {PanelData.Type, GetType().Name},
                {PanelData.Speed, Speed.ToString()},
                {PanelData.Fuel, fuel.ToString()},
                {PanelData.Degree, currentRudderDegree.ToString()},
                {PanelData.Gear, currentGear.ToString()},
                {PanelData.Light, headLight.ToString()},
                {PanelData.MaxSpeed, engine.MaxSpeed.ToString()},
                {PanelData.PedalLuft, pedal.Reaction.ToString()},
                {PanelData.RudderLuft, rudder.Luft.ToString()},
                {PanelData.MaxGear, transmission.maxGear.ToString()}
            };

            return report;
        }
    }
}