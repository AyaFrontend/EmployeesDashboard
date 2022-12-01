using AutoMapper;
using DAL2.Entities;
using EmployeesDashboard.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesDashboard.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _user;
        private readonly IMapper _mapper;
        private readonly SignInManager<Employee> _signInManager;


        public AccountController(UserManager<Employee> user , IMapper mapper,
            SignInManager<Employee> signInManager)
        {
            _user = user;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Registration(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {

              var result = await  _user.CreateAsync(_mapper.Map<RegistrationViewModel, Employee>(model));
                if (result.Succeeded)
                   return RedirectToAction("Login", "Account");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                Employee user = await _user.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var password = await _user.CheckPasswordAsync(user, model.Password);
                    if(password != null)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Index", "Employee");
                    }
                }
                return View("Login");
            }
            return View("Login");
        }
    }
}
