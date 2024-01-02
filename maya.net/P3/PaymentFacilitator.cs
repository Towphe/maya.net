using System.Diagnostics.CodeAnalysis;
using maya.net.Common;


namespace maya.net.P3;

public class PaymentFacilitator {
    public Metadata metadata {get; set;}
    [NotNull]
    public string id {get; set;}
    [NotNull]
    public string name {get; set;}
    public string? mcc {get; set;}
    [NotNull]
    public Address address {get; set;}
    public string contactNo {get; set;}
}