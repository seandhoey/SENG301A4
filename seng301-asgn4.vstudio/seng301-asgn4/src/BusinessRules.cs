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

        public int creditInserted = 0;
        private List<Coin> addedCoins = new List<Coin>();

        /**
         * Default constructor
         */
        public BusinessRules()
        {
        }

        /**
         * Initialize the facade references
         */
        public void init(CommunicationFacade communicationFacade, PaymentFacade paymentFacade, ProductFacade productFacade)
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
         * Keep track of what coins have been inserted
         */
        public void addCoins(Coin coin)
        {
            this.addedCoins.Add(coin);
            Cents cents = coin.Value; //Weird work around
            this.creditInserted += (cents.Value);
            this.communicationFacade.addedCredit(creditInserted); //Update communication facade
        }

        public void buttonPressed(int index, ProductKind productKind, int cost, CoinRack[] coinRacks)
        {
            //Currently, button exists and we have enough credit inserted
            //Will likely need to know whats in the coinRacks. Note: you tell the facades what to do with the information

            //TODO:
            //request product facade to dispense product
            //calculate change
            //request payment facade to dispense change if applicable
        }
    }
}
