using Microsoft.EntityFrameworkCore;
using site_da_escola.Data;
using site_da_escola.Helper;
using site_da_escola.Repositorio;
using site_da_escola.Repositorio.Fixados;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DataBase");

builder.Services.AddDbContext<BancoContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IPostarEvento, PostarEvento>();
builder.Services.AddScoped<IPostarNoticia, PostarNoticia>();
builder.Services.AddScoped<IUsuario, Usuario>();
builder.Services.AddScoped<IFeedback, Feedback>();
builder.Services.AddScoped<IFixadosEventos, FixadosEventos>();
builder.Services.AddScoped<IFixadosNoticias, FixadosNoticias>();
builder.Services.AddScoped<ISessao, Sessao>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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


app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
