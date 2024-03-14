namespace Query.SeoData;
public static class SeoDataMapper
{
    public static SeoDataDto MapSeo(this Common.Domain.ValueObjects.SeoData seoData)
    {
        return new SeoDataDto(seoData.MetaTitle, seoData.MetaDescription,
            seoData.MetaKeyWords, seoData.IndexPage, seoData.Canonical, seoData.Schema);
    }
}