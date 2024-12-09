using PersonalProjeto.Aplicacao;
using PersonalProjeto.Dal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Adiciona o IConfiguration ao container de DI
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<ConexaoMySql>();

builder.Services.AddTransient<PersonalAplicacao>();
builder.Services.AddTransient<AlunoAplicacao>();


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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
