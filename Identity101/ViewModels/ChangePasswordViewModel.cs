
using System.ComponentModel.DataAnnotations;

namespace Identity101.ViewModels
{
    public class ChangePasswordViewModel
    {


        [Required(ErrorMessage = "Eski şifre alanı gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minumum 6 karakterli olmalıdır")]
        [Display(Name = "Eski Şifre")]
        [DataType(DataType.Password)]
        public string EskiPassword { get; set; }


        [Required(ErrorMessage = "Yeni şifre alanı gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minumum 6 karakterli olmalıdır")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler uyuşmuyor")]
        public string ConfirmNewPassword { get; set; }

    }
}