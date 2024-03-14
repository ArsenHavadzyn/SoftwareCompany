using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoftwareCompany.Domain;
using SoftwareCompany.Domain.Repositories.Abstract;
using SoftwareCompany.Domain.Repositories.EntityFramework;
using SoftwareCompany.Service;

var builder = WebApplication.CreateBuilder(args);
var config = new Config();

builder.Configuration.Bind("Project", config);

builder.Services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
builder.Services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
builder.Services.AddTransient<DataManger>();

builder.Configuration.GetConnectionString("AppDbContextConnection");

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opts =>
{
	opts.User.RequireUniqueEmail = true;
	opts.Password.RequiredLength = 6;
	opts.Password.RequireNonAlphanumeric = false;
	opts.Password.RequireLowercase = false;
	opts.Password.RequireUppercase = false;
	opts.Password.RequireDigit = false;
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
	options.Cookie.Name = "softwareCompanyAuth";
	options.Cookie.HttpOnly = true;
	options.LoginPath = "/account/login";
	options.AccessDeniedPath = "/account/accessdeniend";
	options.SlidingExpiration = true;

});

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();