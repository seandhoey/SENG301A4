using Frontend4.Hardware;
using Frontend4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn4.src
{
    public class ProductFacade
    {
        private HardwareFacade hardwareFacade;
        private BusinessRules businessRules;

        private Dictionary<SelectionButton, int> selectionButtonToIndex;

        /**
         * Constructor
         */
        public ProductFacade(HardwareFacade hardwareFacade, BusinessRules businessRules)
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;

            this.selectionButtonToIndex = new Dictionary<SelectionButton, int>();
            for (int i = 0; i < this.hardwareFacade.SelectionButtons.Length; i++)
            {
                this.hardwareFacade.SelectionButtons[i].Pressed += new EventHandler(selectionPressed);
                this.selectionButtonToIndex[this.hardwareFacade.SelectionButtons[i]] = i;
            }
        }

        /**
         * Let business rules know about button selection
         */
        public void selectionPressed(object sender, EventArgs e)
        {
            int index = this.selectionButtonToIndex[(SelectionButton)sender]; //Error here if pressed a button that doesn't exist
            var productKind = this.hardwareFacade.ProductKinds[index];
            var cents = productKind.Cost; //ProductKind is an object containing a string name and a Cents value
            int cost = (cents.Value);
            if (this.businessRules.creditInserted >= cost) //Do we have enough money?
            {
                this.businessRules.buttonPressed(index, productKind, cost, this.hardwareFacade.CoinRacks); //If so, let business rules handle
            } //else ignore
        }

        /**
         * Dispenses product requested by business rules
         */
        public void dispenseProduct(int index)
        {
            //TODO: implement
        }
    }
}
