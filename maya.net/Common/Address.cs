using System.Diagnostics.CodeAnalysis;

namespace maya.net.Common;

public class Address{
    public string? line1 {get; set;}
    [NotNull]
    public string city {get; set;}
    public string? state {get; set;}
    public string? postalCode {get; set;}
    public string alphaCountryCode {get; set;}
}