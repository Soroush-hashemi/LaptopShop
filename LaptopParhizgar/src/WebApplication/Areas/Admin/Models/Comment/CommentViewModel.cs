namespace WebApplication.Areas.Admin.Models.Comment;
public class CommentViewModel
{
    public long Id { get; set; }
    public string UserFullName { get; set; }
    public long ProductId { get; set; }
    public string Text { get; set; }
    public string ProductSlug { get; set; }
    public string ProductTitle { get; set; }
    public DateTime CreationDate { get; set; }
}