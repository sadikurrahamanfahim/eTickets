using eTickets.Data;
using Microsoft.EntityFrameworkCore;

namespace eTickets
{
    public class Startup
    {
        public Startup(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //DB Context Configuaration
            services.AddDbContext< AppDBContext> ();
            
            services.AddControllers();

            //Services configuration

        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(x => x.MapControllers());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Movies}/{action=Index}/{id?}");
            });

            //Seed database
            //AppDbInitializer.Seed(app);
            //AppDbInitializer.seedUsersAndRolesAsync(app).Wait();
        }
    }
}
