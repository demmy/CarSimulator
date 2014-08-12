using Interfaces.Parts;

namespace ZAZ.Parts
{
    public class Pedal : IPedal
    {
        public Pedal()
        {
            Luft = 5;
        }

        public int Luft { get; private set; }
    }
}