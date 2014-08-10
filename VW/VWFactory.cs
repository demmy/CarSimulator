using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBuilder.Abstract.Parts;
using Domain;

namespace VW
{
    public class VWFactory : IFactory
    {
        public AbstractEngine CreateEngine()
        {
            throw new NotImplementedException();
        }

        public AbstractPanel CreatePanel()
        {
            throw new NotImplementedException();
        }

        public AbstractPedal CreatePedal()
        {
            throw new NotImplementedException();
        }

        public AbstractRudder CreateRudder()
        {
            throw new NotImplementedException();
        }

        public AbstractTank CreateTank()
        {
            throw new NotImplementedException();
        }

        public AbstractTransmission CreateTransmission()
        {
            throw new NotImplementedException();
        }
    }
}
