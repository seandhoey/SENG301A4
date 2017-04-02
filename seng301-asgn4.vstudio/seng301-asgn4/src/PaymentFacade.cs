using Frontend4.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn4.src
{
    public class PaymentFacade
    {
        private HardwareFacade hardwareFacade;
        public PaymentFacade(HardwareFacade hardwareFacade)
        {
            //Constructor
            this.hardwareFacade = hardwareFacade;
            this.hardwareFacade.CoinSlot += CoinAccepted(); //DEBUG
        }

        public void CoinAccepted()
        {
            
        }
        //Subscribe to coin inserted events
        //If coin inserted, update VendingMachine about current coin count

        //Subscribe to incoming cent events (non-coin)
        //If non-coin inserted, update VendingMachine about credit

        //If button pressed, ask VendingMachine to handle:
        //Is there enough money between credit/inserted coins?
        //VM would request product facade to dispense product?
        //VM would request payment facade to dispense change if applicable?
    }
}
