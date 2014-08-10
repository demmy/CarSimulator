using Domain;
using Domain.Parts;
using ZAZ.Parts;

namespace ZAZ
{
    public class ZAZFactory : IFactory
    {
        private readonly AbstractEngine engine = new ZAZEngine();
        private readonly AbstractPanel panel = new ZAZPanel();
        private readonly AbstractPedal pedal = new ZAZPedal();
        private readonly AbstractRudder rudder = new ZAZRudder();
        private readonly AbstractTank tank = new ZAZTank();
        private readonly AbstractTransmission transmission = new ZAZTransmission();


        public AbstractCar CreateCar()
        {
            return new ZAZCar(engine, panel, pedal, rudder, tank, transmission);
        }
    }
}