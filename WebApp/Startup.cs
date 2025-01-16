using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using WebApp.Repositories;
using WebApp.Database;
using WebApp.Services;
using WebApp.Services;

namespace WebApp
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(connection);
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                });
            services.AddHttpClient<ITicketMicroservice, TicketMicroserviceImpl>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7295/");
            });
            services.AddHttpClient<IUserMicroservice, UserMicroserviceImpl>(client =>
            {
                client.BaseAddress = new Uri("https://localhost:7299/");
            });
            //services.AddTransient<ITicketService, TicketService>();
            //services.AddTransient<IUserService, UserService>();
            services.AddSession();
			services.AddMvc();

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseFileServer();

            app.UseRouting();

            app.UseAuthentication();    
            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}