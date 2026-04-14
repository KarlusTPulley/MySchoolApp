using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MySchoolApp.Web.Data;
using MySchoolApp.Web.MappingProfiles;
using MySchoolApp.Web.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var loggerFactory = builder.Services.BuildServiceProvider()
                                   .GetRequiredService<ILoggerFactory>();
var mapperConfig = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<SchoolMappingProfile>();
}, loggerFactory);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<ICourseSectionsService, CourseSectionsService>();
builder.Services.AddScoped<IEnrollmentsService, EnrollmentsService>();
builder.Services.AddScoped<IStudentsService, StudentsService>();
builder.Services.AddScoped<ITeachersService, TeachersService>();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await DbInitializer.SeedAsync(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
