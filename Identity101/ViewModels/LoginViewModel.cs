using System.ComponentModel.DataAnnotations;

namespace Identity101.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "KullanıcıAdı")]
        [Required(ErrorMessage = "Kullanıcı alanı gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minumum 6 karakterli olmalıdır")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }    
    }
}
