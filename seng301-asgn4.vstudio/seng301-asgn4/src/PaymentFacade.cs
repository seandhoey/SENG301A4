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
        private Dictionary<SelectionButton, int> selectionButtonToIndex;

        //      For future addition of credit acceptance handling. Replace AcceptorClass and acceptorName as needed
        //      private AcceptorClass acceptorName = new <AcceptorClass>();

        public PaymentFacade(HardwareFacade hardwareFacade, BusinessRules businessRules) //Constructor
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;

            this.hardwareFacade.CoinReceptacle.CoinAdded += new EventHandler<CoinEventArgs>(addCoin);

            this.selectionButtonToIndex = new Dictionary<SelectionButton, int>();
            for (int i = 0; i < this.hardwareFacade.SelectionButtons.Length; i++)
            {
                this.hardwareFacade.SelectionButtons[i].Pressed += new EventHandler(selectionPressed); //Debug: What?
                this.selectionButtonToIndex[this.hardwareFacade.SelectionButtons[i]] = i;
            }

            //      For future addition of credit acceptance handling. Replace acceptorName and eventName as needed
            //      this.acceptorName.eventName += new EventHandler<CentEventArgs>(addCredit);
        }

        public void addCoin(object sender, CoinEventArgs e) //Let business rule know about added coins
        {
            businessRules.addCoins(e.Coin);
        }

        public void addCredit(object sender, CentEventArgs e) //Add credit to business rule if fired
        {
            businessRules.addCredit(e.Cent.Value);
        }

        public void selectionPressed(object sender, CentEventArgs e)
        {
            //Let business rule know which button
            //Is there enough money between credit/inserted coins?
            //VM would request product facade to dispense product?
            //VM would request payment facade to dispense change if applicable?

            int index = this.selectionButtonToIndex[(SelectionButton)sender];
        }
    
    }
}
