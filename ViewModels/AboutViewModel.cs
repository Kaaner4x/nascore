using System.Collections.Generic;
using Nascore.Models;

namespace Nascore.ViewModels;

public class AboutViewModel
{
    // Banner Section
    public string BannerTitlePart1 { get; set; } = string.Empty;
    public string BannerTitlePart2 { get; set; } = string.Empty;
    public List<string> BannerDynamicWords { get; set; } = new List<string>();
    public string BannerDescription { get; set; } = string.Empty;
    public List<Feature> BannerFeatures { get; set; } = new List<Feature>();

    // Services Section
    public string ServicesTitle { get; set; } = string.Empty;
    public string ServicesDescription { get; set; } = string.Empty;
    public List<ServiceItem> Services { get; set; } = new List<ServiceItem>();

    // Skills Section
    public string SkillsImageUrl { get; set; } = string.Empty;
    public List<Skill> Skills { get; set; } = new List<Skill>();

    // Testimonials Section
    public string TestimonialsTitle { get; set; } = string.Empty;
    public string TestimonialsDescription { get; set; } = string.Empty;
    public List<Testimonial> Testimonials { get; set; } = new List<Testimonial>();
}
