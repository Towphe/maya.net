namespace maya.net.Wallet;

using System.ComponentModel.DataAnnotations;

public class WalletResponse{
    [Required]
    public string PaymentId {get; set;}
    [Required]
    public string RedirectUrl {get; set;}
}