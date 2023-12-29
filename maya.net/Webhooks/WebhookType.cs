namespace maya.net.Webhooks;

// NOTE: to access static webhook type, use as WebhookType.<type>.Name

public class WebhookType{
    public string Name {get; private set;}
    private WebhookType(string name) {Name = name;}
    public static WebhookType Authorized {get {return new WebhookType("AUTHORIZED");}}
    public static WebhookType PaymentSuccess {get {return new WebhookType("PAYMENT_SUCCESS");}}
    public static WebhookType PaymentFailed {get {return new WebhookType("PAYMENT_FAILED");}}
    public static WebhookType PaymentExpired {get {return new WebhookType("PAYMENT_EXPIRED");}}
    public static WebhookType PaymentCancelled {get {return new WebhookType("PAYMENT_CANCELLED");}}
    public static WebhookType PaymentSuccess3DS {get {return new WebhookType("3DS_PAYMENT_SUCCESS");}}
    public static WebhookType PaymentFailure3DS {get {return new WebhookType("3DS_PAYMENT_FAILURE");}}
    public static WebhookType PaymentDropout3DS {get {return new WebhookType("3DS_PAYMENT_DROPOUT");}}
    public static WebhookType RecurringPaymentSuccess {get {return new WebhookType("RECURRING_PAYMENT_SUCCESS");}}
    public static WebhookType RecurringPaymentFailure {get {return new WebhookType("RECURRING_PAYMENT_FAILURE");}}
    public static WebhookType CheckoutSuccess {get {return new WebhookType("CHECKOUT_SUCCESS");}}
    public static WebhookType CheckoutFailure {get {return new WebhookType("CHECKOUT_FAILURE");}}
    public static WebhookType CheckoutDropout {get {return new WebhookType("CHECKOUT_DROPOUT");}}
    public static WebhookType CheckoutCancelled {get {return new WebhookType("CHECKOUT_CANCELLED");}}
}