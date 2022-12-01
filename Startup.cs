using BLL2.Interfaces;
using BLL2.Repositories;
using DAL2;
using DAL2.Context;
using DAL2.Entities;
using EmployeesDashboard.Mapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeesDashboard
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MVCAppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SQLConnectionString")));
            services.AddScoped<IDepartment, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IGenericRepository<Department2>,GenericRepository<Department2>>();
            services.AddScoped<IGenericRepository<Employee>, GenericRepository<Employee>>();
            services.AddScoped<IUnitOfWork<Department2>, UnitOfWork<Department2>>();
            services.AddScoped<IUnitOfWork<Employee>, UnitOfWork<Employee>>();
            services.AddAutoMapper(m => m.AddProfile(new EmployeeProfile()));
            services.AddAutoMapper(m => m.AddProfile(new DepartmentProfile()));
            services.AddAuthentication();
            services.AddIdentity<Employee, IdentityRole>(
                op =>
                {
                    op.Password.RequireDigit = true;
                }).AddEntityFrameworkStores<MVCAppDbContext>().AddTokenProvider<DataProtectorTokenProvider<Employee>>(TokenOptions.DefaultProvider);


             
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
