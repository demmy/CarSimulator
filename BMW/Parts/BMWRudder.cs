using Interfaces.Parts;

namespace BMW.Parts
{
    public class BMWRudder : IRudder
    {
        public BMWRudder()
        {
            Luft = 5;
        }

        public int Luft { get; private set; }
    }
}