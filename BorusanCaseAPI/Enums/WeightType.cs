using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum WeightType
    {
        [Display(Name = "Kg")] Kg = 1,
        [Display(Name = "Ton")] Ton = 2,
    }
}
