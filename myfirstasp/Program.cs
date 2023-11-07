using Microsoft.EntityFrameworkCore;
using myfirstasp.Models;
//sebab kita na initialize constructor kita tadi dekat ModDBController

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyModDBDbContext>(options =>
{
    //useInMemoryDatabase ni, dia tak guna mysql, dia guna in-memory DB
    options.UseInMemoryDatabase("aspnet");
    //bukan terus dapat ye options nak guna use in memory db ni
    //perlu install dulu
    //ubuntu : dotnet add package Microsoft.EntityFrameworkCore.InMemory
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//custom route
app.MapControllerRoute(
    name: "TestCustomRoute",
    pattern: "{controller=Hello}/{action=NullableID}/{id?}/{test?}");
//end

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
