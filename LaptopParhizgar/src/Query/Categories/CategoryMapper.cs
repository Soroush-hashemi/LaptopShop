using Domain.Category;
using Query.Categories.DTOs;
using Query.SeoData;

namespace Query.Categories;
internal static class CategoryMapper
{
    public static CategoryDto Map(this Category? category)
    {
        return new CategoryDto()
        {
            ParentId = category.ParentId,
            Id = category.Id,
            Title = category.Title,
            Slug = category.Slug,
            seoDataDto = category.SeoData.MapSeo(),
            CreationDate = category.CreationDate,
            Childs = category.Childs.MapSubCategory()
        };
    }

    public static List<CategoryDto> MapList(this List<Category> categories)
    {
        var model = new List<CategoryDto>();

        categories.ForEach(category =>
        {
            model.Add(new CategoryDto()
            {
                ParentId = category.ParentId,
                Id = category.Id,
                Title = category.Title,
                Slug = category.Slug,
                seoDataDto = category.SeoData.MapSeo(),
                CreationDate = category.CreationDate,
                Childs = category.Childs.MapSubCategory()
            });
        });
        return model;
    }

    public static List<SubCategoryDto> MapSubCategory(this List<Category> child)
    {
        var model = new List<SubCategoryDto>();

        child.ForEach(c =>
        {
            model.Add(new SubCategoryDto()
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug,
                seoDataDto = c.SeoData.MapSeo(),
                CreationDate = c.CreationDate,
                ParentId = (long)c.ParentId
            });
        });
        return model;
    }
}