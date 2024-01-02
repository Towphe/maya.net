using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class Merchant {
    public Metadata? metadata {get; set;}
    [NotNull]
    public string id {get; set;}
    public PaymentFacilitator paymentFacilitator {get; set;}
    public Marketplace marketplace {get; set;}
}