using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FootballScores.Api
{
    public class Startup
    {
        private readonly string ConnectionString = @"
Data Source=(localdb)\MSSQLLocalDB;
Initial Catalog=FootballScores;
Database=FootballScores;
Integrated Security=True;
Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;
ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(ConnectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                //Init the database
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.EnsureCreated();
                    serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().EnsureSeedData();
                }
            }
        }
    }
}
