using AutoMapper;
using BLL2.Interfaces;
using DAL2.Entities;
using EmployeesDashboard.Helpers;
using EmployeesDashboard.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace EmployeesDashboard.Controllers
{

    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork<Employee> _unitOfWork;
        private readonly IMapper _mapper;


        public EmployeeController(IUnitOfWork<Employee> unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<IActionResult> Index(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                var employee = await _unitOfWork.GenericRepository.GetAll();
                var employeeViewModel =
               _mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employee);

                return View(employeeViewModel);
            }
            return View(_mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(await _unitOfWork.EmployeeRepository.SearchByName(value)));

        }

        [HttpGet]
        public async Task< IActionResult >Details(int? id, string ViewName = "Details")
        {
            if (id == null)
                return NotFound();
            var employee =await _unitOfWork.GenericRepository.Get(id);
            if (employee == null)
                return NotFound();

            return View(_mapper.Map<Employee , EmployeeViewModel>(employee));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {

            return await Details(id, "Edit");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit([FromRoute] string id, EmployeeViewModel employee)
        {
            if (id != employee.Id)
                return BadRequest();
            if (ModelState.IsValid)
            {
                
                var emp = _mapper.Map<EmployeeViewModel, Employee>(employee);
                emp.ImageName = DocumentSettings.SettingUploadFiles(employee.Image, "Images");
                await _unitOfWork.GenericRepository.Update(emp);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult>Create( EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                employee.ImageName = DocumentSettings.SettingUploadFiles(employee.Image, "Images");
                var emp = _mapper.Map<EmployeeViewModel, Employee>(employee);
               await _unitOfWork.GenericRepository.Add(emp);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            return await Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] string id, EmployeeViewModel employee)
        {
            if (id != employee.Id)
                return BadRequest();
            var emp = _mapper.Map<EmployeeViewModel, Employee>(employee);
            DocumentSettings.DeleteFile( emp.ImageName, "images");
            await _unitOfWork.GenericRepository.Delete(emp);
           
            return RedirectToAction("Index");
        }
    }
}
