namespace VW
{
    public class VWCar : AbstractCar
    {
        public VWCar(
            AbstractEngine engine,
            AbstractPanel panel,
            AbstractPedal pedal,
            AbstractRudder rudder,
            AbstractTank tank,
            AbstractTransmission transmission) : base(
                engine,
                panel,
                pedal,
                rudder,
                tank,
                transmission
                )
        {
        }
    }
}