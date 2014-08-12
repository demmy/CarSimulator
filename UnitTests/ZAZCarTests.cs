using System;
using Interfaces.Parts;
using ZAZ;
using Interfaces;
using Models;
using NUnit.Framework;
using ZAZ.Parts;

namespace UnitTests
{

    [TestFixture]
    [Category("ZAZ")]
    internal class Tests
    {


        [Test]
        [Category("Creation")]
        public void ShouldCreateNewCarWsParts()
        {
            ICar car = new Car(new CarFactory());

            Assert.IsInstanceOf<Engine>(car.Engine);
            Assert.IsInstanceOf<Panel>(car.Panel);
            Assert.IsInstanceOf<Pedal>(car.Pedal);
            Assert.IsInstanceOf<Rudder>(car.Rudder);
            Assert.IsInstanceOf<Tank>(car.Tank);
            Assert.IsInstanceOf<Transmission>(car.Transmission);
        }

        [Test]
        [Category("Creation")]
        public void ShouldReturnDefaultValues()
        {
            ICar car = new Car(new CarFactory());

            Assert.That(0, Is.EqualTo(car.CurrentGear));
            Assert.That(0, Is.EqualTo(car.CurrentRudderDegree));
            Assert.That(0, Is.EqualTo(car.CurrentSpeed));
            Assert.That(120, Is.EqualTo(car.Fuel));
            Assert.That(250, Is.EqualTo(car.Engine.MaxSpeed));
            Assert.That(5, Is.EqualTo(car.Pedal.Luft));
            Assert.That(5, Is.EqualTo(car.Rudder.Luft));
            Assert.That(6, Is.EqualTo(car.Transmission.MaxGear));
        }

        [Test]
        [Category("Drive")]
        public void ShouldAsselerateAndBrakeControlledZeroAndMaxSpeed()
        {
            ICar car = new Car(new CarFactory());

            car.Accelerate(100);
            car.Accelerate(100);

            Assert.That(19d, Is.EqualTo(car.CurrentSpeed));

            car.Break(100);

            Assert.That(9.5d, Is.EqualTo(car.CurrentSpeed));

            car.Break(100);

            Assert.That(0.0, Is.EqualTo(car.CurrentSpeed));

            car.Accelerate(50);
            car.Accelerate(50);
            car.Accelerate(50);
            car.Accelerate(50);

            Assert.That(18d, Is.EqualTo(car.CurrentSpeed));


            for (int i = 0; i < 1000; i++)
            {
                car.Accelerate(100);
            }

            Assert.That(car.Engine.MaxSpeed, Is.EqualTo(car.CurrentSpeed));

            for (int i = 0; i < 5000; i++)
            {
                car.Break(100);
            }

            Assert.That(0.0, Is.EqualTo(car.CurrentSpeed));
        }

        [Test]
        [Category("Drive")]
        public void ShouldThrowErrorWhenPressValueIncorrect()
        {
            IFactory factory = new CarFactory();
            var car = new Car(factory);
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Accelerate(120));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Accelerate(-10));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Break(120));
            Assert.Throws<ArgumentOutOfRangeException>(() => car.Break(-10));
        }

        [Test]
        [Category("Utility")]
        public void ShouldTransmissionChangedInRange()
        {
            IFactory factory = new CarFactory();
            var car = new Car(factory);

            //понижаем передачу ниже нулевой
            car.GearDown();
            Assert.That(0, Is.EqualTo(car.CurrentGear));

            //повышаем передачу 100 раз
            for (int i = 0; i < 100; i++)
            {
                car.GearUp();
            }
            Assert.That(car.Transmission.MaxGear, Is.EqualTo(car.CurrentGear));
        }

        [Test]
        [Category("Utility")]
        public void ShouldHeadlightSwitch()
        {
            IFactory factory = new CarFactory();
            var car = new Car(factory);

            Assert.False(car.HeadLight);

            car.LightSwitch();

            Assert.True(car.HeadLight);

            car.LightSwitch();

            Assert.False(car.HeadLight);
        }

        [Test]
        [Category("Utility")]
        public void ShouldReturnPanelDataSomeTypeNotNull()
        {
            IFactory factory = new CarFactory();
            var car = new Car(factory);

            var report = car.PanelData();

            foreach (var item in report)
            {
                Assert.IsInstanceOf<EPanelData>(item.Key);
                Assert.IsInstanceOf<string>(item.Value);
            }
        }

    }
}