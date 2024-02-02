using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using maya.net.Checkout;
using System.Dynamic;

namespace maya.net.P3;

public class Card{
    [Required]
    public string cardNumber {get; set;}
    [Required]
    public string expiryMonth {get; set;}
    [Required]
    public string expiryYear {get; set;}
    public string? firstName {get; set;}
    public string? lastName {get; set;}
    // either DEBIT or CREDIT
    public string? type {get; set;}
    // either DEFAULT, SAVINGS, CURRENT OR CREDIT
    public string? account {get; set;} = "DEFAULT";
    [StringLength(3)]
    public string? csc {get; set;}
    public BillingAddress? billingAddress {get; set;}
    public bool vaulted {get; set;} = false;
    public string tokenId {get; set;}
    public string referenceId {get; set;}
    public CardPresentFields cardPresentFields {get; set;}
    public Pin pin {get; set;}
}

public class BillingAddress{
    // billing address for cards.
    public string line1 {get; set;}
    public string city {get; set;}
    public string state {get; set;}
    public string postalCode {get; set;}
    public string alphaCountryCode {get; set;}
}

public class CardPresentFields{
    public string? cardSeqNum {get; set;}
    public string? emvIccData {get; set;}
    public string? track1 {get; set;}
    public string? track2 {get; set;}
}

public class Pin{
    [Required]
    public string block {get; set;}
    [Required]
    public string format {get; set;}
    [Required]
    public string keyId {get; set;}
}