using Interfaces.Parts;

namespace ZAZ.Parts
{
    public class Engine : IEngine
    {
        public Engine()
        {
            MaxSpeed = 250;
        }

        public int MaxSpeed { get; private set; }
    }
}