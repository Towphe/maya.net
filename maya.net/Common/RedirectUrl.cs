namespace maya.net.Common;

using System.ComponentModel.DataAnnotations;

public class RedirectUrl{
    [Required]
    public string success {get; set;}
    [Required]
    public string failure {get; set;}
    [Required]
    public string cancel {get; set;}
}