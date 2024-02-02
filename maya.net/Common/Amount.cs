using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class Amount{
    public string? currency {get; set;}
    public decimal? value {get; set;}
}