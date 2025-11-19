using HelpDeskAI.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ======================================
// 🔹 CONFIGURAÇÃO DO BANCO DE DADOS
// ======================================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// ======================================
// 🔹 CONFIGURAÇÃO DE AUTENTICAÇÃO / COOKIE
// ======================================
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Usuario/Login";
        options.LogoutPath = "/Usuario/Logout";
        options.AccessDeniedPath = "/Usuario/AcessoNegado";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", p => p.RequireRole("admin"));
    options.AddPolicy("Gestor", p => p.RequireRole("gestor", "admin"));
    options.AddPolicy("Usuario", p => p.RequireRole("usuario", "gestor", "admin"));
});

// ======================================
// 🔹 MVC (Views + Controllers)
// ======================================
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ======================================
// 🔹 MIDDLEWARE
// ======================================

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// 🔥 AUTENTICAÇÃO OBRIGATÓRIA (sem isso o login nunca funciona)
app.UseAuthentication();

// 🔥 AUTORIZAÇÃO
app.UseAuthorization();

// ======================================
// 🔹 ROTAS
// ======================================

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuario}/{action=Login}/{id?}");

app.Run();
