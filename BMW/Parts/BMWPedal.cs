using Interfaces.Parts;

namespace BMW.Parts
{
    public class BMWPedal : IPedal
    {
        public BMWPedal()
        {
            Luft = 5;
        }

        public int Luft { get; private set; }
    }
}