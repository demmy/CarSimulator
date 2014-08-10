using System;
using System.Collections.Generic;
using Domain;
using Domain.Parts;
using NUnit.Framework;
using VW;

namespace UnitTests
{
    [TestFixture]
    [Category("Car")]
    public class CarTest
    {
        [Test]
        [Category("Drive")]
        public void ShouldAccelerateAndBreak()
        {
            // MagicNumbers in Assert:
            // double vwFullStep = 10d * ((100d - 10d)/100d); //9
            // double vwHalfStep = 10d * ((50d - 10d) / 100d); //4

            IFactory factory = new VWFactory();
            var car = new Car(factory);

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(50);

            Dictionary<PanelData, string> report = car.Panel();

            Assert.That("22", Is.EqualTo(report[PanelData.Speed]));

            car.PressBreak(100);
            report = car.Panel();
            Assert.That("13", Is.EqualTo(report[PanelData.Speed]));

            car.PressBreak(50);
            report = car.Panel();
            Assert.That("9", Is.EqualTo(report[PanelData.Speed]));

            car.PressBreak(100);
            report = car.Panel();
            Assert.That("0", Is.EqualTo(report[PanelData.Speed]));
        }

        [Test]
        public void ShouldCreateVWCarVsDefaultData()
        {
            IFactory factory = new VWFactory();
            var car = new Car(factory);

            Dictionary<PanelData, string> report = car.Panel();

            Assert.That(report[PanelData.Type], Is.EqualTo(typeof (VWCar).Name));
            Assert.That(report[PanelData.Speed], Is.EqualTo(0.ToString()));
            Assert.That(report[PanelData.Fuel], Is.EqualTo(60.ToString()));
            Assert.That(report[PanelData.Degree], Is.EqualTo(0.ToString()));
            Assert.That(report[PanelData.Gear], Is.EqualTo(0.ToString()));
            Assert.That(report[PanelData.Light], Is.EqualTo("False"));
            Assert.That(report[PanelData.MaxSpeed], Is.EqualTo(220.ToString()));
            Assert.That(report[PanelData.RudderLuft], Is.EqualTo(5.ToString()));
            Assert.That(report[PanelData.MaxGear], Is.EqualTo(5.ToString()));
        }

        [Test]
        [Category("Drive")]
        public void ShouldStopOnMaxSpeedAndStop()
        {
            IFactory factory = new VWFactory();
            var car = new Car(factory);
            Dictionary<PanelData, string> report = car.Panel();

            // 1000 раз жмем тормоз на полную
            for (int i = 0; i < 100; i++)
            {
                car.PressBreak(100);
            }

            report = car.Panel();
            Assert.That("0", Is.EqualTo(report[PanelData.Speed]));

            // 1000 раз жмем газ на полную
            for (int i = 0; i < 1000; i++)
            {
                car.Accelerate(100);
            }
            report = car.Panel();
            Assert.That(report[PanelData.MaxSpeed], Is.EqualTo(report[PanelData.Speed]));
        }

        [Test]
        [Category("Drive")]
        public void ShouldThrowErrorWhenPressValueIncorrect()
        {
            IFactory factory = new VWFactory();
            var car = new Car(factory);
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Accelerate(120));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Accelerate(-10));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.PressBreak(120));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.PressBreak(-10));
        }

        [Test]
        [Category("Drive")]
        public void ShouldHeadlightSwitch()
        {
            IFactory factory = new VWFactory();
            var car = new Car(factory);
            Dictionary<PanelData, string> report = car.Panel();

            Assert.That("False",Is.EqualTo(report[PanelData.Light]));
            car.LightSwitch();
            report = car.Panel();
            Assert.That("True", Is.EqualTo(report[PanelData.Light]));
        }

        [Test]
        [Category("Drive")]
        public void ShouldTransmissionChangedInRange()
        {
            IFactory factory = new VWFactory();
            var car = new Car(factory);
            Dictionary<PanelData, string> report = car.Panel();

            Assert.That("0",Is.EqualTo(report[PanelData.Gear]));

            //понижаем передачу ниже нулевой
            car.GearDown();
            report = car.Panel();
            Assert.That("0",Is.EqualTo(report[PanelData.Gear]));

            //повышаем передачу 100 раз
            for (int i = 0; i < 100; i++)
            {
                car.GearUp();
            }
            report = car.Panel();
            Assert.That(report[PanelData.MaxGear], Is.EqualTo(report[PanelData.Gear]));
        }
    } 
}