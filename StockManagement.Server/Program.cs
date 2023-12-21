using Microsoft.EntityFrameworkCore;
using StockManagement.Server.ContextModels;
using StockManagement.Server.Entities;
using StockManagement.Server.Repositories;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();


builder.Services.AddIdentityCore<ApplicationUser>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<StockContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<StockContext>();


builder.Services.AddDbContext<StockContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("Stock");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "StockManagement API V1");
    c.RoutePrefix = string.Empty;
});

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
