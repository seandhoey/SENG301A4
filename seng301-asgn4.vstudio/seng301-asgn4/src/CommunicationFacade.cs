using Frontend4.Hardware;
using Frontend4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace seng301_asgn4.src
{
    public class CommunicationFacade
    {
        private HardwareFacade hardwareFacade;
        private BusinessRules businessRules;

        public string Message { get; protected set; }
        public event EventHandler<MessageEventArgs> creditDisplay;

        private int creditAvailable = 0;
        private Dictionary<SelectionButton, int> selectionButtonToIndex;

        /**
         * Constructor
         */
        public CommunicationFacade(HardwareFacade hardwareFacade, BusinessRules businessRules)
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
            int index = this.selectionButtonToIndex[(SelectionButton)sender];
            //TODO:
            //Let business rule know which button
            //Is there enough money between credit/inserted coins?
            //Rules would request product facade to dispense product?
            //Rules would request payment facade to dispense change if applicable?
        }

        /**
         * Update available credit, and broadcast the amount
         */
        public void addedCredit(int creditAvailable)
        {
            this.creditAvailable = creditAvailable;
            String message = this.creditAvailable.ToString();
            var oldMessage = this.Message;
            this.Message = message;
            if (this.creditDisplay != null) //Broadcast creditDisplay event
            {
                this.creditDisplay(this, new MessageEventArgs() { NewMessage = this.Message, OldMessage = oldMessage });
            }
        }
    }
}
