using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using ImageGalleryProject.Infrastructure;
using ImageGalleryProject.Data;
using ImageGalleryProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageGalleryProject.Services
{
    public class MediaRepo : IMediaRepo
    {
        private readonly MyContext _context;

        public MediaRepo(MyContext context)
        {
            _context = context;
        }
        public void AddRange(List<Media> model)
        {
            _context.Media.AddRange(model);
        }

        public void Delete(int Id)
        {
            var mediaManager = GetById(Id);
            _context.Media.Remove(mediaManager);
        }
        public List<Media> GetAll()
        {
            var data = _context.Media.Include(x => x.Category).ToList();
            return data;
        }

        public Media GetById(int Id)
        {
            return _context.Media.Where(x => x.Id == Id).Include(x=> x.Category).FirstOrDefault();
        }

        public void Insert(Media mediaManager)
        {
            _context.Media.Add(mediaManager);
        }
        public void Update(Media mediaManager)
        {
            _context.Media.Update(mediaManager);
        }
    }

}