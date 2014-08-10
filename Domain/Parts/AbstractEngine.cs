using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBuilder.Abstract.Parts
{
    public abstract class AbstractEngine
    {
        public readonly int MaxSpeed;

        public AbstractEngine(int maxsspeed)
        {
            this.MaxSpeed = maxsspeed;
        }
    }
}
