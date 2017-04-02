using Frontend4.Hardware;
using Frontend4;
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
        private BusinessRules businessRules;

        //      For future addition of credit acceptance handling. Replace AcceptorClass and acceptorName as needed:
        //      private AcceptorClass acceptorName = new <AcceptorClass>();

        /**
         * Constructor
         */
        public PaymentFacade(HardwareFacade hardwareFacade, BusinessRules businessRules) //Constructor
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;

            this.hardwareFacade.CoinReceptacle.CoinAdded += new EventHandler<CoinEventArgs>(addCoin);

            //      For future addition of credit acceptance handling. Replace acceptorName and eventName as needed
            //      this.acceptorName.eventName += new EventHandler<CentEventArgs>(addCredit);

            //TODO: Add event for listening to BusinessRules for amount of change to dispense
        }

        /**
         * Let business rule know about added coins
         */
        public void addCoin(object sender, CoinEventArgs e)
        {
            businessRules.addCoins(e.Coin);
        }

        /**
         * Add credit to business rule
         */
        public void addCredit(object sender, CentEventArgs e)
        {
            businessRules.addCredit(e.Cent.Value);
        }
    
    }
}
