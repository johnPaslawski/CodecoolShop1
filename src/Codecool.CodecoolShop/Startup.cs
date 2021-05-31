using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Codecool.CodecoolShop.Daos;
using Codecool.CodecoolShop.Daos.Implementations;
using Codecool.CodecoolShop.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Codecool.CodecoolShop
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
                app.UseExceptionHandler("/Product/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Product}/{action=Index}/{id?}");
            });

            SetupInMemoryDatabases();
        }

        private void SetupInMemoryDatabases()
        {
            IProductDao productDataStore = ProductDaoMemory.GetInstance();
            IProductCategoryDao productCategoryDataStore = ProductCategoryDaoMemory.GetInstance();
            ISupplierDao supplierDataStore = SupplierDaoMemory.GetInstance();

            Supplier amazon = new Supplier{Name = "Amazon", Description = "Digital content and services"};
            supplierDataStore.Add(amazon);
            Supplier lenovo = new Supplier{Name = "Lenovo", Description = "Computers"};
            supplierDataStore.Add(lenovo);
            Supplier HP = new Supplier { Name = "HP", Description = "Laptops, electronics" };
            supplierDataStore.Add(HP);
            ProductCategory tablet = new ProductCategory {Name = "Tablet", Department = "Hardware", Description = "A tablet computer, commonly shortened to tablet, is a thin, flat mobile computer with a touchscreen display." };
            productCategoryDataStore.Add(tablet);
            ProductCategory laptop = new ProductCategory { Name = "Laptop", Department = "Hardware", Description = "Laptop is a nice, portable, foldable personal computer" };
            productCategoryDataStore.Add(laptop);
            productDataStore.Add(new Product { Name = "Amazon Fire", DefaultPrice = 49.9m, Currency = "USD", Description = "Fantastic price. Large content ecosystem. Good parental controls. Helpful technical support.", ProductCategory = tablet, Supplier = amazon });
            productDataStore.Add(new Product { Name = "Lenovo IdeaPad Miix 700", DefaultPrice = 479.0m, Currency = "USD", Description = "Keyboard cover is included. Fanless Core m5 processor. Full-size USB ports. Adjustable kickstand.", ProductCategory = tablet, Supplier = lenovo });
            productDataStore.Add(new Product { Name = "Amazon Fire HD 8", DefaultPrice = 89.0m, Currency = "USD", Description = "Amazon's latest Fire HD 8 tablet is a great value for media consumption.", ProductCategory = tablet, Supplier = amazon });
            
            productDataStore.Add(new Product { Name = "HP Pavillon 15", DefaultPrice = 989.9m, Currency = "USD", Description = "Nice laptop from HP, you must have it", ProductCategory = laptop, Supplier = HP });
            productDataStore.Add(new Product { Name = "HP Pavillon 14", DefaultPrice = 860.9m, Currency = "USD", Description = "Onother high performance laptop from HP, you must have it", ProductCategory = laptop, Supplier = HP });
            productDataStore.Add(new Product { Name = "HP Ryzen 14", DefaultPrice = 1200.0m, Currency = "USD", Description = "Not so cheap but elegant laptop from HP, you carteinly must have it", ProductCategory = laptop, Supplier = HP });
            productDataStore.Add(new Product { Name = "HP Ryzen 16", DefaultPrice = 1300.0m, Currency = "USD", Description = "Super cool, super expensive laptop from HP, dont you have one, yet ? LOL", ProductCategory = laptop, Supplier = HP });
        }
    }
}
