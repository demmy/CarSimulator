using Domain;
using Domain.Parts;
using VW.Parts;

namespace VW
{
    public class VWFactory : IFactory
    {
        private readonly AbstractEngine engine = new VWEngine();
        private readonly AbstractPanel panel = new VWPanel();
        private readonly AbstractPedal pedal = new VWPedal();
        private readonly AbstractRudder rudder = new VWRudder();
        private readonly AbstractTank tank = new VWTank();
        private readonly AbstractTransmission transmission = new VWTransmission();


        public AbstractCar CreateCar()
        {
            return new VWCar(engine, panel, pedal, rudder, tank, transmission);
        }
    }
}