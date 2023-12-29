using maya.net.Common;

namespace maya.net.Wallet;

public class WalletBody{
    public TotalAmount totalAmount {get; set;}
    public RedirectUrl redirectUrl {get; set;}
    public string requestReferenceNumber {get; set;}
    public string? userId {get; set;} 
    public Metadata metadata {get; set;}
}

public class TotalAmount {
    public float value {get; set;}
    public string currency {get; set;} = "PHP";
}

public class RedirectUrl{
    public string success {get; set;}
    public string failure {get; set;}
    public string cancel {get; set;}
}