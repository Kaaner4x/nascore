namespace Nascore.ViewModels;

public class ContactViewModel
{
    // Banner Bilgileri
    public string BannerTitlePart1 { get; set; } = string.Empty;
    public string BannerTitlePart2 { get; set; } = string.Empty;
    public string BannerDescription { get; set; } = string.Empty;

    // İletişim Bilgileri (Sol Taraf)
    public string Address { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string WorkingHours { get; set; } = string.Empty;
    public string GoogleMapsUrl { get; set; } = string.Empty;

    // Form Bilgileri (Sağ Taraf)
    public ContactFormViewModel Form { get; set; } = new ContactFormViewModel();
}
