using Application.Sliders.Create;
using Application.Sliders.Edit;
using Query.Sliders.DTO;

namespace WebApplication.Areas.Admin.Models.Sliders;
public static class SliderMapper
{
    public static CreateSliderCommand MapToCreateCommand(this SliderViewModel viewModel)
    {
        return new CreateSliderCommand(viewModel.Link, viewModel.ImageFile);
    }

    public static EditSliderCommand MapToEditCommand(this SliderViewModel viewModel)
    {
        return new EditSliderCommand(viewModel.Id, viewModel.Link, viewModel.ImageFile);
    }

    public static SliderViewModel MapDto(this SliderDto dto)
    {
        return new SliderViewModel()
        {
            Id = dto.Id,
            Link = dto.Link,
            ImageName = dto.ImageName
        };
    }

    public static List<SliderViewModel> MapList(this List<SliderDto> ViewModel)
    {
        var Model = new List<SliderViewModel>();

        ViewModel.ForEach(c =>
        {
            Model.Add(new SliderViewModel
            {
                Id = c.Id,
                Link = c.Link,
                ImageName = c.ImageName,
            });
        });
        return Model;
    }
}