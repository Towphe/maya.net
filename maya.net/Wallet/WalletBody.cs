namespace maya.net.Wallet;

using System.ComponentModel.DataAnnotations;
using maya.net.Common;

public class WalletBody{
    [Required]
    [Display(Name ="Total amount and currency")]
    public TotalAmount totalAmount {get; set;}
    [Required]
    public RedirectUrl redirectUrl {get; set;}
    [Required]
    public string requestReferenceNumber {get; set;}
    public string? userId {get; set;} 
    public Metadata metadata {get; set;}
}

public class TotalAmount {
    [Required]
    public float value {get; set;}
    [Required]
    public string currency {get; set;} = "PHP";
}

