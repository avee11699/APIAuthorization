using APIAuthorization.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIAuthorization
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
            services.AddDbContext<AuthSettingContext>(option => option.UseSqlServer(@"Data Source=LPCKOMU005\SQLEXPRESS;Initial Catalog=CP;Integrated Security = true"));
            services.AddDbContext<MC_AuthSettingContext>(option => option.UseSqlServer(@"Data Source=LPCKOMU005\SQLEXPRESS;Initial Catalog=CP;Integrated Security = true"));
            services.AddDbContext<User_LoginContext>(option => option.UseSqlServer(@"Data Source=LPCKOMU005\SQLEXPRESS;Initial Catalog=CP;Integrated Security = true"));
          
            //services.AddDbContext<AuthSettingContext>(option => option.UseSqlServer(@"Data Source=LPCKOMU066\SQLEXPRESS;Initial Catalog=CP;Integrated Security = true"));
            //services.AddDbContext<MC_AuthSettingContext>(option => option.UseSqlServer(@"Data Source=LPCKOMU066\SQLEXPRESS;Initial Catalog=CP;Integrated Security = true"));
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();

            //services.AddMvc().AddRazorPagesOptions(options =>
            //{
            //    options.Conventions.AddPageRoute("/api/UserLogin", "");
            //});
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();


            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //name: "Default",
                //pattern: "{controller=default}/{action=Index}/{id?}");

                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
