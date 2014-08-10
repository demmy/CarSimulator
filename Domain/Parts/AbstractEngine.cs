namespace Domain.Parts
{
    public abstract class AbstractEngine
    {
        public readonly int MaxSpeed;

        protected AbstractEngine(int maxsspeed)
        {
            MaxSpeed = maxsspeed;
        }
    }
}