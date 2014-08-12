using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Parts
{
    interface IPanel
    {
        string Type { get; }
        string Speed { get; }
        string Fuel { get; }
        string Degree { get; }
        string Gear { get; }
        string Light { get; }
        string MaxSpeed { get; }
        string MaxGear { get; }
        string PedalLuft { get; }
        string RudderLuft { get; }
    }
}
