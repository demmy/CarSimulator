using Interfaces.Parts;

namespace ZAZ.Parts
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