using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Areas.Admin.Controllers;
public class UploadController : AdminControllerBase
{
    private IFileService _fileManager;
    public UploadController(IFileService fileManager)
    {
        _fileManager = fileManager;
    }

    [Route("/Upload/Article")]
    public IActionResult UploadArticleImage(IFormFile upload)
    {
        if (upload == null)
            BadRequest();

        var imageName = _fileManager.SaveFileAndGenerateName(upload, Directories.productContentImage);

        return Json(new { Uploaded = true, url = Directories.GetProductContentImage(imageName) });
    }
}