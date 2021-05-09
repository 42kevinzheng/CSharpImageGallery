using AutoMapper;
using ImageGalleryProject.Infrastructure;
using ImageGalleryProject.Models;
using ImageGalleryProject.ViewModels.CategoryViewModels;
using ImageGalleryProject.ViewModels.MediaViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGalleryProject.Controllers
{
    public class MediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MediaController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //Get: Category
        public ActionResult Index()
        {
            var categories = _unitOfWork.MediaRepo.GetAll();
            var vm = _mapper.Map<List<MediaViewModel>>(categories);
            return View(vm);
        }

        //Get: Category/Details/5
        public ActionResult Details(int Id)
        {
            var category = _unitOfWork.MediaRepo.GetById(Id);
            var vm = _mapper.Map<MediaViewModel>(category);
            return View(vm);
        }

        //Get: Category/Create
        public ActionResult Create()
        {
            ViewBag.Categories = _unitOfWork.CategoryRepo.GetAll();
            return View();
        }

        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MediaCreateViewModel vm)
        {
            try
            {
                var category = _unitOfWork.CategoryRepo.GetById(vm.CategoryId);
                List<Media> media = new List<Media>();
                foreach(var file in vm.Files)
                {
                    media.Add(new Media()
                    {
                        ImagePath = file.FileName,
                        Category = category
                }); 
                    
                }


                _unitOfWork.UploadFile(vm.Files);
                _unitOfWork.MediaRepo.AddRange(media);
                _unitOfWork.Save();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {

            ViewBag.Categories = _unitOfWork.CategoryRepo.GetAll();
            var media = _unitOfWork.MediaRepo.GetById(Id);
            var mappedMedia = _mapper.Map<MediaEditViewModel>(media);
            return View(mappedMedia);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MediaEditViewModel vm)
        {
            try
            {
                if(vm.File==null && _unitOfWork.MediaRepo.GetById(vm.Id).CategoryId == vm.CategoryId)
                {
                     RedirectToAction(nameof(Index));

                }
                else if(vm.File!=null)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);
                    var updateMedia = _unitOfWork.MediaRepo.GetById(vm.Id);
                    updateMedia.CategoryId = vm.CategoryId;
                    updateMedia.ImagePath = vm.File.FileName;

                    _unitOfWork.UploadFile(files);
                    _unitOfWork.MediaRepo.Update(updateMedia);
                    _unitOfWork.Save();
                    RedirectToAction(nameof(Index));
                }
                else if(_unitOfWork.MediaRepo.GetById(vm.Id).CategoryId!=vm.CategoryId)
                {
                    List<IFormFile> files = new List<IFormFile>();
                    files.Add(vm.File);
                    var updateMedia = _unitOfWork.MediaRepo.GetById(vm.Id);
                    updateMedia.CategoryId = vm.CategoryId;
                    updateMedia.ImagePath = _unitOfWork.MediaRepo.GetById(vm.Id).ImagePath;

                    //_unitOfWork.UploadFile(files);
                    _unitOfWork.MediaRepo.Update(updateMedia);
                    _unitOfWork.Save();
                    RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            var category = _unitOfWork.MediaRepo.GetById(Id);
            var vm = _mapper.Map<MediaViewModel>(category);
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, IFormCollection category)
        {
            try
            {
             
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }










    }
}
