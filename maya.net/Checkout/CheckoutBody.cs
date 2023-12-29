using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using maya.net.Common;

namespace maya.net.Checkout;

public class CheckoutBody{
    [Required]
    public TotalAmount totalAmount {get; set;}
    public List<Item> items {get; set;}
    [Required]
    public string requestReferenceNumber {get; set;}
    public Metadata? metadata {get; set;}
}

public class BasicCheckoutBody : CheckoutBody{
    public BasicBuyer buyer {get; set;}
}

public class KountCheckBody : CheckoutBody{
    public KountBuyer buyer {get; set;}
}

public class TotalAmount {
    public float value {get; set;}
    public string currency {get; set;} = "PHP";
}

public class Total {
    public float value {get; set;}
    public AmountDetails details {get; set;}
}

public class Item {
    public string name {get; set;}
    public string? quantity {get; set;}
    public string? code {get; set;}
    public string? description {get; set;}
    public Amount? amount {get; set;}
    public Total totalAmount {get; set;}
}

public class Amount{
    public float value {get; set;}
    public AmountDetails? details {get; set;}
}

public class AmountDetails {
    public string? subTotal {get; set;}
    public string? discount {get; set;}
    public string? serviceCharge {get;set;}
    public string? shippingFee {get; set;}
    public string? tax {get; set;}
}

public class BasicBuyer{
    public string? firstName {get; set;}
    public string? middleName {get; set;}
    public string? lastName {get; set;}
    public DateOnly? birthday {get; set;}
    public DateOnly? customerSince {get; set;}
    public string? sex {get; set;}
    public Contact? contact {get; set;}
    public BasicBillingAddress? billingAddress {get; set;}
}

public class KountBuyer{
    public string firstName {get; set;}
    public string? middleName {get; set;}
    public string lastName {get; set;}
    public DateOnly? birthday {get; set;}
    public DateOnly? customerSince {get; set;}
    public string sex {get; set;}
    public Contact? contact {get; set;}
    public KountBillingAddress? billingAddress {get; set;}
}

public class BasicBillingAddress {
    public string? line1 {get; set;}
    public string? line2 {get; set;}
    public string? city {get; set;}
    public string? state {get; set;}
    public string? zipCode {get; set;}
    public string? countryCode {get; set;} // ISO 3166 alpha-2 country notation
}

public class KountBillingAddress {
    public string? line1 {get; set;}
    public string? line2 {get; set;}
    public string? city {get; set;}
    public string? state {get; set;}
    public string? zipCode {get; set;}
    public string countryCode {get; set;} // ISO 3166 alpha-2 country notation
}

public class Contact {
    public string phone {get; set;}
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string email {get; set;}
}