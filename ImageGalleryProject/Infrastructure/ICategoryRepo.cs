using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Models;

namespace ImageGalleryProject.Infrastructure
{
    public interface ICategoryRepo
    {
        List<Category> GetAll();
        Category GetById(int Id);

        void Insert(Category category);
        void Update(Category category);
        void Delete(int Id);


    }

}