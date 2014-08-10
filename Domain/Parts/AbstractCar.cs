using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBuilder.Abstract.Parts;

namespace Domain.Parts
{
    // по сути это прокси класс ко всем запчастям
    public class AbstractCar
    {
        //запчасти
        private AbstractEngine engine;
        private AbstractPanel panel;
        private AbstractPedal pedal;
        private AbstractRudder rudder;
        private AbstractTank tank;
        private AbstractTransmission transmission;

        //состояния
        private double speed = 0;
        private double rudderDegree = 0;
        private int currentGear = 0;
        private bool headLight = false;


        //методы

        /// <summary>
        /// Ускорение
        /// </summary>
        /// <param name="pedalPress"></param>
        /// <returns></returns>
        public bool Accelerate(int pedalPress)
        {
            if (pedalPress < 0 || pedalPress > 100)
            {
                throw new ArgumentOutOfRangeException("Педаль можно нажать от нуля до 100%");
            }
        }
    }
}
