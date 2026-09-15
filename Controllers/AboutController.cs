using Microsoft.AspNetCore.Mvc;
using Nascore.ViewModels;
using Nascore.Services.Abstract;
using System.Threading.Tasks;
using System.Linq;

namespace Nascore.Controllers
{
    public class AboutController : Controller
    {
        private readonly IFeatureService _featureService;
        private readonly IServiceItemService _serviceItemService;
        private readonly ISkillService _skillService;
        private readonly ITestimonialService _testimonialService;

        public AboutController(
            IFeatureService featureService, 
            IServiceItemService serviceItemService,
            ISkillService skillService,
            ITestimonialService testimonialService)
        {
            _featureService = featureService;
            _serviceItemService = serviceItemService;
            _skillService = skillService;
            _testimonialService = testimonialService;
        }

        public async Task<IActionResult> Index()
        {
            var features = await _featureService.GetAllAsync();
            var serviceItems = await _serviceItemService.GetAllAsync();
            var skills = await _skillService.GetAllAsync();
            var testimonials = await _testimonialService.GetAllAsync();

            var model = new AboutViewModel
            {
                // Banner Sabit Metinleri
                BannerTitlePart1 = "İş ortaklarımız için",
                BannerTitlePart2 = "inşa ediyoruz",
                BannerDynamicWords = new System.Collections.Generic.List<string> { "marka kimliği", "tasarım çözümleri", "dijital stratejiler" },
                BannerDescription = "Modern web standartlarına tam uyumlu, estetik ve yüksek performanslı dijital deneyimler geliştiriyoruz. <strong>Nascore</strong> olarak, işletmenizin kurumsal vizyonunu yenilikçi teknolojiler ve yaratıcı tasarım disipliniyle geleceğe taşıyoruz.",
                BannerFeatures = features.ToList(),

                // Services Sabit Metinleri
                ServicesTitle = "Temel Hizmetlerimiz.",
                ServicesDescription = "Fikirden nihai ürüne kadar markanızın tüm dijital dönüşüm süreçlerinde uçtan uca, yenilikçi ve sonuç odaklı çözümler üretiyoruz.",
                Services = serviceItems.ToList(),

                // Skills Sabit Metinleri
                SkillsImageUrl = "/user-interface/images/about-img.jpg",
                Skills = skills.Take(8).ToList(),

                // Testimonials Sabit Metinleri
                TestimonialsTitle = "İş Ortaklarımız Ne Diyor?",
                TestimonialsDescription = "Birlikte başarı hikayeleri yazdığımız değerli markaların Nascore hakkındaki samimi değerlendirmeleri.",
                Testimonials = testimonials.ToList()
            };

            return View(model);
        }
    }
}