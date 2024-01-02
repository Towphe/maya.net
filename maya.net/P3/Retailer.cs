using System.Diagnostics.CodeAnalysis;
using maya.net.Common;

namespace maya.net.P3;

public class Retailer{
    public Metadata? metadata {get; set;}
    public string? name {get; set;}
    [NotNull]
    public Address address {get; set;}
}