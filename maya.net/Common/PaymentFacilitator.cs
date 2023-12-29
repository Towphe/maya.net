using System.ComponentModel.DataAnnotations;

namespace maya.net.Common;

public class PaymentFacilitator{
    [Required]
    public string smi {get; set;}
    [Required]
    public string smn {get; set;}
    [Required]
    public string mci {get; set;}
    [Required]
    [MaxLength(3, ErrorMessage = "ISO 4217 Currency code must have max 3 digits")]
    public string mpc {get; set;}
    [Required]
    [MaxLength(3, ErrorMessage = "ISO 3166 Country code must have max 3 digits")]
    public string mco {get; set;}
    [Required]
    public string? mst {get; set;}
    public string? mcc {get; set;}
    public string? postalCode {get; set;}
    public string? contactNo {get; set;}
    public string? state {get; set;}
    public string? addressLine1 {get; set;}
}