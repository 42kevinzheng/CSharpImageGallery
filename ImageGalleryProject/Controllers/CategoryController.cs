using AutoMapper;
using ImageGalleryProject.Infrastructure;
using ImageGalleryProject.Models;
using ImageGalleryProject.ViewModels.CategoryViewModels;
using ImageGalleryProject.ViewModels.MediaViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ImageGalleryProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //Get: Category
        public ActionResult Index()
        {
            var categories = _unitOfWork.CategoryRepo.GetAll();
            var vm = _mapper.Map<List<CategoryViewModel>>(categories);
            return View(vm);
        }

        //Get: Category/Details/5
        public ActionResult Details(int Id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(Id);
            var vm = _mapper.Map<CategoryViewModel>(category);
            return View(vm);
        }

        //Get: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCategoryViewModel category)
        {
            try
            {
                var mappedCategory = _mapper.Map<Category>(category);
                _unitOfWork.CategoryRepo.Insert(mappedCategory);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int Id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(Id);
            var vm = _mapper.Map<EditCategoryViewModel>(category);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditCategoryViewModel vm)
        {
            try
            {
                var mappedCategory = _mapper.Map<Category>(vm);
                _unitOfWork.CategoryRepo.Update(mappedCategory);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int Id)
        {
            var category = _unitOfWork.CategoryRepo.GetById(Id);
            var vm = _mapper.Map<CategoryViewModel>(category);
            return View(vm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int Id, CategoryViewModel category)
        {
            try
            {
                _unitOfWork.CategoryRepo.Delete(Id);
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }










    }
}
