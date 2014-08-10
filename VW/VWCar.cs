using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Parts;

namespace VW
{
    class VWCar : AbstractCar
    {
        public VWCar(
            AbstractEngine engine, 
            AbstractPanel panel, 
            AbstractPedal pedal, 
            AbstractRudder rudder, 
            AbstractTank tank, 
            AbstractTransmission transmission) : base(
            engine, 
            panel, 
            pedal, 
            rudder, 
            tank, 
            transmission
            )
        {
        }
    }
}
