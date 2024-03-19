using Common.Query.Bases;

namespace PresentationFacade.ProductComment.Service.DTO;
public class ProductCommentDto : BaseDto
{
    public string UserFullName { get; set; }
    public long ProductId { get; set; }
    public string Text { get; set; }
    public string ProductSlug { get; set; }
    public string ProductTitle { get; set; }
}