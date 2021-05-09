using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ImageGalleryProject.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Media> Media { get; set; } = new List<Media>();
    }
}