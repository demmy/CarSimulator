using Interfaces.Parts;

namespace BMW.Parts
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