using Common.Domain.Bases;
using Common.Domain.Exceptions;
using Common.Domain.Tools;
using Common.Domain.ValueObjects;
using Domain.Products.Service;

namespace Domain.Products;
public class Product : BaseEntity
{
    // general
    public long CategoryId { get; private set; }
    public long SubCategoryId { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public int Visit { get; set; }
    public long Price { get; private set; }
    public long? DiscountedPrice { get; private set; }
    public string ImageName { get; private set; }
    public string ImageNameSecond { get; private set; }
    public string? ImageNameThird { get; private set; }
    public string? ImageNameFourth { get; private set; }
    public string? ImageNameFifth { get; private set; }
    public string Color { get; private set; }
    public bool IsSpecial { get; private set; }
    public bool ProductNotExist { get; private set; }
    public bool AdminSuggestion { get; private set; }
    public string Brand { get; private set; }
    public string Weight { get; private set; }
    public string Dimensions { get; private set; }
    public bool nonOriginal { get; private set; }
    public string? IncludedItems { get; private set; }
    public string? Classification { get; private set; }
    public string? Situation { get; private set; }
    public string? SpecialFeatures { get; private set; }
    public SeoData SeoData { get; private set; }

    #region products prop
    // LapTop
    public bool BigTable { get; private set; }
    public string? Cpu { get; private set; }
    public string? ProcessorSpeed { get; private set; }
    public string? Ram { get; private set; }
    public string? TypeOfRam { get; private set; }
    public string? Storage { get; private set; }
    public string? TypeOfStorage { get; private set; }
    public string? Graphic { get; private set; }
    public string? TypeOfGraphic { get; private set; }
    public string? ScreenSize { get; private set; }
    public string? Screen { get; private set; }
    public string? LapTopPorts { get; private set; }

    //Printer
    public string? CartridgeType { get; private set; }
    public string? PrintType { get; private set; }
    public string? PrintSize { get; private set; }
    public string? PrintingTechnology { get; private set; }
    public string? PaperSize { get; private set; }
    public string? PaperInputCapacity { get; private set; }
    public string? PrintResolution { get; private set; }
    public string? PrinterMemory { get; private set; }
    public string? CopySpeed { get; private set; }
    public string? FaxResolution { get; private set; }
    public string? ScannerResolution { get; private set; }
    public string? ScannerDepth { get; private set; }
    public string? MonthlyWorkCapacity { get; private set; }
    #endregion

    public Product(long categoryId, long subCategoryId, string title, string slug, string description,
        long price, long? discountedPrice, string imageName, string imageNameSecond,
        string? imageNameThird, string? imageNameFourth, string? imageNameFifth,
        string color, bool isSpecial, bool productIsExist, bool adminSuggestion,
        string brand, string weight, string dimensions, bool nonOriginal, string? includedItems,
        string? classification, string? situation, string? specialFeatures,
        SeoData seoData, bool bigTable, string? cpu, string? processorSpeed,
        string? ram, string? typeOfRam, string? storage, string? typeOfStorage,
        string? graphic, string? typeOfGraphic, string? screenSize, string? screen,
        string? lapTopPorts, string? cartridgeType, string? printType,
        string? printSize, string? printingTechnology, string? paperSize,
        string? paperInputCapacity, string? printResolution, string? printerMemory,
        string? copySpeed, string? faxResolution, string? scannerResolution,
        string? scannerDepth, string? monthlyWorkCapacity, IProductDomainService domainService)
    {
        Guard(title, slug, description, brand, color, domainService);
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
        Visit = 0;
        Price = price;
        DiscountedPrice = discountedPrice;
        ImageName = imageName;
        ImageNameSecond = imageNameSecond;
        ImageNameThird = imageNameThird;
        ImageNameFourth = imageNameFourth;
        ImageNameFifth = imageNameFifth;
        Color = color;
        IsSpecial = isSpecial;
        ProductNotExist = productIsExist;
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

    public void Edit(long categoryId, long subCategoryId, string title, string slug, string description,
         long price, long? discountedPrice, string imageName, string imageNameSecond,
         string? imageNameThird, string? imageNameFourth, string? imageNameFifth,
         string color, bool isSpecial, bool productIsExist, bool adminSuggestion,
         string brand, string weight, string dimensions, bool nonOriginal, string? includedItems,
         string? classification, string? situation, string? specialFeatures, SeoData seoData,
         bool bigTable, string? cpu, string? processorSpeed,
         string? ram, string? typeOfRam, string? storage, string? typeOfStorage,
         string? graphic, string? screenSize, string? screen,
         string? lapTopPorts, string? speaker, string? cartridgeType, string? printType,
         string? printSize, string? printingTechnology, string? paperSize, string? paperInputCapacity,
         string? printResolution, string? printerMemory,
         string? copySpeed, string? faxResolution, string? scannerResolution, string? scannerDepth,
         string? monthlyWorkCapacity, IProductDomainService domainService)
    {
        Guard(title, slug, description, brand, color, domainService);
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Title = title;
        Slug = slug.ToSlug();
        Description = description;
        Price = price;
        DiscountedPrice = discountedPrice;
        ImageName = imageName;
        ImageNameSecond = imageNameSecond;
        ImageNameThird = imageNameThird;
        ImageNameFourth = imageNameFourth;
        ImageNameFifth = imageNameFifth;
        Color = color;
        IsSpecial = isSpecial;
        ProductNotExist = productIsExist;
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

    public void Guard(string Title, string slug, string Description, string Brand, string Color, IProductDomainService domainService)
    {
        NullOrEmptyException.CheckString(Title, nameof(Title));
        NullOrEmptyException.CheckString(Description, nameof(Description));
        NullOrEmptyException.CheckString(slug, nameof(slug));
        NullOrEmptyException.CheckString(Brand, nameof(Brand));
        NullOrEmptyException.CheckString(Color, nameof(Color));

        if (Slug != slug)
        {
            var result = domainService.IsSlugExist(slug);
            if (result.Status != Common.Application.OperationResultStatus.Success)
                throw new NullOrEmptyException(result.Message);
        }
    }
}