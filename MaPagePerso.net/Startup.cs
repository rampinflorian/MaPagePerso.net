using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.ReCaptcha;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using MaPagePerso.net.Data;
using MaPagePerso.net.Services;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MimeKit;

namespace MaPagePerso.net
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = "";
            connectionString = _env.IsDevelopment() ? Configuration.GetConnectionString("DefaultConnection") : Environment.GetEnvironmentVariable("DATABASE_URL");

            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (connectionString != null) options.UseSqlServer(connectionString);
            });

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddFlashes().AddMvc();
            
            // Captcha
            services.AddReCaptcha(Configuration.GetSection("ReCaptcha"));
            
            // AutoWiring
            services.AddTransient<MailerService>();
            services.AddTransient<MimeMessage>();
            
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
                options.ForwardedHeaders =
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseForwardedHeaders(); 
                app.UseHttpsRedirection();
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "Contact",
                    pattern: "contact/mailer",
                    defaults: new { controller = "Contact", action = "Mailer"});
                endpoints.MapControllerRoute(name: "Contact",
                    pattern: "contact/",
                    defaults: new { controller = "Contact", action = "Index"});
                endpoints.MapControllerRoute(name: "Resume",
                    pattern: "resume/",
                    defaults: new { controller = "Resume", action = "Index"});
                endpoints.MapControllerRoute(name: "Project",
                    pattern: "project/",
                    defaults: new { controller = "Project", action = "Index"});
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}