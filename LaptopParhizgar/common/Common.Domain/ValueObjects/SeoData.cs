using Common.Domain.Bases;

namespace Common.Domain.ValueObjects;
public class SeoData : BaseValueObject
{
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeyWords { get; set; }
    public bool IndexPage { get; set; }
    public string? Canonical { get; set; }
    public string? Schema { get; set; }

    public static SeoData CreateEmpty()
    {
        return new SeoData();
    }

    private SeoData()
    {

    }

    public SeoData(string? metaKeyWords, string? metaDescription, string? metaTitle, bool indexPage, string? canonical, string schema)
    {
        MetaKeyWords = metaKeyWords;
        MetaDescription = metaDescription;
        MetaTitle = metaTitle;
        IndexPage = indexPage;
        Canonical = canonical;
        Schema = schema;
    }
}