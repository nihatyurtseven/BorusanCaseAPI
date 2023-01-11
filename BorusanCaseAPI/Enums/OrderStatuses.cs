using System.ComponentModel.DataAnnotations;

namespace Enums
{
    public enum OrderStatuses
    {
        [Display(Name = "Sipariş Alındı")] SiparisAlindi = 0,
        [Display(Name = "Yola Çıktı")] YolaCikti = 1,
        [Display(Name = "Dağıtım Merkezinde")] DagitimMerkezinde = 2,
        [Display(Name = "Dağıtıma Çıktı")] DagitimaCikti = 3,
        [Display(Name = "Teslim Edildi")] TeslimEdildi = 4,
        [Display(Name = "Teslim Edilemedi")] TeslimEdilemedi = 5,
    }
}
