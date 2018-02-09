using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UsherSheat.Service;
using UsherSheat.Service.Service;

namespace UsherSheat.Api
{
    public class Startup
    {
        public static UnitOfWork DataContext;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
            services.AddMvc();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISeatService, SeatService>();
            services.AddTransient<IBuildingEventService, BuildingEventService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
                {    
                    routes.MapRoute("defaut","{controller}/{action}/{id}");
                }
            );
        }
    }
}
