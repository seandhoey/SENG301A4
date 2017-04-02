using Frontend4.Hardware;
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
        public CommunicationFacade(HardwareFacade hardwareFacade, BusinessRules businessRules)
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;
        }
    }
}
