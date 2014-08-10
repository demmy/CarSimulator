using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBuilder.Abstract.Parts;
using Domain.Parts;

namespace Domain
{
    public interface IFactory
    {
        AbstractEngine CreateEngine();
        AbstractPanel CreatePanel();
        AbstractPedal CreatePedal();
        AbstractRudder CreateRudder();
        AbstractTank CreateTank();
        AbstractTransmission CreateTransmission();

        AbstractCar CreateCar();
    }
}
