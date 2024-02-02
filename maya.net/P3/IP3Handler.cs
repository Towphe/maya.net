namespace maya.net.P3;

public interface IP3Handler{
    /// <summary>
    /// Perform a sale / purchase request with <b>E-Commerce using Card</b>.
    /// </summary>
    /// <param name="merchant"></param>
    /// <param name="payer"></param>
    /// <param name="threeDSecure"></param>
    /// <param name="transaction"></param>
    /// <param name="trace"></param>
    /// <returns></returns>
    public Task<dynamic> Pay(Merchant merchant, Payer payer, ThreeDSecure threeDSecure, Transaction transaction, Trace trace, P3Header p3Header);

    /// <summary>
    /// Perform a sale / purchase request with <b>E-Commerce using Card</b>
    /// </summary>
    /// <param name="merchant"></param>
    /// <param name="payer"></param>
    /// <param name="transaction"></param>
    /// <param name="trace"></param>
    /// <param name="p3Header"></param>
    /// <returns></returns>
    public Task<dynamic> Pay(Merchant merchant, Payer payer, Transaction transaction, P3Header p3Header, Trace? trace = null);
    // public Task Authorize();
    // public Task Capture();
    // public Task FinalCapture();
    // public Task Void();
    // public Task Refund();
    // public Task AccountBalanceInquiry();
    // public Task GetTransaction();
    // public Task ListTransaction();
    // public Task ServicePing();
}