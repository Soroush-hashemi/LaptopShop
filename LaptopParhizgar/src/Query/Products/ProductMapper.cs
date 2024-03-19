using Domain.Products;
using Query.Products.DTOs;
using Query.SeoData;

namespace Query.Products;
public static class ProductMapper
{
    public static ProductDto Map(this Product product)
    {
        return new ProductDto()
        {
            CategoryId = product.CategoryId,
            SubCategoryId = product.SubCategoryId,
            Title = product.Title,
            Slug = product.Slug,
            Description = product.Description,
            Visit = product.Visit,
            Price = product.Price,
            DiscountedPrice = product.DiscountedPrice,
            ImageName = product.ImageName,
            ImageNameSecond = product.ImageNameSecond,
            ImageNameThird = product.ImageNameThird,
            ImageNameFourth = product.ImageNameFourth,
            ImageNameFifth = product.ImageNameFifth,
            Color = product.Color,
            IsSpecial = product.IsSpecial,
            ProductNotExist = product.ProductNotExist,
            AdminSuggestion = product.AdminSuggestion,
            Brand = product.Brand,
            Weight = product.Weight,
            Dimensions = product.Dimensions,
            nonOriginal = product.nonOriginal,
            IncludedItems = product.IncludedItems,
            Classification = product.Classification,
            Situation = product.Situation,
            SpecialFeatures = product.SpecialFeatures,
            SeoDataDto = product.SeoData.MapSeo(), // Assuming there is a method Map() in SeoData class

            // Laptop properties
            BigTable = product.BigTable,
            Cpu = product.Cpu,
            ProcessorSpeed = product.ProcessorSpeed,
            Ram = product.Ram,
            TypeOfRam = product.TypeOfRam,
            Storage = product.Storage,
            TypeOfStorage = product.TypeOfStorage,
            Graphic = product.Graphic,
            TypeOfGraphic = product.TypeOfGraphic,
            ScreenSize = product.ScreenSize,
            Screen = product.Screen,
            LapTopPorts = product.LapTopPorts,

            // Printer properties
            CartridgeType = product.CartridgeType,
            PrintType = product.PrintType,
            PrintSize = product.PrintSize,
            PrintingTechnology = product.PrintingTechnology,
            PaperSize = product.PaperSize,
            PaperInputCapacity = product.PaperInputCapacity,
            PrintResolution = product.PrintResolution,
            PrinterMemory = product.PrinterMemory,
            CopySpeed = product.CopySpeed,
            FaxResolution = product.FaxResolution,
            ScannerResolution = product.ScannerResolution,
            ScannerDepth = product.ScannerDepth,
            MonthlyWorkCapacity = product.MonthlyWorkCapacity
        };
    }
}
