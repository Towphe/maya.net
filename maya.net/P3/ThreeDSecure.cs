using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class ThreeDSecure {
    public string? xid {get; set;}
    [Required]
    public string eci {get; set;}
    public string? verificationToken {get; set;}
    [Required]
    public char enrolled {get; set;} = 'U'; // can be Y, N or U
    [Required]
    public char authenticationStatus {get; set;} = 'U';
    public string? dsTransactionId {get; set;}
    public string? messageVersion {get; set;}
}