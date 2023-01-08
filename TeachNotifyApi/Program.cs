using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TeachNotifyApi.Modelos;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<itesrcne_teachnotifyContext>(opt =>
opt.UseMySql("server=204.93.216.11;user=itesrcne_jacob;password=jacob1;database=itesrcne_teachnotify",
Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.29-mariadb")));

builder.Services.AddCors();

builder.Services.AddMvc();

builder.Services.AddControllers();


builder.Services.AddHttpContextAccessor();


var app = builder.Build();

app.UseCors(x => x
.AllowAnyMethod()
.AllowAnyHeader()
.SetIsOriginAllowed(origin => true)
.AllowCredentials()
);

app.UseDeveloperExceptionPage();

app.UseRequestLocalization("es-MX");

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
