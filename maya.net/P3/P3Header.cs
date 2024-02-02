using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class P3Header{
    [Required]
    public required string requestReferenceNo {get; set;}
    public string? XIdempotencyKey {get; set;}
    public double? Longitude {get; set;}
    public double? Latitude {get; set;}

}