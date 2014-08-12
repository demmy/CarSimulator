namespace ZAZ
{
    public class ZAZCar : AbstractCar
    {
        public ZAZCar(
            AbstractEngine engine,
            AbstractPanel panel,
            AbstractPedal pedal,
            AbstractRudder rudder,
            AbstractTank tank,
            AbstractTransmission transmission
            ) : base(
                engine, panel, pedal, rudder, tank, transmission
                )
        {
        }
    }
}