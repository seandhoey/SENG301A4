using System;
using System.Collections.Generic;
using Frontend4;
using Frontend4.Hardware;
using seng301_asgn4.src;

//This class is used for the business logic?

/**
 * Represents vending machines, fully configured and with all software
 * installed.
 * 
 */
public class VendingMachine {

    private HardwareFacade hardwareFacade;
    public HardwareFacade Hardware
    {
        get
        {
            return this.hardwareFacade;
        }
    }
    private CommunicationFacade communicationFacade;
    public CommunicationFacade Communication
    {
        get
        {
            return this.communicationFacade;
        }
    }
    private PaymentFacade paymentFacade;
    public PaymentFacade Payment
    {
        get
        {
            return this.paymentFacade;
        }
    }
    private ProductFacade productFacade;
    public ProductFacade Product
    {
        get
        {
            return this.productFacade;
        }
    }


    /**
     * Creates a standard arrangement for the vending machine. All the
     * components are created and interconnected. The hardware is initially
     * empty. The product kind names and costs are initialized to &quot; &quot;
     * and 1 respectively.
     * 
     * @param coinKinds
     *            The values (in cents) of each kind of coin. The order of the
     *            kinds is maintained. One coin rack is produced for each kind.
     *            Each kind must have a unique, positive value.
     * @param selectionButtonCount
     *            The number of selection buttons on the machine. Must be
     *            positive.
     * @param coinRackCapacity
     *            The maximum capacity of each coin rack in the machine. Must be
     *            positive.
     * @param productRackCapacity
     *            The maximum capacity of each product rack in the machine. Must
     *            be positive.
     * @param receptacleCapacity
     *            The maximum capacity of the coin receptacle, storage bin, and
     *            delivery chute. Must be positive.
     * @throws IllegalArgumentException
     *             If any of the arguments is null, or the size of productCosts
     *             and productNames differ.
     */
    public VendingMachine(Cents[] coinKinds, int selectionButtonCount, int coinRackCapacity, int productRackCapacity, int receptacleCapacity)
    {
        //Facade initialization
        this.hardwareFacade = new HardwareFacade(coinKinds, selectionButtonCount, coinRackCapacity, productRackCapacity, receptacleCapacity);
        this.communicationFacade = new CommunicationFacade();
        this.paymentFacade = new PaymentFacade();
        this.productFacade = new ProductFacade();
    }
}
