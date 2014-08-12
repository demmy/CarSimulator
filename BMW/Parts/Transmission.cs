using Interfaces.Parts;

namespace BMW.Parts
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