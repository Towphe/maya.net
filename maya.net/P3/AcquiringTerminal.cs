using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace maya.net.P3;

public class AcquiringTerminal{
    [NotNull]
    public string id {get; set;}
    public InputCapability? inputCapability {get; set;}
    public PosEntryMode posEntryMode {get; set;}
    public bool? onMerchantPremise {get; set;} = true;
    public bool? terminalAttended {get; set;} = true;
    public bool? cardCaptureSupported {get; set;} = false;
    public bool? cardholderActivatedTerminal {get; set;} = false;
    [Required]
    public string type {get; set;}
}

public class InputCapability {
    public bool? keyEntry {get; set;}
    public bool? magstripeReader {get; set;}
    public bool? emvChip {get; set;}
    public bool? contactless {get; set;}
    public bool contactlessMagstripe {get; set;}
}

public class PosEntryMode {
    [Required]
    public string panEntry {get; set;}
    public string? pinEntry {get; set;}
}