using BMW.Parts;
using Interfaces;
using Interfaces.Parts;

namespace BMW
{
    public class BMWFactory : IFactory
    {
        public IEngine CreatEngine()
        {
            return new BMWEngine();
        }

        public IPanel CreatePanel()
        {
            return new BMWPanel();
        }

        public IPedal CreatePedal()
        {
            return new BMWPedal();
        }

        public IRudder CreateRudder()
        {
            return new BMWRudder();
        }

        public ITank CreateTank()
        {
            return new BMWTank();
        }

        public ITransmission CreateTransmission()
        {
            return new BMWTransmission();
        }
    }
}