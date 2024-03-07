namespace Common.Application.FileUtil;
public class Directories
{
    public const string PostImage = "wwwroot/images/post";
    public const string SliderImages = "wwwroot/images/sliders";
    public const string StudentsImages = "wwwroot/images/Student";
    public const string TeachersImages = "wwwroot/images/Teachers";
    public const string PDF = "wwwroot/pdfs";

    public static string GetPostImage(string imageName) => $"{PostImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetPDFFile(string? pdfFileName) => $"{PDF.Replace("wwwroot", "")}/{pdfFileName}";
    public static string GetSliderImage(string imageName) => $"{SliderImages.Replace("wwwroot", "")}/{imageName}";
    public static string GetStudentImage(string imageName) => $"{StudentsImages.Replace("wwwroot", "")}/{imageName}";
    public static string GetTeacherImage(string imageName) => $"{TeachersImages.Replace("wwwroot", "")}/{imageName}";
}
