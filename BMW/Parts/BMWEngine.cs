using Interfaces.Parts;

namespace BMW.Parts
{
    public class BMWEngine : IEngine
    {
        public BMWEngine()
        {
            MaxSpeed = 250;
        }

        public int MaxSpeed { get; private set; }
    }
}