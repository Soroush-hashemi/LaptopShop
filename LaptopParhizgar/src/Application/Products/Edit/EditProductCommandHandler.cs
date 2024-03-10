using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Products.Repository;
using Domain.Products.Service;
using Microsoft.AspNetCore.Http;

namespace Application.Products.Edit;
public class EditProductCommandHandler : IBaseCommandHandler<EditProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IProductDomainService _domainService;
    private readonly IFileService _fileService;
    public EditProductCommandHandler(IProductRepository repository, IProductDomainService domainService, IFileService fileServiceS)
    {
        _repository = repository;
        _domainService = domainService;
        _fileService = fileServiceS;
    }

    public async Task<OperationResult> Handle(EditProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.productImage);
            var ImageNameSecond = await _fileService.SaveFileAndGenerateName(request.ImageFileSecond, Directories.productImage);
            var ImageNameThird = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileThird, Directories.productImage);
            var ImageNameFourth = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileFourth, Directories.productImage);
            var ImageNameFifth = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileFifth, Directories.productImage);

            var oldImage = product.ImageName;
            var oldImageSecond = product.ImageNameSecond;
            var oldImageThird = product?.ImageNameThird;
            var oldImageFourth = product?.ImageNameFourth;
            var oldImageFifth = product?.ImageNameFifth;

            if (request.DiscountedPrice == 0)
                request.DiscountedPrice = null;

            product.Edit(request.CategoryId, request.SubCategoryId, request.Title, request.Slug, request.Description
                    , request.Price, request.DiscountedPrice, ImageName, ImageNameSecond, ImageNameThird, ImageNameFourth, ImageNameFifth
                    , request.Color, request.IsSpecial, request.ProductNotExist, request.AdminSuggestion, request.Brand, request.Weight
                    , request.Dimensions, request.nonOriginal, request.IncludedItems, request.Classification, request.Situation, request.SpecialFeatures
                    , request.SeoData, request.BigTable, request.Cpu, request.ProcessorSpeed, request.Ram, request.TypeOfRam, request.Storage
                    , request.TypeOfStorage, request.Graphic, request.TypeOfGraphic, request.ScreenSize, request.Screen, request.LapTopPorts
                    , request.CartridgeType, request.PrintType, request.PrintSize, request.PrintingTechnology, request.PaperSize
                    , request.PaperInputCapacity, request.PrintResolution, request.PrinterMemory, request.CopySpeed, request.FaxResolution
                    , request.ScannerResolution, request.ScannerDepth, request.MonthlyWorkCapacity, _domainService);

            await _repository.Save();
            RemoveOldImage(request.ImageFile, oldImage);
            RemoveOldImage(request.ImageFileSecond, oldImageSecond);

            RemoveOldImage(request.ImageFileThird, oldImageThird);
            RemoveOldImage(request.ImageFileFourth, oldImageFourth);
            RemoveOldImage(request.ImageFileFifth, oldImageFifth);

            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }

    private void RemoveOldImage(IFormFile imageFile, string oldImageName)
    {
        if (imageFile != null)
        {
            _fileService.DeleteFile(Directories.productImage, oldImageName);
        }
    }
}