using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Infrastructure;
using ImageGalleryProject.Data;
using ImageGalleryProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ImageGalleryProject.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyContext _context;
        private ICategoryRepo _categoryRepo;
        private IMediaRepo _mediaRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public UnitOfWork(MyContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
        }

        public ICategoryRepo CategoryRepo
        {
            get
            {
                return _categoryRepo = _categoryRepo ?? new CategoryRepo(_context);
            }
        }

        public IMediaRepo MediaRepo
        {
            get
            {
                return _mediaRepo = _mediaRepo ?? new MediaRepo(_context);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async void UploadFile(List<IFormFile> files)
        {
            foreach(IFormFile item in files)
            {
                long totalBytes = files.Sum(f => f.Length);
                string filename = item.FileName.Trim('"');
                filename = EnsureFileName(filename);
                byte[] buffer = new byte[16 * 1024];
                using (FileStream output = File.Create(GetpathAndFileName(filename)))
                {
                    using (Stream input = item.OpenReadStream())
                    {
                        int readBytes;
                        while((readBytes = input.Read(buffer, 0, buffer.Length))>0)
                        {
                            await output.WriteAsync(buffer, 0, readBytes);
                            totalBytes += readBytes;
                        }
                    }
                }
            }
        }

        private string EnsureFileName(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);
            return filename;
        }

        private string GetpathAndFileName(string filename)
        {
            string path = hostingEnvironment.WebRootPath + "\\uploads\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            return path + filename;

        }

    }

}