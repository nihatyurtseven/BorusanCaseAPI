using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum QuantityTypes
    {
        [Display(Name = "Adet")] Adet = 1,
        [Display(Name = "Koli")] Koli = 2,
        [Display(Name = "Paket")] Paket = 3,
        [Display(Name = "Palet")] Palet = 4,
    }
}
