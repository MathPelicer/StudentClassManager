using StudentClassManager.UI.Clients;
using StudentClassManager.UI.Clients.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton(provider =>
{
    var httpClient = new HttpClient();
    httpClient.BaseAddress = new("http://localhost:5047/");
    return httpClient;
});

builder.Services.AddScoped<IStudentClient, StudentClient>();
builder.Services.AddScoped<IClassClient, ClassClient>();
builder.Services.AddScoped<IClassStudentClient, ClassStudentClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
