using Cartools.Areas.Admin.Services;
using Cartools.Context;
using Cartools.Models;
using Cartools.Repositories;
using Cartools.Repositories.Interfaces;
using Cartools.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;

namespace Cartools;

public class Startup
{
    public Startup(IConfiguration configuration)
    {

        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    //This method gets called by the runtime. Use this method to add ser

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        services.AddIdentity<IdentityUser, IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

        /*
        services.Configure<IdentityOptions>(options =>
        {
            //Default Password settings.
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;

        });
        */

        services.Configure<ConfigurationImagens>(Configuration.GetSection("ConfigurationPastaImagens"));

        services.Configure<ConfigurationImagensParceiros>(Configuration.GetSection("ConfigurationPastaImagensParceiros"));


        services.AddTransient<IServicoRepository, ServicoRepository>();
        services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddTransient<IPlanoRepository, PlanoRepository>();
        services.AddTransient<ITipoRepository, TipoRepository>();
        services.AddTransient<ILocalRepository, LocalRepository>();
        services.AddTransient<IOficinaRepository, OficinaRepository>();

        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();
        services.AddScoped<RelatorioVendasService>();
        services.AddScoped(sp => CarrinhoCompra.GetCarrinho(sp));

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Admin", politica_admin =>
            {
                politica_admin.RequireRole("Admin");
            });
        });

        services.AddAuthorization(options =>
        {
            options.AddPolicy("Parceiro", politica_parceiro =>
            {
                politica_parceiro.RequireRole("Parceiro");
            });
        });



        services.AddControllersWithViews();

        services.AddPaging(options =>
        {
            options.ViewName = "Bootstrap4";
            options.PageParameterName = "pageindex";
        });

        services.AddMemoryCache();
        services.AddSession();


    }

    //This method gets called by the runtime. Use this method to configure

    public void Configure(IApplicationBuilder app,
        IWebHostEnvironment env, ISeedUserRoleInitial seedUserRoleInitial)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            //The default HSTS value is 30 days. You may want to change

            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        //cria os perfis
        seedUserRoleInitial.SeedRoles();

        //cria os usuários e atributos ao perfil
        seedUserRoleInitial.SeedUsers();

        app.UseSession();

        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Parceiro}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");
            
            endpoints.MapControllerRoute(
                name: "servicoFiltro",
                pattern: "Servico/{action}/{servico?}",
                defaults: new { Controller = "Servico", action = "List" });

            endpoints.MapControllerRoute(
                name: "categoriaFiltro",
                pattern: "Servico/{action}/{categoria?}",
                defaults: new { Controller = "Servico", action = "List" });

            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}
