using System;
using System.Collections.Generic;

namespace Frontend4.Hardware {

    /// <summary>
    /// A set of cents.
    /// </summary>
    public class CentEventArgs : EventArgs {
        public Cents Cent { get; set; }
    }
}