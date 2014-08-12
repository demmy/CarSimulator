using BMW;
using BMW.Parts;
using Interfaces;
using Models;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    [Category("BMW")]
    internal class BMWTests
    {
        [Test]
        [Category("Drive")]
        public void ShouldAccelerateAndBreak()
        {
            ICar car = new Car(new BMWFactory());

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
        }

        [Test]
        [Category("Creation")]
        public void ShouldCreateNewBmwCarWsBmwParts()
        {
            ICar car = new Car(new BMWFactory());

            Assert.IsInstanceOf<BMWEngine>(car.Engine);
            Assert.IsInstanceOf<BMWPanel>(car.Panel);
            Assert.IsInstanceOf<BMWPedal>(car.Pedal);
            Assert.IsInstanceOf<BMWRudder>(car.Rudder);
            Assert.IsInstanceOf<BMWTank>(car.Tank);
            Assert.IsInstanceOf<BMWTransmission>(car.Transmission);
        }

        [Test]
        [Category("Creation")]
        public void ShouldReturnDefaultValues()
        {
            ICar car = new Car(new BMWFactory());

            Assert.That(0, Is.EqualTo(car.CurrentGear));
            Assert.That(0, Is.EqualTo(car.CurrentRudderDegree));
            Assert.That(0, Is.EqualTo(car.CurrentSpeed));
            Assert.That(120, Is.EqualTo(car.Fuel));
            Assert.That(250, Is.EqualTo(car.Engine.MaxSpeed));
            Assert.That(5, Is.EqualTo(car.Pedal.Luft));
            Assert.That(5, Is.EqualTo(car.Rudder.Luft));
            Assert.That(6, Is.EqualTo(car.Transmission.MaxGear));
        }
    }
}