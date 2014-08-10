using Domain.Parts;

namespace Domain
{
    public class AbstractCar
    {
        //TODO:Расход бензина и заправка
        //запчасти
        public AbstractEngine engine;
        public AbstractPanel panel;
        public AbstractPedal pedal;
        public AbstractRudder rudder;
        public AbstractTank tank;
        public AbstractTransmission transmission;


        public AbstractCar(AbstractEngine engine, AbstractPanel panel, AbstractPedal pedal, AbstractRudder rudder,
            AbstractTank tank, AbstractTransmission transmission)
        {
            this.engine = engine;
            this.panel = panel;
            this.pedal = pedal;
            this.rudder = rudder;
            this.tank = tank;
            this.transmission = transmission;
        }


        public virtual double Accelerate(int pedalPressPower)
        {
            return 10d * ((pedalPressPower - pedal.Reaction) / 100d);
        }

        public virtual double Break(int pedalPressPower)
        {
            return 10d * ((pedalPressPower - pedal.Reaction) / 100d);
        }
    }
}