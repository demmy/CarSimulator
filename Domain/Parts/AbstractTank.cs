namespace Domain.Parts
{
    public abstract class AbstractTank
    {
        public readonly int Capacity;

        protected AbstractTank(int capacity)
        {
            Capacity = capacity;
        }
    }
}