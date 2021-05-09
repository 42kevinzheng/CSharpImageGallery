using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Models;

namespace ImageGalleryProject.Infrastructure
{
    public interface IMediaRepo
    {
        List<Media> GetAll();
        Media GetById(int Id);

        void Insert(Media mediaManager);
        void Update(Media mediaManager);
        void Delete(int Id);
        void AddRange(List<Media> model);


    }

}