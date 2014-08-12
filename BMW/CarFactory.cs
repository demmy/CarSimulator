using BMW.Parts;
using Interfaces;
using Interfaces.Parts;

namespace BMW
{
    public class CarFactory : IFactory
    {
        public IEngine CreatEngine()
        {
            return new Engine();
        }

        public IPanel CreatePanel()
        {
            return new Panel();
        }

        public IPedal CreatePedal()
        {
            return new Pedal();
        }

        public IRudder CreateRudder()
        {
            return new Rudder();
        }

        public ITank CreateTank()
        {
            return new Tank();
        }

        public ITransmission CreateTransmission()
        {
            return new Transmission();
        }
    }
}