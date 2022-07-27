using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using ProyectoUdemy.Controllers.Contexto;
using ProyectoUdemy.Servicios;

namespace ProyectoUdemy
{
    public class Startup
    {
        public Startup (IConfiguration configuration)
        {
            Configuration= configuration;
        }
        public IConfiguration Configuration{get;}
        public void ConfigureService(IServiceCollection services)
        {

            services.AddAutoMapper(typeof(Startup));

            services.AddTransient<IAlmacenadorArchivos,AlmacenadorArchivoLocal>();
            services.AddHttpContextAccessor();
            services.AddDbContext<ApplicationBbContext>(options=>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            //services.AddSwaggerGen();
            
        }

        public void Configure(IApplicationBuilder app,IWebHostEnvironment env)
        {

            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                   // app.UseSwagger();
                    //app.UseSwaggerUI();
                }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endponts=>
            {
                endponts.MapControllers();

            });

        }
    }
}