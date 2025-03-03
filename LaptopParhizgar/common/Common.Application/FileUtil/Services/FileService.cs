﻿using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Common.Application.FileUtil.Services
{
    public class FileService : IFileService
    {
        public void DeleteDirectory(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
                Directory.Delete(directoryPath, true);
        }

        public void DeleteFile(string path, string fileName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), path,
                  fileName);
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public void DeleteFile(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public void DeleteFileMayNull(string? path, string? fileName)
        {
            if (fileName != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), path,
                  fileName);
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
        }

        public async Task SaveFile(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);
            using var stream = new FileStream(path, FileMode.Create);

            await file.CopyToAsync(stream);
        }

        public async Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath)
        {
            if (file == null)
                throw new InvalidDataException("file is Null");

            var fileName = file.FileName;

            fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                          .Replace(":", "")
                                          .Replace(".", "") + Path.GetExtension(fileName);

            var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
            if (!Directory.Exists(folderName))
                Directory.CreateDirectory(folderName);

            var path = Path.Combine(folderName, fileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);
            return fileName;
        }

        public async Task<string> SaveFileAndGenerateNameForPdf(IFormFile? file, string directoryPath)
        {
            if (file != null)
            {
                var fileName = file.FileName;
                fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                              .Replace(":", "")
                                              .Replace(".", "") + Path.GetExtension(fileName);

                var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                var path = Path.Combine(folderName, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return fileName;
            }

            return null;
        }

        public async Task<string> SaveFileAndGenerateNameMayNull(IFormFile? file, string directoryPath)
        {
            if (file != null)
            {
                var fileName = file.FileName;

                fileName = Guid.NewGuid() + DateTime.Now.TimeOfDay.ToString()
                                              .Replace(":", "")
                                              .Replace(".", "") + Path.GetExtension(fileName);

                var folderName = Path.Combine(Directory.GetCurrentDirectory(), directoryPath.Replace("/", "\\"));
                if (!Directory.Exists(folderName))
                    Directory.CreateDirectory(folderName);

                var path = Path.Combine(folderName, fileName);

                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
                return fileName;
            }
            else
            {
                return null;
            }
        }
    }
}