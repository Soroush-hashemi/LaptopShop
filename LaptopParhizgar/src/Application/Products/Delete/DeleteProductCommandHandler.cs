using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Domain.Products.Repository;

namespace Application.Products.Delete;
public class DeleteProductCommandHandler : IBaseCommandHandler<DeleteProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IProductCommentRepository _commentRepository;
    private readonly IFileService _fileService;
    public DeleteProductCommandHandler(IProductRepository repository, IProductCommentRepository commentRepository, IFileService fileService)
    {
        _repository = repository;
        _commentRepository = commentRepository;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _repository.GetTracking(request.ProductId);
        if (product == null)
            return OperationResult.NotFound();

        var Comment = _commentRepository.GetByProductId(request.ProductId);
        var CartItemProduct = _repository.GetCartsByProductId(request.ProductId);

        if (Comment != null)
        {
            foreach (var item in Comment)
            {
                _commentRepository.DeleteProductComment(item);
            }
        }

        if (CartItemProduct != null)
        {
            foreach (var item in CartItemProduct)
            {
                _repository.DeleteCartItem(item);
            }
        }

        var Image = product.ImageName;
        var ImageSecond = product.ImageNameSecond;

        _fileService.DeleteFile(Directories.productImage, Image);
        _fileService.DeleteFile(Directories.productImage, ImageSecond);

        var ImageThird = product?.ImageNameThird;
        var ImageFourth = product?.ImageNameFourth;
        var ImageFifth = product?.ImageNameFifth;

        _fileService.DeleteFileMayNull(Directories.productImage, ImageThird);
        _fileService.DeleteFileMayNull(Directories.productImage, ImageFourth);
        _fileService.DeleteFileMayNull(Directories.productImage, ImageFifth);

        _repository.DeleteProduct(product);
        await _repository.Save();
        return OperationResult.Success();
    }
}