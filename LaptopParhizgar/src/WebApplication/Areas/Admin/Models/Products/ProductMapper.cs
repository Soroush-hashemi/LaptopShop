using Application.Products.Create;
using Application.Products.Delete;
using Application.Products.Edit;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PresentationFacade.RequestPayment.Service.DTO;
using Query.Products.DTOs;
using Query.SeoData;
using WebApplication.Areas.Admin.Models.RequestPayment;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Products;
public static class ProductMapper
{
    public static CreateProductCommand MapToCreate(this ProductViewModel ViewModel)
    {
        return new CreateProductCommand(ViewModel.CategoryId, ViewModel.SubCategoryId, ViewModel.Title,
        ViewModel.Slug, ViewModel.Description, ViewModel.Price, ViewModel.DiscountedPrice, ViewModel.ImageFile,
        ViewModel.ImageFileSecond, ViewModel.ImageFileThird, ViewModel.ImageFileFourth, ViewModel.ImageFileFifth,
        ViewModel.Color, ViewModel.IsSpecial, ViewModel.ProductNotExist, ViewModel.AdminSuggestion, ViewModel.Brand,
        ViewModel.Weight, ViewModel.Dimensions, ViewModel.nonOriginal, ViewModel.IncludedItems, ViewModel.Classification,
        ViewModel.Situation, ViewModel.SpecialFeatures, ViewModel.seoDataViewModel.MapSeoData(), ViewModel.BigTable,
        ViewModel.Cpu, ViewModel.ProcessorSpeed, ViewModel.Ram, ViewModel.TypeOfRam, ViewModel.Storage, ViewModel.TypeOfStorage,
        ViewModel.Graphic, ViewModel.TypeOfGraphic, ViewModel.ScreenSize, ViewModel.Screen, ViewModel.LapTopPorts, ViewModel.CartridgeType,
        ViewModel.PrintType, ViewModel.PrintSize, ViewModel.PrintingTechnology, ViewModel.PaperSize, ViewModel.PaperInputCapacity,
        ViewModel.PrintResolution, ViewModel.PrinterMemory, ViewModel.CopySpeed, ViewModel.FaxResolution, ViewModel.ScannerResolution,
        ViewModel.ScannerDepth, ViewModel.MonthlyWorkCapacity);
    }

    public static EditProductCommand MapToEdit(this ProductViewModel ViewModel)
    {
        return new EditProductCommand(ViewModel.Id, ViewModel.CategoryId, ViewModel.SubCategoryId, ViewModel.Title,
        ViewModel.Slug, ViewModel.Description, ViewModel.Price, ViewModel.DiscountedPrice, ViewModel.ImageFile,
        ViewModel.ImageFileSecond, ViewModel.ImageFileThird, ViewModel.ImageFileFourth, ViewModel.ImageFileFifth,
        ViewModel.Color, ViewModel.IsSpecial, ViewModel.ProductNotExist, ViewModel.AdminSuggestion, ViewModel.Brand,
        ViewModel.Weight, ViewModel.Dimensions, ViewModel.nonOriginal, ViewModel.IncludedItems, ViewModel.Classification,
        ViewModel.Situation, ViewModel.SpecialFeatures, ViewModel.seoDataViewModel.MapSeoData(), ViewModel.BigTable,
        ViewModel.Cpu, ViewModel.ProcessorSpeed, ViewModel.Ram, ViewModel.TypeOfRam, ViewModel.Storage, ViewModel.TypeOfStorage,
        ViewModel.Graphic, ViewModel.TypeOfGraphic, ViewModel.ScreenSize, ViewModel.Screen, ViewModel.LapTopPorts, ViewModel.CartridgeType,
        ViewModel.PrintType, ViewModel.PrintSize, ViewModel.PrintingTechnology, ViewModel.PaperSize, ViewModel.PaperInputCapacity,
        ViewModel.PrintResolution, ViewModel.PrinterMemory, ViewModel.CopySpeed, ViewModel.FaxResolution, ViewModel.ScannerResolution,
        ViewModel.ScannerDepth, ViewModel.MonthlyWorkCapacity);
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
            ProductNotExist = dto.ProductNotExist,
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

    public static ProductFilterParamsViewModel MapParamDto(this ProductFilterParams model)
    {
        return new ProductFilterParamsViewModel()
        {
            PageId = model.PageId,
            CategorySlug = model.CategorySlug,
            Take = model.Take,
            Title = model.Title,
        };
    }

    public static ProductFilterParams MapParamViewModel(this ProductFilterParamsViewModel viewmodel)
    {
        return new ProductFilterParams()
        {
            PageId = viewmodel.PageId,
            CategorySlug = viewmodel.CategorySlug,
            Take = viewmodel.Take,
            Title = viewmodel.Title,
        };
    }

    public static ProductFilterViewModel MapFilter(this ProductFilterDto dto)
    {
        return new ProductFilterViewModel()
        {
            EntityCount = dto.EntityCount,
            EndPage = dto.EndPage,
            StartPage = dto.StartPage,
            Take = dto.Take,
            CurrentPage = dto.CurrentPage,
            FilterParams = dto.FilterParams.MapParamDto(),
            Product = dto.Product.MapList(),
            PageCount = dto.PageCount,
        };
    }

    public static List<ProductViewModel> MapList(this List<ProductDto> dto)
    {
        List<ProductViewModel> model = new List<ProductViewModel>();
        dto.ForEach(c => model.Add(c.Map()));
        return model;
    }
}