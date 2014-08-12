using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Parts;

namespace Interfaces
{
    interface ICar
    {
        IEngine Engine { get; }
        IPanel Panel { get; }
        IPedal Pedal { get; }
        IRudder Rudder { get; }
        ITank Tank { get; }
        ITransmission Transmission { get; }

        int CurrentGear { get; }
        double CurrentSpeed { get; }
        double CurrentRudderDegree { get; }
        double Fuel { get; }
        bool HeadLight { get; }

        void Accelerate(int pedalPressPower);
        void Break(int pedalPressPower);

        void TurnLeft(int degree);
        void TurnRight(int degree);

        void LightSwitch();
    }
}
