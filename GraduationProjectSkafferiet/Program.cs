var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(o => o.MapControllers());
app.UseStaticFiles();

app.Run();
