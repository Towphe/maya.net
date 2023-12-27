using maya.net.Checkout;

namespace maya.net;

public interface ICheckoutHandler{
    ///<summary>
    /// Creates a checkout transaction.
    ///</summary>
    public Task<CheckoutResponse?> CreateCheckout(CheckoutBody checkout);
}