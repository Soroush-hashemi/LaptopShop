using Common.Application;
using Common.Domain.ValueObjects;
using Microsoft.AspNetCore.Http;

namespace Application.Products.Create;
public class CreateProductCommand : IBaseCommand
{
    public long CategoryId { get; set; }
    public long SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public long Price { get; set; }
    public long? DiscountedPrice { get; set; }
    public IFormFile ImageFile { get; set; }
    public IFormFile ImageFileSecond { get; set; }
    public IFormFile? ImageFileThird { get; set; }
    public IFormFile? ImageFileFourth { get; set; }
    public IFormFile? ImageFileFifth { get; set; }
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
    public SeoData SeoData { get; set; }

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

    public CreateProductCommand(long categoryId, long subCategoryId, string title, string slug, string description,
        long price, long? discountedPrice, IFormFile imageFile, IFormFile imageFileSecond, IFormFile? imageFileThird,
        IFormFile? imageFileFourth, IFormFile? imageFileFifth, string color, bool isSpecial, bool productNotExist,
        bool adminSuggestion, string brand, string weight, string dimensions, bool nonOriginal, string? includedItems,
        string? classification, string? situation, string? specialFeatures, SeoData seoData, bool bigTable, string? cpu,
        string? processorSpeed, string? ram, string? typeOfRam, string? storage, string? typeOfStorage, string? graphic,
        string? typeOfGraphic, string? screenSize, string? screen, string? lapTopPorts, string? cartridgeType, string? printType,
        string? printSize, string? printingTechnology, string? paperSize, string? paperInputCapacity, string? printResolution,
        string? printerMemory, string? copySpeed, string? faxResolution, string? scannerResolution, string? scannerDepth, string? monthlyWorkCapacity)
    {
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Slug = slug;
        Description = description;
        Price = price;
        DiscountedPrice = discountedPrice;
        ImageFile = imageFile;
        ImageFileSecond = imageFileSecond;
        ImageFileThird = imageFileThird;
        ImageFileFourth = imageFileFourth;
        ImageFileFifth = imageFileFifth;
        Color = color;
        IsSpecial = isSpecial;
        ProductNotExist = productNotExist;
        AdminSuggestion = adminSuggestion;
        Brand = brand;
        Weight = weight;
        Dimensions = dimensions;
        this.nonOriginal = nonOriginal;
        IncludedItems = includedItems;
        Classification = classification;
        Situation = situation;
        SpecialFeatures = specialFeatures;
        SeoData = seoData;
        BigTable = bigTable;
        Cpu = cpu;
        ProcessorSpeed = processorSpeed;
        Ram = ram;
        TypeOfRam = typeOfRam;
        Storage = storage;
        TypeOfStorage = typeOfStorage;
        Graphic = graphic;
        TypeOfGraphic = typeOfGraphic;
        ScreenSize = screenSize;
        Screen = screen;
        LapTopPorts = lapTopPorts;
        CartridgeType = cartridgeType;
        PrintType = printType;
        PrintSize = printSize;
        PrintingTechnology = printingTechnology;
        PaperSize = paperSize;
        PaperInputCapacity = paperInputCapacity;
        PrintResolution = printResolution;
        PrinterMemory = printerMemory;
        CopySpeed = copySpeed;
        FaxResolution = faxResolution;
        ScannerResolution = scannerResolution;
        ScannerDepth = scannerDepth;
        MonthlyWorkCapacity = monthlyWorkCapacity;
    }
}