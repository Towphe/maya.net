using maya.net.Common;

namespace maya.net.QR;

public interface IQRHandler{
    public Task<QR> CreateDynamicQR(QRBody qrBody);
}

public class Amount{
    public required float value {get; set;}
    public required string currency {get; set;}
}