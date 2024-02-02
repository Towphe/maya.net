using maya.net.Common;

namespace maya.net.QR;

public interface IQRHandler{
    /// <summary>
    /// Creates a dynamic QR payment transaction.
    /// </summary>
    /// <param name="qrBody"></param>
    /// <returns></returns>
    public Task<QR> CreateDynamicQR(QRBody qrBody);
}

public class Amount{
    public required float value {get; set;}
    public required string currency {get; set;}
}