using System.ComponentModel.DataAnnotations;
using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Product;
public class ProductViewModel
{
    public long Id { get; set; }

    public DateTime CreationDate { get; set; }

    [Display(Name = "دسته بندی")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public long CategoryId { get; set; }

    [Display(Name = "زیرگروه دسته بندی")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public long SubCategoryId { get; set; }

    [Display(Name = "slug")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Slug { get; set; }

    [Display(Name = "عنوان")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Title { get; set; }

    [Display(Name = "عکس")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public IFormFile ImageFile { get; set; }

    [Display(Name = "عکس دوم")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public IFormFile ImageFileSecond { get; set; }

    [Display(Name = "عکس سوم")]
    public IFormFile? ImageFileThird { get; set; }

    [Display(Name = "عکس چهارم")]
    public IFormFile? ImageFileFourth { get; set; }

    [Display(Name = "عکس پنجم")]
    public IFormFile? ImageFileFifth { get; set; }

    [Display(Name = "توضیحات")]
    [UIHint("Ckeditor4")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Description { get; set; }
    public long Visit { get; set; }
    public SeoDataViewModel seoDataViewModel { get; set; }
    public string ImageName { get; set; }
    public string ImageNameSecond { get; set; }
    public string? ImageNameThird { get; set; }
    public string? ImageNameFourth { get; set; }
    public string? ImageNameFifth { get; set; }

    [Display(Name = "قیمت به تومان")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public long Price { get; set; }
    public long? DiscountedPrice { get; set; }

    [Display(Name = "پیشنهاد ادمین ؟")]
    public bool AdminSuggestion { get; set; }

    [Display(Name = "پیشنهاد لحظه ای ؟")]
    public bool IsSpecial { get; set; }

    [Display(Name = "کالا موجود نیست ؟")]
    public bool ProductIsExist { get; set; }

    [Display(Name = "جدول بزرگ ؟")]
    public bool BigTable { get; set; }

    [Display(Name = "رنگ")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Color { get; set; }

    [Display(Name = "برند")]
    [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
    public string Brand { get; set; }

    [Display(Name = "وزن")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string? Weight { get; set; }

    [Display(Name = "ابعاد")]
    [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
    public string? Dimensions { get; set; }

    [Display(Name = "غیراصل")]
    public bool nonOriginal { get; set; }

    [Display(Name = "طبقه‌بندی")]
    public string? Classification { get; set; }

    [Display(Name = "اقلام همراه")]
    public string? IncludedItems { get; set; }

    [Display(Name = "وضعیت")]
    public string? Situation { get; set; }

    [Display(Name = "ویژگی های خاص")]
    public string? SpecialFeatures { get; set; }

    [Display(Name = "مدل و سری پردازنده")]
    public string? Cpu { get; set; }

    [Display(Name = "محدوده سرعت پردازنده")]
    public string? ProcessorSpeed { get; set; }

    [Display(Name = "ظرفیت Ram")]
    public string? Ram { get; set; }

    [Display(Name = "نوع Ram")]
    public string? TypeOfRam { get; set; }

    [Display(Name = "ظرفیت حافظه")]
    public string? Storage { get; set; }

    [Display(Name = "نوع حافظه")]
    public string? TypeOfStorage { get; set; }

    [Display(Name = "ظرفیت گرافیکی")]
    public string? Graphic { get; set; }

    [Display(Name = "مدل و نوع گرافیک")]
    public string? TypeOfGraphic { get; set; }

    [Display(Name = "سایز صفحه نمایش")]
    public string? ScreenSize { get; set; }

    [Display(Name = "کیفیت و توضیحات صفحه نمایش")]
    public string? Screen { get; set; }

    [Display(Name = "تعداد و نوع پورت ها")]
    public string? LapTopPorts { get; set; }

    [Display(Name = "نوع کارتریج")]
    public string? CartridgeType { get; set; }

    [Display(Name = "نوع پرینت")]
    public string? PrintType { get; set; }

    [Display(Name = "سایز پرینت")]
    public string? PrintSize { get; set; }

    [Display(Name = "تکنولوژی پرینت کردن")]
    public string? PrintingTechnology { get; set; }

    [Display(Name = "اندازه کاغذ")]
    public string? PaperSize { get; set; }

    [Display(Name = "ظرفیت ورودی کاغذ")]
    public string? PaperInputCapacity { get; set; }

    [Display(Name = "رزولوشن چاپ")]
    public string? PrintResolution { get; set; }

    [Display(Name = "حافظه پرینتر")]
    public string? PrinterMemory { get; set; }

    [Display(Name = "سرعت کپی")]
    public string? CopySpeed { get; set; }

    [Display(Name = "رزولوشن فکس")]
    public string? FaxResolution { get; set; }

    [Display(Name = "رزولوشن اسکنر")]
    public string? ScannerResolution { get; set; }

    [Display(Name = "عمق اسکنر")]
    public string? ScannerDepth { get; set; }

    [Display(Name = "توان کار ماهانه")]
    public string? MonthlyWorkCapacity { get; set; }
}