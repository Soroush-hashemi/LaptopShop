using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Exceptions;
using Domain.Products;
using Domain.Products.Repository;
using Domain.Products.Service;

namespace Application.Products.Create;
public class CreateProductCommandHandler : IBaseCommandHandler<CreateProductCommand>
{
    private readonly IProductRepository _repository;
    private readonly IProductDomainService _domainService;
    private readonly IFileService _fileService;
    public CreateProductCommandHandler(IProductRepository repository, IProductDomainService domainService, IFileService fileService)
    {
        _repository = repository;
        _domainService = domainService;
        _fileService = fileService;
    }

    public async Task<OperationResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        try
        {
            if (request.DiscountedPrice == 0)
                request.DiscountedPrice = null;

            var ImageName = await _fileService.SaveFileAndGenerateName(request.ImageFile, Directories.productImage);
            var ImageNameSecond = await _fileService.SaveFileAndGenerateName(request.ImageFileSecond, Directories.productImage);
            var ImageNameThird = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileThird, Directories.productImage);
            var ImageNameFourth = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileFourth, Directories.productImage);
            var ImageNameFifth = await _fileService.SaveFileAndGenerateNameMayNull(request.ImageFileFifth, Directories.productImage);

            var product = new Product(request.CategoryId, request.SubCategoryId, request.Title, request.Slug, request.Description
                , request.Price, request.DiscountedPrice, ImageName, ImageNameSecond, ImageNameThird, ImageNameFourth, ImageNameFifth
                , request.Color, request.IsSpecial, request.ProductNotExist, request.AdminSuggestion, request.Brand, request.Weight
                , request.Dimensions, request.nonOriginal, request.IncludedItems, request.Classification, request.Situation, request.SpecialFeatures
                , request.SeoData, request.BigTable, request.Cpu, request.ProcessorSpeed, request.Ram, request.TypeOfRam, request.Storage
                , request.TypeOfStorage, request.Graphic, request.TypeOfGraphic, request.ScreenSize, request.Screen, request.LapTopPorts
                , request.CartridgeType, request.PrintType, request.PrintSize, request.PrintingTechnology, request.PaperSize
                , request.PaperInputCapacity, request.PrintResolution, request.PrinterMemory, request.CopySpeed, request.FaxResolution
                , request.ScannerResolution, request.ScannerDepth, request.MonthlyWorkCapacity, _domainService);

            _repository.Add(product);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}