using Frontend4;
using Frontend4.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn4.src
{
    public class BusinessRules
    {
        //Instance variables
        private int creditInserted = 0;
        private List<Coin> addedCoins = new List<Coin>();

        public void addCredit(int amount) //Add credit, not needed to store in hardware
        {
            this.creditInserted += amount;
        }

        public void addCoins(Coin coin) //Let the logic know what coins have been inserted
        {
            this.addedCoins.Add(coin);
            Cents cents = coin.Value; //Weird fix...
            this.creditInserted += (cents.Value);
        }

    }
}
