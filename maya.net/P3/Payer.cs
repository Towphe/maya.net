using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;

namespace maya.net.P3;

public class Payer {
    [Required]
    public FundingInstrument fundingInstrument {get; set;}
}

public class EcommerceUsingCardPayer : Payer {
    public PayerMetaData? metadata {get; set;}
    public string? referenceId {get; set;}
}

public class CardPresentPayer :Payer{
    public FundingInstrument fundingInstrument {get; set;}
}

public class FundingInstrument {
    [Required]
    public Card card {get; set;}
}

public class PayerMetaData {
    public string? ipAddress {get; set;}
}