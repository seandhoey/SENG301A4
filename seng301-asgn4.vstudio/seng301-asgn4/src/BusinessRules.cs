using Frontend4;
using Frontend4.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn4.src
{
    /**
     * Class representing most of the internal software for a Vending Machine. Handles background tasks for facades
     */
    public class BusinessRules
    {
        private CommunicationFacade communicationFacade;
        private PaymentFacade paymentFacade;
        private ProductFacade productFacade;

        private int creditInserted = 0;
        private List<Coin> addedCoins = new List<Coin>();

        /**
         * Constructor
         */
        public BusinessRules(CommunicationFacade communicationFacade, PaymentFacade paymentFacade, ProductFacade productFacade)
        {
            this.communicationFacade = communicationFacade;
            this.paymentFacade = paymentFacade;
            this.productFacade = productFacade;
        }

        /**
         * Keep track of credit outside of hardware
         */
        public void addCredit(int amount)
        {
            this.creditInserted += amount;
            this.communicationFacade.addedCredit(creditInserted); //Update communication facade
        }

        /**
         * Update what coins have been inserted
         */
        public void addCoins(Coin coin)
        {
            this.addedCoins.Add(coin);
            Cents cents = coin.Value; //Weird work around
            this.creditInserted += (cents.Value);
            this.communicationFacade.addedCredit(creditInserted); //Update communication facade
        }

    }
}
