using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Components.Models;

public class FinanceProduct
{
    public uint Id { get; set; }
    [Required(ErrorMessage = "Musí obsahovat název")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "Délka názvu musí být mezi 3-50 znaků")]
    public string Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string InvestmentType { get; set; } = "Akcie";
    [Required]
    public uint PortfolioId { get; set; }
    public Portfolio? Portfolio { get; set; }
}
