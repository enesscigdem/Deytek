using System;
using System.ComponentModel.DataAnnotations;

namespace Deytek.Models
{
	public class UserUpdateViewModel
	{
        [Display(Name = "Ad Soyad")]
        [Required(ErrorMessage = "Lütfen ad soyad giriniz")]
        public string namesurname { get; set; }

        [Display(Name = "Mail Adres")]
        [Required(ErrorMessage = "Lütfen mail giriniz")]
        public string mail { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen şifre giriniz")]
        public string password { get; set; }

        [Display(Name = "Şifre Tekrar")]
        [Compare("password", ErrorMessage = "Şifreler Uyuşmuyor!")]
        public string confirmpassword { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Lütfen kullanıcı adınızı giriniz")]
        public string username { get; set; }
    }
}

