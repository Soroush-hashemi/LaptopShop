using Application.Sliders.CreateSliderPosters;
using Application.Sliders.DeleteSliderPoster;
using Application.Sliders.EditSliderPoster;
using Domain.Sliders;
using Query.SliderPosters.DTO;

namespace WebApplication.Areas.Admin.Models.SliderPosters;
public class SliderPosterViewModel
{
    public long Id { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
    public IFormFile ImageFile { get; set; }
    public ImageLocation ImageLocation { get; set; }
}

public static class SliderPosterMapper
{
    public static CreateSliderPostersCommand MapCreate(this SliderPosterViewModel viewModel)
    {
        return new CreateSliderPostersCommand(viewModel.Link, viewModel.ImageLocation, viewModel.ImageFile);
    }

    public static EditSliderPostersCommand MapEdit(this SliderPosterViewModel viewModel)
    {
        return new EditSliderPostersCommand(viewModel.Id, viewModel.Link, viewModel.ImageFile, viewModel.ImageLocation);
    }

    public static DeleteSliderPostersCommand MapDelete(this long Id)
    {
        return new DeleteSliderPostersCommand(Id);
    }

    public static SliderPosterViewModel Map(this SliderPostersDto dto)
    {
        return new SliderPosterViewModel()
        {
            Id = dto.Id,
            Image = dto.Image,
            Link = dto.Link,
            ImageFile = dto.ImageFile,
            ImageLocation = dto.ImageLocationDto,
        };
    }

    public static List<SliderPosterViewModel> MapList(this List<SliderPostersDto> dtos)
    {
        List<SliderPosterViewModel> model = new List<SliderPosterViewModel>();
        dtos.ForEach(c => model.Add(c.Map()));
        return model;
    }
}