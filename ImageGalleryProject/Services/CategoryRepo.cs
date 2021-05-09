using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Infrastructure;
using ImageGalleryProject.Data;
using ImageGalleryProject.Models;

namespace ImageGalleryProject.Services
{
    public class CategoryRepo : ICategoryRepo
    { 
        private readonly MyContext _context;

        public CategoryRepo(MyContext context)
        {
            _context = context;
        }
        public void Delete(int Id)
        {
            var category = GetById(Id);
            _context.Categories.Remove(category);
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetById(int Id)
        {
            return _context.Categories.Where(x => x.Id == Id).FirstOrDefault();
        }

        public void Insert (Category category)
        {
            _context.Categories.Add(category);
        }
        public void Update(Category  category)
        {
            _context.Categories.Update(category);
        }
    }

}