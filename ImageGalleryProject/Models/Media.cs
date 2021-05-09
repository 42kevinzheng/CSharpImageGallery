using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ImageGalleryProject.Models
{
    public class Media
    {
        public int Id { get; set; }

        public string ImagePath { get; set; }

        public int CategoryId { get; set; }


        public Category Category { get; set; } = new Category();
    }
}