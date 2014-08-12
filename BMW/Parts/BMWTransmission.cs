using Interfaces.Parts;

namespace BMW.Parts
{
    public class BMWTransmission : ITransmission
    {
        public BMWTransmission()
        {
            MaxGear = 6;
        }

        public int MaxGear { get; private set; }
    }
}