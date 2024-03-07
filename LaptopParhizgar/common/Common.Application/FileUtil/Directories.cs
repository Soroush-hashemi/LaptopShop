namespace Common.Application.FileUtil;
public class Directories
{
    public const string productImage = "wwwroot/images/Products";
    public const string productContentImage = "wwwroot/images/Products/content";
    public const string SliderImage = "wwwroot/images/Silder";
    public const string SliderPosterImage = "wwwroot/images/SilderPoster";

    public static string GetProductImage(string imageName) => $"{productImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetProductContentImage(string imageName) => $"{productContentImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetSliderImage(string imageName) => $"{SliderImage.Replace("wwwroot", "")}/{imageName}";
    public static string GetSliderPosterImage(string imageName) => $"{SliderPosterImage.Replace("wwwroot", "")}/{imageName}";
}
