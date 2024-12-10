using ADSWebApi.Services;

namespace ADSWebApi
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
            services.AddControllers();
            services.AddSwaggerGen();

            // configure DI for application services
            services.AddScoped<ITur_categoria_publicacionService,
Tur_categoria_publicacionService>();
            services.AddScoped<ITur_comercioService,
                Tur_comercioService>();
            services.AddScoped<ITur_mensaje_aprobacionService,
                Tur_mensaje_aprobacionService>();
            services.AddScoped<ITur_mensaje_rechazoService,
    Tur_mensaje_rechazoService>();
            services.AddScoped<ITur_movimientos_comercioService,
    Tur_movimientos_comercioService>();
            services.AddScoped<ITur_notificacionesService,
                Tur_notificacionesService>();
            services.AddScoped<ITur_publicacionesService,
                Tur_publicacionesService>();

            services.AddScoped<ITur_turistaService,
                Tur_turistaService>();
            services.AddScoped<ITur_videos_educativosService,
    Tur_videos_educativosService>();
            services.AddScoped<ITur_videosService,
    Tur_videosService>();
            services.AddScoped<ITur_visitas_x_turistaService,
    Tur_visitas_x_turistaService>();
            services.AddScoped<ITur_visitas_x_turistaService, Tur_visitas_x_turistaService>();
            services.AddScoped<IFavoritosService, FavoritosService>();
            services.AddCors();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseStaticFiles();
                app.UseStaticFiles(new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers
                           .Add("X-Copyright", "Copyright 2016 - JMA");
                    }
                });
            }
            //app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taskman API V1"); });
            app.UseRouting();
            // if (env.EnvironmentName == "Development")
            // {
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
            Console.WriteLine(env.EnvironmentName);
            //app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
