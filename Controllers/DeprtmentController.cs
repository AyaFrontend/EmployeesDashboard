using AutoMapper;
using BLL2.Interfaces;
using BLL2.Repositories;
using DAL2;
using DAL2.Entities;
using EmployeesDashboard.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Controllers
{
    public class DeprtmentController : Controller
    {
       
        private readonly IUnitOfWork<Department2> _unitOfWork;
        private readonly IMapper _mapper;


        public DeprtmentController(IUnitOfWork<Department2> unitOfWork ,
            IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
           
        }
        public async Task<IActionResult> Index(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                var departments = await _unitOfWork.GenericRepository.GetAll();
                return View(_mapper.Map<IEnumerable<Department2>, IEnumerable<DepartmentViewModel>>(departments));
            }
            return View(_mapper.Map<IEnumerable<Department2>, IEnumerable<DepartmentViewModel>>( await _unitOfWork.DepartmentRepository.Search(value)));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id , string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var department = await _unitOfWork.GenericRepository.Get(id);
            if (department == null)
                return NotFound();
           
           return View( _mapper.Map<Department2 , DepartmentViewModel>(department));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] string id , DepartmentViewModel department )
        {
            if (id != department.Id)
                return BadRequest();
            if(ModelState.IsValid)
            {
                await _unitOfWork.GenericRepository.Update( _mapper.Map<DepartmentViewModel , Department2>(department));
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        [HttpGet]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.GenericRepository.Add(_mapper.Map<DepartmentViewModel, Department2>(department));
                return RedirectToAction("Index");
            }
                
            return View(department);
        }

        [HttpGet]
        public async Task<IActionResult> Delete (int?id)
        {
            return await Details(id , "Delete");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, DepartmentViewModel department)
        {
            if (id != department.Id)
                return BadRequest();
            await _unitOfWork.GenericRepository.Delete(_mapper.Map<DepartmentViewModel, Department2>(department));
            return RedirectToAction("Index");
        }

    }
}
