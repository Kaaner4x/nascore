using System.ComponentModel.DataAnnotations;

namespace Nascore.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "Adınız Soyadınız alanı zorunludur.")]
    [StringLength(70, MinimumLength = 3, ErrorMessage = "Adınız 3 ile 70 karakter arasında olmalıdır.")]
    [Display(Name = "Adınız Soyadınız")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "E-Posta Adresiniz alanı zorunludur.")]
    [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
    [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Lütfen e-posta adresinizi doğru formatta (örn: isim@domain.com) giriniz.")]
    [DataType(DataType.EmailAddress)]
    [Display(Name = "E-Posta Adresiniz")]
    public string Email { get; set; } = string.Empty;

    [Display(Name = "Telefon Numaranız")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Konu alanı zorunludur.")]
    [StringLength(120, MinimumLength = 3, ErrorMessage = "Konu 3 ile 120 karakter arasında olmalıdır.")]
    [Display(Name = "Konu")]
    public string Subject { get; set; } = string.Empty;

    [Required(ErrorMessage = "Mesajınız alanı zorunludur.")]
    [StringLength(3000, MinimumLength = 10, ErrorMessage = "Mesajınız 10 ile 3000 karakter arasında olmalıdır.")]
    [Display(Name = "Mesajınız")]
    public string Message { get; set; } = string.Empty;

    [Required(ErrorMessage = "KVKK onay metnini kabul etmelisiniz.")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "KVKK onay metnini kabul etmelisiniz.")]
    [Display(Name = "KVKK Onayı")]
    public bool IsKvkkAccepted { get; set; }
}
