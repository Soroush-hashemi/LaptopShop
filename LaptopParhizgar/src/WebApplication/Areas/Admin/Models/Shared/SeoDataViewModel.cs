using Common.Domain.ValueObjects;
using Query.SeoData;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Areas.Admin.Models.Shared;
public class SeoDataViewModel
{
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string? MetaTitle { get; set; }
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string? MetaDescription { get; set; }
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string? MetaKeyWords { get; set; }
    public bool IndexPage { get; set; }
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string? Canonical { get; set; }
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string? Schema { get; set; }
}

public static class SeoMapper
{
    public static SeoDataViewModel MapSeoViewModel(this SeoDataDto dto)
    {
        return new SeoDataViewModel()
        {
            MetaTitle = dto.MetaTitle,
            MetaDescription = dto.MetaDescription,
            MetaKeyWords = dto.MetaKeyWords,
            IndexPage = dto.IndexPage,
            Canonical = dto.Canonical,
            Schema = dto.Schema,
        };
    }

    public static SeoDataDto MapSeoDto(this SeoDataViewModel ViewModel)
    {
        return new SeoDataDto(ViewModel.MetaTitle, ViewModel.MetaDescription, ViewModel.MetaKeyWords,
            ViewModel.IndexPage, ViewModel.Canonical, ViewModel.Schema);
    }

    public static SeoData MapSeoData(this SeoDataViewModel ViewModel)
    {
        return new SeoData(ViewModel.MetaTitle, ViewModel.MetaDescription, ViewModel.MetaKeyWords,
            ViewModel.IndexPage, ViewModel.Canonical, ViewModel.Schema);
    }
}