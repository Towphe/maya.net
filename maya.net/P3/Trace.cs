using System.ComponentModel.DataAnnotations;

namespace maya.net.P3;

public class Trace{
    [MinLength(1)]
    [MaxLength(6)]
    public string? batchNo {get; set;}
    [MinLength(1)]
    [MaxLength(6)]
    public string? traceNo {get; set;}
}