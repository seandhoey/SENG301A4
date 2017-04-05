<<<<<<< HEAD
﻿using Frontend4;
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
        { //Reference made, but values not initialized
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
         * Keep track of credit (not in hardware)
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

        /**
         * coinkRacks is an array containing each coin rack, ordered by the configured coinKinds
         */
        public void buttonPressed(int index, ProductKind productKind, int cost, CoinRack[] coinRacks)
        {
            //Currently, button exists and we have enough credit inserted
            this.productFacade.dispenseProduct(index);
            List<int> coinIndices = new List<int>();

            //TODO:
            //calculate change
            //request payment facade to dispense change if applicable
            this.paymentFacade.dispenseChange(coinIndices);
        }
    }
}
=======
﻿using Frontend4;
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
        { //Reference made, but values not initialized
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
         * Keep track of credit (not in hardware)
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

        /**
         * coinkRacks is an array containing each coin rack, ordered by the configured coinKinds
         */
        public void buttonPressed(int index, ProductKind productKind, int cost, CoinRack[] coinRacks)
        {
            //Currently, button exists and we have enough credit inserted
            this.productFacade.dispenseProduct(index);
            List<int> coinIndices = new List<int>();

            //TODO:
            //calculate change
            //request payment facade to dispense change if applicable
            this.paymentFacade.dispenseChange(coinIndices);
        }
    }
}
>>>>>>> d4993314e84335080b718052a7ba32d4705132bb
