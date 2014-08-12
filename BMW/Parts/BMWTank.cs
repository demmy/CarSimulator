using Interfaces.Parts;

namespace BMW.Parts
{
    public class BMWTank : ITank
    {
        public BMWTank()
        {
            Capacity = 120;
        }

        public int Capacity { get; private set; }
    }
}