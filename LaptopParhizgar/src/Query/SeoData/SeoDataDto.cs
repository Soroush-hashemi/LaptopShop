namespace Query.SeoData;
public class SeoDataDto
{
    public SeoDataDto(string? mataTitle, string? mataDescription, string? metaKeyWords,
        bool indexPage, string? canonical, string? schema)
    {
        MetaTitle = mataTitle;
        MetaDescription = mataDescription;
        MetaKeyWords = metaKeyWords;
        IndexPage = indexPage;
        Canonical = canonical;
        Schema = schema;
    }

    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeyWords { get; set; }
    public bool IndexPage { get; set; }
    public string? Canonical { get; set; }
    public string? Schema { get; set; }
}