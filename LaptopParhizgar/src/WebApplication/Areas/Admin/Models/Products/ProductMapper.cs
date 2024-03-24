using Application.Products.Create;
using Query.Products.DTOs;
using Query.SeoData;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Product;
public static class ProductMapper
{
    public static CreateProductCommand MapToCreate(this ProductViewModel command)
    {
        return new CreateProductCommand();
    }

    public static ProductViewModel Map(this ProductDto dto)
    {
        return new ProductViewModel()
        {
            Id = dto.Id,
            CreationDate = dto.CreationDate,
            CategoryId = dto.CategoryId,
            SubCategoryId = dto.SubCategoryId,
            Title = dto.Title,
            Slug = dto.Slug,
            Description = dto.Description,
            Visit = dto.Visit,
            Price = dto.Price,
            DiscountedPrice = dto.DiscountedPrice,
            ImageFile = dto.ImageFile,
            ImageFileSecond = dto.ImageFileSecond,
            ImageFileThird = dto.ImageFileThird,
            ImageFileFourth = dto.ImageFileFourth,
            ImageFileFifth = dto.ImageFileFifth,
            ImageName = dto.ImageName,
            ImageNameSecond = dto.ImageNameSecond,
            ImageNameThird = dto.ImageNameThird,
            ImageNameFourth = dto.ImageNameFourth,
            ImageNameFifth = dto.ImageNameFifth,
            Color = dto.Color,
            IsSpecial = dto.IsSpecial,
            ProductIsExist = dto.ProductNotExist,
            AdminSuggestion = dto.AdminSuggestion,
            Brand = dto.Brand,
            Weight = dto.Weight,
            Dimensions = dto.Dimensions,
            nonOriginal = dto.nonOriginal,
            IncludedItems = dto.IncludedItems,
            Classification = dto.Classification,
            Situation = dto.Situation,
            SpecialFeatures = dto.SpecialFeatures,
            seoDataViewModel = dto.SeoDataDto.MapSeoViewModel(),
            BigTable = dto.BigTable,
            Cpu = dto.Cpu,
            ProcessorSpeed = dto.ProcessorSpeed,
            Ram = dto.Ram,
            TypeOfRam = dto.TypeOfRam,
            Storage = dto.Storage,
            TypeOfStorage = dto.TypeOfStorage,
            Graphic = dto.Graphic,
            TypeOfGraphic = dto.TypeOfGraphic,
            Screen = dto.Screen,
            ScreenSize = dto.ScreenSize,
            LapTopPorts = dto.LapTopPorts,
            CartridgeType = dto.CartridgeType,
            PrintType = dto.PrintType,
            PrintSize = dto.PrintSize,
            PrintingTechnology = dto.PrintingTechnology,
            PaperSize = dto.PaperSize,
            PaperInputCapacity = dto.PaperInputCapacity,
            PrintResolution = dto.PrintResolution,
            PrinterMemory = dto.PrinterMemory,
            CopySpeed = dto.CopySpeed,
            FaxResolution = dto.FaxResolution,
            ScannerResolution = dto.ScannerResolution,
            ScannerDepth = dto.ScannerDepth,
            MonthlyWorkCapacity = dto.MonthlyWorkCapacity,
        };
    }

    public static List<ProductViewModel> MapList(this List<ProductDto> dto)
    {
        List<ProductViewModel> model = new List<ProductViewModel>();
        dto.ForEach(c => model.Add(c.Map()));
        return model;
    }
}