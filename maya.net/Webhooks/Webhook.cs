using System.ComponentModel.DataAnnotations;
using maya.net.Webhooks;

public class Webhook{
    
    [Required]
    [Display(Name="Webhook ID")]
    public string Id {get; set;}

    [Required]
    [Display(Name="Name of Webhook")]
    public string Name {get; set;}

    [Required]
    [Display(Name="Callback URL")]
    public string CallbackURL {get; set;}

    [Required]
    [Display(Name="Date of creation")]
    public DateTime CreatedAt {get; set;} = DateTime.Now;
}