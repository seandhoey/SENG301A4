using System;
using System.Collections.Generic;

namespace Frontend4.Hardware {

    /// <summary>
    /// A set of coins. Some events fire with the Coin property set; others fire with the
    /// Coins property set.
    /// </summary>
    public class CentEventArgs : EventArgs {
        public Cents Cent { get; set; }
    }
}