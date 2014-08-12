using Interfaces.Parts;

namespace Interfaces
{
    public interface IFactory
    {
        IEngine CreatEngine();
        IPanel CreatePanel();
        IPedal CreatePedal();
        IRudder CreateRudder();
        ITank CreateTank();
        ITransmission CreateTransmission();
    }
}