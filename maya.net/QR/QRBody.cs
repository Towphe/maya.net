using maya.net.Common;

namespace maya.net.QR;

public class QRBody{
    public required Amount totalAmount {get; set;}
    public RedirectUrl? redirectUrl {get; set;}
    public required string requestReferenceNumber {get; set;}
    public Metadata? metadata {get; set;}
}