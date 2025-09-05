namespace Cyberspace.Model;

using System.ComponentModel.DataAnnotations;

public class PaymentDto
{
    public string? Pan { get; set; }
    public string? Cvv { get; set; }
    public string? Expiry { get; set; }
    public string? Name { get; set; }
    public double Amount { get; set; }

}