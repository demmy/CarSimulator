namespace Domain.Parts
{
    public abstract class AbstractRudder
    {
        public readonly int Luft;

        protected AbstractRudder(int luft)
        {
            Luft = luft;
        }
    }
}
