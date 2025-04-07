using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Components.Models;

public class Note
{
    public uint Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime Date { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Poznámka nemůže být prázdná")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "Délka textu musí být mezi 3-200 znaků")]
    public string Text { get; set; }
}
