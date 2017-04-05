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

        /**
         * Constructor
         */
        public CommunicationFacade(HardwareFacade hardwareFacade, BusinessRules businessRules)
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;
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
