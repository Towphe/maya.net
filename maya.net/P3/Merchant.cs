using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace maya.net.P3;

public class Merchant {
    public Metadata? metadata {get; set;}
    [Required]
    public string id {get; set;}
    
}

public class EcommerceMerchant : Merchant{
    public PaymentFacilitator paymentFacilitator {get; set;}
    public Marketplace marketplace {get; set;}
}

public class CardMerchant : Merchant{
    [Required]
    public AcquiringTerminal acquiringTerminal {get; set;}
}
