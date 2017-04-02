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

        /**
         * Constructor
         */
        public ProductFacade(HardwareFacade hardwareFacade, BusinessRules businessRules)
        {
            this.hardwareFacade = hardwareFacade;
            this.businessRules = businessRules;
        }
    }
}
