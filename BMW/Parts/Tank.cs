using Interfaces.Parts;

namespace BMW.Parts
{
    public class Tank : ITank
    {
        public Tank()
        {
            Capacity = 120;
        }

        public int Capacity { get; private set; }
    }
}