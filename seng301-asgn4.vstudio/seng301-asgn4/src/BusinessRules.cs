/*Author & Student ID:  Lisa Hynes - 30011515
* Author & Student ID:  Sean Hoey - 10065269
* Assignment:		    04
* Course:		        SENG 301
* Instructor:		    Tony Tang
* TA:			        May Mahmoud
* Due Date:		        April 6th, 2017 12:00pm 
 */

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

        /*
         * Clears the addedCoins list and sets creditInserted back to zero
         */
        public void clearLists()
        {
            addedCoins.Clear();
            creditInserted = 0;
        }

        /**
         * coinkRacks is an array containing each coin rack, ordered by the configured coinKinds
         */
        public void buttonPressed(int index, ProductKind productKind, int cost, CoinRack[] coinRacks)
        {
            //Currently, button exists and we have enough credit inserted
            this.productFacade.dispenseProduct(index);      //tells the product facade to dispense product
            List<int> coinIndices = new List<int>();
            int change = 0;
            int changeNeeded = 0;

            change = creditInserted - cost;     //calculates the change needed
            changeNeeded = change;
            
            this.paymentFacade.dispenseChange(change, changeNeeded);    //tells the payment facade to dispense change
        }
    }
}