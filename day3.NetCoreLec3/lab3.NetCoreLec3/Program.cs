using lab3.NetCoreLec3.Data;
using lab3.NetCoreLec3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//studentmoc �� �����  object ���� ��� ������ �� ���� ���� ��������� ��� ����� 
builder.Services.AddTransient<IStudent, StudentDB>();

//AddTransient have inside it singleton and scoped can used as poth
// ��� ����� ������� ����� ���� object  �� �� �� �������� ������ ������  add singleton 
// ��� ����� ����� �� ����� �� ���� ��� ������  object  �� �� �� �������� ������ ������  add Transient
// ��� ����� ����� ��  object  �� �� �� �������� ������ ������  addscoped


//context �� ��  object �� �� ���� ���� 
builder.Services.AddDbContext<StudentDBContext>(a =>
{
    a.UseSqlServer("Server=DESKTOP-04LM1KF\\SQLEXPRESS;Database=ITIDatabase;Trusted_Connection=True;MultipleActiveResultSets=true");
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();
