using Interfaces.Parts;

namespace ZAZ.Parts
{
    public class Transmission : ITransmission
    {
        public Transmission()
        {
            MaxGear = 6;
        }

        public int MaxGear { get; private set; }
    }
}