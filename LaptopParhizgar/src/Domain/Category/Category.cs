using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.Tools;
using Common.Domain.ValueObjects;
using Domain.Category.Service;

namespace Domain.Category;
public class Category : BaseEntity
{
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public SeoData SeoData { get; private set; }
    public long? ParentId { get; private set; }
    public List<Category> Childs { get; private set; }

    private Category()
    {
        Childs = new List<Category>();
    }

    public Category(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, domainService);
        Title = title;
        Slug = slug;
        SeoData = seoData;
        Childs = new List<Category>();
    }

    public void Edit(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
    {
        slug = slug?.ToSlug();
        Guard(title, slug, domainService);
        Title = title;
        Slug = slug;
        SeoData = seoData;
    }

    public void AddChild(string title, string slug, SeoData seoData, ICategoryDomainService domainService)
    {
        Childs.Add(new Category(title, slug, seoData, domainService)
        {
            ParentId = Id
        });
    }

    public void Guard(string title, string slug, ICategoryDomainService domainService)
    {
        NullOrEmptyException.CheckString(title, nameof(title));
        NullOrEmptyException.CheckString(slug, nameof(slug));

        var result = domainService.IsSlugExist(slug);
        if (result.Status != Common.Application.OperationResultStatus.Success)
            throw new NullOrEmptyException(result.Message);
    }
}