using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Components.Models;

public class Portfolio
{
    public uint Id { get; set; }
    [Required]
    public string Quarter { get; set; } = "Q1";
    [Required]
    public string Year { get; set; }
    public string QuarterYear => $"{Quarter} {Year}";
    public List<FinanceProduct>? FinanceProducts { get; set; }
}
