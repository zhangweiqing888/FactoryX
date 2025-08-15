using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using FactoryX.Infrastructure;
using FactoryX.Web.Services.Concretes;
using FactoryX.Web.Services.Abstracts;
using FactoryX.Web.Middlewares;
using FactoryX.Application.Services.Concretes;
using FactoryX.Application.Services.Abstracts;
using FactoryX.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);

// MVC Services
builder.Services.AddControllersWithViews();

// 添加本地化服务
builder.Services.AddLocalization();

// 配置本地化选项
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("en-US"), // 英文
        new CultureInfo("zh-CN"), // 中文
    };

    options.DefaultRequestCulture = new RequestCulture("zh-CN"); // 默认中文
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

// Database Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString ?? "");
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Application Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
builder.Services.AddScoped<IOperatorService, OperatorService>();
builder.Services.AddScoped<IProductionRecordService, ProductionRecordService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

// Web Services
builder.Services.AddScoped<IFirstVisitService, FirstVisitService>();

// Session Configuration
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.SecurePolicy = builder.Environment.IsDevelopment() ? CookieSecurePolicy.None : CookieSecurePolicy.Always;
});

// Authentication and Authorization Configuration
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/Login";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Exception Handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Security & Static Files
app.UseHttpsRedirection();
app.UseStaticFiles();

// 添加本地化中间件
app.UseRequestLocalization();

// Routing
app.UseRouting();

// Session & Authentication
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// 暂时禁用FirstVisitMiddleware来测试本地化功能
// app.UseMiddleware<FirstVisitMiddleware>();

app.MapStaticAssets();

// Custom Routes
app.MapControllerRoute(
    name: "login",
    pattern: "login",
    defaults: new { controller = "Account", action = "Login" });

app.MapControllerRoute(
    name: "register",
    pattern: "register",
    defaults: new { controller = "Account", action = "Register" });

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();