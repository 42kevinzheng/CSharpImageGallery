using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Models;
using Microsoft.AspNetCore.Http;

namespace ImageGalleryProject.Infrastructure
{
    public interface IUnitOfWork
    {
        ICategoryRepo CategoryRepo { get; }
        IMediaRepo MediaRepo { get; }
        void Save();
        void UploadFile(List<IFormFile> files);

    }

}