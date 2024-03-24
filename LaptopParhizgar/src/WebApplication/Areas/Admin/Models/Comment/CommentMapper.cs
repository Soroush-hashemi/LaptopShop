using PresentationFacade.ProductComment.Service.DTO;

namespace WebApplication.Areas.Admin.Models.Comment;
public static class CommentMapper
{
    public static CommentViewModel Map(this ProductCommentDto dto)
    {
        return new CommentViewModel()
        {
            Id = dto.Id,
            UserFullName = dto.UserFullName,
            ProductId = dto.ProductId,
            Text = dto.Text,
            ProductSlug = dto.ProductSlug,
            ProductTitle = dto.ProductTitle,
            CreationDate = dto.CreationDate,
        };
    }

    public static List<CommentViewModel> MapList(this List<ProductCommentDto> dto)
    {
        List<CommentViewModel> model = new List<CommentViewModel>();
        dto.ForEach(c => model.Add(c.Map()));
        return model;
    }
}