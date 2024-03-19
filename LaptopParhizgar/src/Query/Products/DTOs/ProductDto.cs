using Common.Query.Bases;
using Microsoft.AspNetCore.Http;
using Query.SeoData;

namespace Query.Products.DTOs;
public class ProductDto : BaseDto
{
    public readonly IFormFile ImageFile;
    public readonly IFormFile ImageFileSecond;
    public readonly IFormFile? ImageFileThird;
    public readonly IFormFile? ImageFileFourth;
    public readonly IFormFile? ImageFileFifth;
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public int Visit { get; set; }
    public long Price { get; set; }
    public long? DiscountedPrice { get; set; }
    public string ImageName { get; set; }
    public string ImageNameSecond { get; set; }
    public string? ImageNameThird { get; set; }
    public string? ImageNameFourth { get; set; }
    public string? ImageNameFifth { get; set; }
    public string Color { get; set; }
    public bool IsSpecial { get; set; }
    public bool ProductNotExist { get; set; }
    public bool AdminSuggestion { get; set; }
    public string Brand { get; set; }
    public string Weight { get; set; }
    public string Dimensions { get; set; }
    public bool nonOriginal { get; set; }
    public string? IncludedItems { get; set; }
    public string? Classification { get; set; }
    public string? Situation { get; set; }
    public string? SpecialFeatures { get; set; }
    public SeoDataDto SeoDataDto { get; set; }

    #region products prop
    // LapTop
    public bool BigTable { get; set; }
    public string? Cpu { get; set; }
    public string? ProcessorSpeed { get; set; }
    public string? Ram { get; set; }
    public string? TypeOfRam { get; set; }
    public string? Storage { get; set; }
    public string? TypeOfStorage { get; set; }
    public string? Graphic { get; set; }
    public string? TypeOfGraphic { get; set; }
    public string? ScreenSize { get; set; }
    public string? Screen { get; set; }
    public string? LapTopPorts { get; set; }

    //Printer
    public string? CartridgeType { get; set; }
    public string? PrintType { get; set; }
    public string? PrintSize { get; set; }
    public string? PrintingTechnology { get; set; }
    public string? PaperSize { get; set; }
    public string? PaperInputCapacity { get; set; }
    public string? PrintResolution { get; set; }
    public string? PrinterMemory { get; set; }
    public string? CopySpeed { get; set; }
    public string? FaxResolution { get; set; }
    public string? ScannerResolution { get; set; }
    public string? ScannerDepth { get; set; }
    public string? MonthlyWorkCapacity { get; set; }
    #endregion
}