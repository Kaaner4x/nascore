using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Data;
using Npgsql;
using Serilog;
using Nascore.Middlewares;

// Configure Serilog for Console and File logging
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .WriteTo.File("logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

try
{
    Log.Information("Starting web application");

    // Load .env file (for local development)
    if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") != "true")
    {
        DotNetEnv.Env.Load();
    }

    var builder = WebApplication.CreateBuilder(args);

    // Use Serilog as the logging provider
    builder.Host.UseSerilog();

    // Add PostgreSQL database connection for Dapper to the DI Container
    builder.Services.AddScoped<IDbConnection>(sp => 
        new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection"))
    );

    // DI registrations for Generic and Specific Repositories
    builder.Services.AddScoped<Nascore.Repositories.Abstract.INewsRepository, Nascore.Repositories.Concrete.NewsRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IFeatureRepository, Nascore.Repositories.Concrete.FeatureRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IServiceItemRepository, Nascore.Repositories.Concrete.ServiceItemRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.ISkillRepository, Nascore.Repositories.Concrete.SkillRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.ITestimonialRepository, Nascore.Repositories.Concrete.TestimonialRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IProjectCategoryRepository, Nascore.Repositories.Concrete.ProjectCategoryRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IProjectItemRepository, Nascore.Repositories.Concrete.ProjectItemRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IContactMessageRepository, Nascore.Repositories.Concrete.ContactMessageRepository>();

    // DI registrations for Services (Business Logic)
    builder.Services.AddScoped<Nascore.Services.Abstract.INewsService, Nascore.Services.Concrete.NewsService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IFeatureService, Nascore.Services.Concrete.FeatureService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IServiceItemService, Nascore.Services.Concrete.ServiceItemService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.ISkillService, Nascore.Services.Concrete.SkillService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.ITestimonialService, Nascore.Services.Concrete.TestimonialService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IProjectCategoryService, Nascore.Services.Concrete.ProjectCategoryService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IProjectItemService, Nascore.Services.Concrete.ProjectItemService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IContactMessageService, Nascore.Services.Concrete.ContactMessageService>();

    builder.Services.AddScoped<Nascore.Repositories.Abstract.ISiteSettingRepository, Nascore.Repositories.Concrete.SiteSettingRepository>();
    builder.Services.AddScoped<Nascore.Repositories.Abstract.IMenuItemRepository, Nascore.Repositories.Concrete.MenuItemRepository>();
    builder.Services.AddScoped<Nascore.Services.Abstract.ISiteSettingService, Nascore.Services.Concrete.SiteSettingService>();
    builder.Services.AddScoped<Nascore.Services.Abstract.IMenuItemService, Nascore.Services.Concrete.MenuItemService>();

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Add Global Exception Middleware BEFORE other middlewares
    app.UseMiddleware<GlobalExceptionMiddleware>();

    // Configure localization
    var defaultCulture = new CultureInfo("tr-TR");
    var localizationOptions = new RequestLocalizationOptions
    {
        DefaultRequestCulture = new RequestCulture(defaultCulture),
        SupportedCultures = new List<CultureInfo> { defaultCulture },
        SupportedUICultures = new List<CultureInfo> { defaultCulture }
    };
    app.UseRequestLocalization(localizationOptions);

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        // Handled by our custom GlobalExceptionMiddleware, but keeping this for standard framework catches
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    // Security Headers Middleware (Content Security Policy & XSS Protection)
    app.Use(async (context, next) =>
    {
        context.Response.Headers.Append("Content-Security-Policy",
            "default-src 'self'; " +
            "script-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net; " +
            "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdn.jsdelivr.net; " +
            "font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net data:; " +
            "img-src 'self' data: https:; " +
            "frame-src 'self' https://www.google.com; " +
            "connect-src 'self';");

        context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
        context.Response.Headers.Append("X-Frame-Options", "SAMEORIGIN");
        context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");

        await next();
    });

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}

