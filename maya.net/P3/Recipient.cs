using System.ComponentModel.DataAnnotations;
using maya.net.Common;

namespace maya.net.P3;

public class Recipient {
    [Required]
    public string firstName {get; set;}
    [Required]
    public string lastName {get; set;}
    [Required]
    public Address address {get; set;}
    [Required]
    public string accountNumber {get; set;}
    public string? accountTargetIdentificationCode {get; set;} = null;
    [Required]
    public string accountNumberType {get; set;} // refer to documentation for options (create class for its options)
    public string? description {get; set;} = null;
}

