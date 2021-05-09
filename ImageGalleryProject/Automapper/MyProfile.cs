using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;
using ImageGalleryProject.Models;
using ImageGalleryProject.ViewModels.CategoryViewModels;
using ImageGalleryProject.ViewModels.MediaViewModels;

namespace ImageGalleryProject.Automapper
{
    public class MyProfile : Profile
    {

        public MyProfile()
        {
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Category, EditCategoryViewModel>().ReverseMap();
            CreateMap<Category, CreateCategoryViewModel>().ReverseMap();

            CreateMap<Media, MediaEditViewModel>().ReverseMap();
            CreateMap<Media, MediaViewModel>()
                .ForMember(dest => dest.CategoryTitle, opt => opt.MapFrom(src => src.Category.Title));




        }


    }
}