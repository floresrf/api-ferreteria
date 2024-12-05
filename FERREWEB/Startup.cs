using FERREWEB.Data;
using FERREWEB.Data.Models;
using FERREWEB.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace FERREWEB
{
    public class Startup
    {
        public string ConnectionString { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            //configuracion dbcontext con sql
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnectionString));

            //configurar el servicio para que pueda ser usado
            services.AddTransient<MarcaService>();
            services.AddTransient<CategoriaService>();
            //services.AddTransient<ProductoService>();
            //services.AddTransient<CarroService>();
            //services.AddTransient<UsuarioService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API FERREWEB", Version = "v9.11" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API FERREWEB v1.1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

}
