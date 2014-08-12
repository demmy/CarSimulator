using System;
using System.Collections.Generic;
using System.Globalization;
using Interfaces;
using Interfaces.Parts;

namespace Models
{
    public class Car : ICar
    {
        public Car(IFactory factory)
        {
            Engine = factory.CreatEngine();
            Panel = factory.CreatePanel();
            Pedal = factory.CreatePedal();
            Rudder = factory.CreateRudder();
            Tank = factory.CreateTank();
            Transmission = factory.CreateTransmission();

            Name = "";
            CurrentGear = 0;
            CurrentSpeed = 0;
            CurrentRudderDegree = 0;
            Fuel = Tank.Capacity;
            HeadLight = false;
        }

        public string Name { get; set; }
        public IEngine Engine { get; private set; }
        public IPanel Panel { get; private set; }
        public IPedal Pedal { get; private set; }
        public IRudder Rudder { get; private set; }
        public ITank Tank { get; private set; }
        public ITransmission Transmission { get; private set; }

        public int CurrentGear { get; private set; }
        public double CurrentSpeed { get; private set; }
        public double CurrentRudderDegree { get; private set; }
        public double Fuel { get; private set; }
        public bool HeadLight { get; private set; }

        public void Accelerate(int pedalPressPower)
        {
            if (pedalPressPower < 0 || pedalPressPower > 100)
            {
                throw new ArgumentOutOfRangeException("pedalPressPower");
            }
            double accelerate = 10d*((pedalPressPower - Pedal.Luft)/100d);

            if (CurrentSpeed + accelerate < Engine.MaxSpeed)
            {
                CurrentSpeed += accelerate;
            }
            else
            {
                CurrentSpeed = Engine.MaxSpeed;
            }
        }

        public void Break(int pedalPressPower)
        {
            if (pedalPressPower < 0 || pedalPressPower > 100)
            {
                throw new ArgumentOutOfRangeException("pedalPressPower");
            }
            double deccelerate = 10d*((pedalPressPower - Pedal.Luft)/100d);

            if (CurrentSpeed - deccelerate > 0)
            {
                CurrentSpeed -= deccelerate;
            }
            else
            {
                CurrentSpeed = 0;
            }
        }

        public void TurnLeft(int degree)
        {
            if (degree < 0 || degree > 360)
            {
                throw new ArgumentOutOfRangeException("degree");
            }
            double tmpDegree = CurrentRudderDegree - (degree - Rudder.Luft);

            if (tmpDegree < 0)
            {
                // прибавляя отрицательный угол к 360 мы по факту отнимаем модуль
                tmpDegree = 360 + tmpDegree;
            }
            CurrentRudderDegree = tmpDegree;
        }

        public void TurnRight(int degree)
        {
            if (degree < 0)
            {
                throw new ArgumentOutOfRangeException("degree");
            }
            double tmpDegree = CurrentRudderDegree + (degree - Rudder.Luft);

            if (tmpDegree > 360)
            {
                CurrentRudderDegree -= 360;
            }
        }

        public void GearUp()
        {
            if (++CurrentGear > Transmission.MaxGear)
            {
                CurrentGear = Transmission.MaxGear;
            }
        }

        public void GearDown()
        {
            if (--CurrentGear < 0)
            {
                CurrentGear = 0;
            }
        }

        public void LightSwitch()
        {
            HeadLight = !HeadLight;
        }

        public Dictionary<EPanelData, string> PanelData()
        {
            PreparePanel();

            var result = new Dictionary<EPanelData, string>
            {
                {EPanelData.Name, Panel.Name},
                {EPanelData.Speed, Panel.Speed},
                {EPanelData.MaxSpeed, Panel.MaxSpeed},
                {EPanelData.Gear, Panel.Gear},
                {EPanelData.MaxGear, Panel.MaxGear},
                {EPanelData.PedalLuft, Panel.PedalLuft},
                {EPanelData.RudderLuft, Panel.RudderLuft},
                {EPanelData.Light, Panel.Light},
                {EPanelData.Fuel, Panel.Fuel},
                {EPanelData.Degree, Panel.Degree}
            };

            return result;
        }

        private void PreparePanel()
        {
            Panel.Name = Name;
            Panel.Speed = CurrentSpeed.ToString(CultureInfo.InvariantCulture);
            Panel.Degree = CurrentRudderDegree.ToString(CultureInfo.InvariantCulture);
            Panel.Gear = CurrentGear.ToString(CultureInfo.InvariantCulture);
            Panel.Light = (HeadLight) ? "ON" : "OFF";
            Panel.MaxSpeed = Engine.MaxSpeed.ToString(CultureInfo.InvariantCulture);
            Panel.MaxGear = Transmission.MaxGear.ToString(CultureInfo.InvariantCulture);
            Panel.PedalLuft = Pedal.Luft.ToString(CultureInfo.InvariantCulture);
            Panel.RudderLuft = Rudder.Luft.ToString(CultureInfo.InvariantCulture);
            Panel.Fuel = Fuel.ToString(CultureInfo.InvariantCulture);
        }
    }
}