using Interfaces.Parts;

namespace ZAZ.Parts
{
    public class Rudder : IRudder
    {
        public Rudder()
        {
            Luft = 5;
        }

        public int Luft { get; private set; }
    }
}