namespace maya.net.Payments;

public interface IPaymentsHandler{

    /// <summary>
    /// Retrieve the transaction information by supplying its payment ID.
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public Task<dynamic> RetrievePaymentById(string paymentId);
    /// <summary>
    /// Retrieve the transaction/s information by supplying a merchant's request reference number.
    /// </summary>
    /// <param name="rrn"></param>
    /// <returns></returns>
    public Task<dynamic> RetrievePaymentviaRRN(string rrn);
    /// <summary>
    /// A simplified version of the Retrieve Payment via ID API. This only returns the payment status.
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public Task<dynamic> RetrievePaymentStatus (string paymentId);
    /// <summary>
    /// Cancel the transaction identified by the payment ID.
    /// </summary>
    /// <param name="paymentId"></param>
    /// <returns></returns>
    public Task<dynamic> CancelPaymentViaID(string paymentId);
    /// <summary>
    /// Captures an AUTHORIZED or CAPTURED payment. This will create a new payment record. This payment record can be voided or refunded.
    /// </summary>
    /// <param name="paymentId"></param>
    /// <param name="captureBody"></param>
    /// <returns></returns>
    public Task<dynamic> CapturePayment(string paymentId, CapturePaymentBody captureBody);
}