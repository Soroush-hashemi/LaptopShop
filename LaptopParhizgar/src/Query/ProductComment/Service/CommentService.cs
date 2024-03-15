using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.ProductComment.DTO;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Query.ProductComment.Service;
public class CommentService : ICommentService
{
    private readonly LaptopParhizgerContext _context;
    public CommentService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public List<ProductCommentDto> GetAllCommentsForAdmin()
    {
        var comment = _context.ProductComments.OrderByDescending(c => c.CreationDate).ToList();
        List<ProductCommentDto> commentList = new List<ProductCommentDto>();

        foreach (var item in comment)
        {
            var product = _context.Products.FirstOrDefault(c => c.Id == item.ProductId);
            var User = _context.Users.FirstOrDefault(c => c.Id == item.UserId);
            var commentDto = new ProductCommentDto()
            {
                ProductSlug = product.Slug,
                ProductTitle = product.Title,
                Text = item.Text,
                UserFullName = User.FullName,
                Id = item.Id,
            };
            commentList.Add(commentDto);
        }

        return commentList;
    }

    public List<ProductCommentDto> GetProductComments(long ProductId)
    {
        var comment = _context.ProductComments.Where(c => c.ProductId == ProductId)
            .OrderByDescending(c => c.CreationDate).ToList();

        List<ProductCommentDto> commentList = new List<ProductCommentDto>();
        foreach (var item in comment)
        {
            var User = _context.Users.FirstOrDefault(c => c.Id == item.UserId);
            var commentDto = new ProductCommentDto()
            {
                Id = item.Id,
                ProductId = item.ProductId,
                Text = item.Text,
                UserFullName = User.FullName,
                CreationDate = item.CreationDate
            };
            commentList.Add(commentDto);
        }

        return commentList;
    }
}