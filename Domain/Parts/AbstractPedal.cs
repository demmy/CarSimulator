namespace Domain.Parts
{
    public abstract class AbstractPedal
    {
        public readonly int Reaction;

        protected AbstractPedal(int reaction)
        {
            Reaction = reaction;
        }
    }
}
