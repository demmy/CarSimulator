using Domain.Parts;

namespace Domain
{
    // по сути это прокси класс ко всем запчастям
    public class AbstractCar
    {
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
    }
}