using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class Transaction{
    // create static values for the values here
    public string? initiator {get; set;} = "CONSUMER";
    public string? intent {get; set;} = "PAYMENT";
    [Required]
    public Amount total {get; set;}
    public string frequencyIndicator {get; set;} = "SINGLE";
    public Recipient recipient {get; set;}
    public string? description {get; set;}
}