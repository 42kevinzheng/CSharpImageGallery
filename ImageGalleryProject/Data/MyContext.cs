using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ImageGalleryProject.Models;
using ImageGalleryProject.ViewModels.CategoryViewModels;

namespace ImageGalleryProject.Data
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Media> Media { get; set; }

        public DbSet<ImageGalleryProject.ViewModels.CategoryViewModels.CategoryViewModel> CategoryViewModel { get; set; }

        public DbSet<ImageGalleryProject.ViewModels.CategoryViewModels.CreateCategoryViewModel> CreateCategoryViewModel { get; set; }

        public DbSet<ImageGalleryProject.ViewModels.CategoryViewModels.EditCategoryViewModel> EditCategoryViewModel { get; set; }

  
    }
}