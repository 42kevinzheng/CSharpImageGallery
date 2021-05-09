using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace ImageGalleryProject.Automapper
{
    public class MyProfile : Profile
    {

        public MyProfile()
        {
            //CreateMap<Category, CategoryViewModel>().ReverseMap();
            //CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            //CreateMap<Category, CreateCategoryViewModel>().ReverseMap();
            //CreateMap<Category, CategoryComponentViewModel>();

            //CreateMap<Media, MediaEditViewModel>().ReverseMap();
            //CreateMap<Media, MediaViewModel>()
            //    .ForMember(dest => dest.CategoryTitle, opt => opt.MapForm(src => src.Cateogry.Title));




        }


    }
}