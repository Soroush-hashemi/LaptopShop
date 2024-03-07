using System.Drawing;
using Microsoft.AspNetCore.Http;

namespace Common.Application.SecurityUtil
{
    public static class ImageValidator
    {
        public static bool IsImage(this IFormFile? file) // اعتبار سنجی تصاویر رو چک میکنه
        {
            if (file == null)
                return false;

            try
            {
                var img = Image.FromStream(file.OpenReadStream());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
