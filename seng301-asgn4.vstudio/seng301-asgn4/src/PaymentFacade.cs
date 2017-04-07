/*Author & Student ID:  Lisa Hynes - 30011515
* Author & Student ID:  Sean Hoey - 10065269
* Assignment:		    04
* Course:		        SENG 301
* Instructor:		    Tony Tang
* TA:			        May Mahmoud
* Due Date:		        April 6th, 2017 12:00pm 
 */

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

        /**
         * Dispenses change requested by business rules
         * 
         * coins is a list of integers which are the indices of each coin to be dispensed
         */
        public void dispenseChange(int change, int changeNeeded)
        {
            List<int> CoinRacksL = new List<int>();
            for (int i = 0; i < this.hardwareFacade.CoinRacks.Count(); i++)
            {
                CoinRacksL.Add(this.hardwareFacade.GetCoinKindForCoinRack(i).Value);
            }

            CoinRacksL.Sort();      //sorts the coin racks
            CoinRacksL.Reverse();   //places the coin racks in highest to lowest order
    
            if (change >= 0) 
            {
                this.hardwareFacade.CoinReceptacle.StoreCoins();        //stores the coins in the coin receptacle

                if (changeNeeded > 0)
                {
                    foreach (int coinType in CoinRacksL)
                    {
                        Cents cents = new Cents(coinType);
                        while (((changeNeeded - coinType) >= 0) && (this.hardwareFacade.GetCoinRackForCoinKind(cents).Count > 0))
                        {
                            this.hardwareFacade.GetCoinRackForCoinKind(cents).ReleaseCoin();        //releases the appropriate coin
                            changeNeeded = changeNeeded - coinType;     //determines the amount of change that still needs to be given
                        }
                    }
                }
                businessRules.clearLists();                 //clears the added coins list & sets insertedCredit back to zero when the vending machine is unloaded
                businessRules.addCredit(changeNeeded);      //stores any credit remaining after change has been given
            }
        }
    }
}