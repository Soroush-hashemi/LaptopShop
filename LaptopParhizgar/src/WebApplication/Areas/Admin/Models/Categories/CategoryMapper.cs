using Application.Categories.AddChild;
using Application.Categories.Create;
using Application.Categories.Delete;
using Application.Categories.Edit;
using Query.Categories.DTOs;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Categories;
public static class CategoryMapper
{
    public static CreateCategoryCommand MapToCreateCommand(this CategoryViewModel viewModel)
    {
        return new CreateCategoryCommand(viewModel.Title, viewModel.Slug, viewModel.SeoDataViewModel.MapSeoData());
    }

    public static EditCategoryCommand MapToEditCommand(this CategoryViewModel viewModel)
    {
        return new EditCategoryCommand(viewModel.Id, viewModel.Title, viewModel.Slug, viewModel.SeoDataViewModel.MapSeoData());
    }

    public static AddChildCategoryCommand MapToAddChildCommand(this ChildCategoryViewModel viewModel)
    {
        return new AddChildCategoryCommand(viewModel.ParentId, viewModel.Title, viewModel.Slug, viewModel.SeoDataViewModel.MapSeoData());
    }

    public static DeleteCategoryCommand MapToDeleteCommand(this CategoryViewModel viewModel)
    {
        return new DeleteCategoryCommand(viewModel.Id);
    }

    public static List<CategoryViewModel> MapList(this List<CategoryDto> categoryDto)
    {
        var Model = new List<CategoryViewModel>();

        categoryDto.ForEach(c =>
        {
            Model.Add(new CategoryViewModel
            {
                Id = c.Id,
                Title = c.Title,
                ParentId = c.ParentId,
                Slug = c.Slug,
                SeoDataViewModel = c.seoDataDto.MapSeoViewModel(),
            });
        });
        return Model;
    }

    public static CategoryViewModel MapDto(this CategoryDto categoryDto)
    {
        return new CategoryViewModel()
        {
            ParentId = categoryDto.ParentId,
            Id = categoryDto.Id,
            Title = categoryDto.Title,
            Slug = categoryDto.Slug,
            SeoDataViewModel = categoryDto.seoDataDto.MapSeoViewModel(),
        };
    }

    public static List<ChildCategoryViewModel> MapChildList(this List<SubCategoryDto> categoryDto)
    {
        var Model = new List<ChildCategoryViewModel>();

        categoryDto.ForEach(c =>
        {
            Model.Add(new ChildCategoryViewModel
            {
                Id = c.Id,
                Title = c.Title,
                Slug = c.Slug,
                ParentId = c.ParentId,
                SeoDataViewModel = c.seoDataDto.MapSeoViewModel(),
            });
        });
        return Model;
    }
}