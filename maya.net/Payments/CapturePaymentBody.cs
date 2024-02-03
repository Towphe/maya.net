namespace maya.net.Payments;

public class CapturePaymentBody{
    public required CaptureAmount captureAmount {get; set;}
    public required string requestReferenceNumber {get; set;}
}

public class CaptureAmount{
    public required float amount {get; set;}
    public required string currency {get; set;} = "PHP";
}