using BaiThiWEBAPI.Models;
using BaiThiWEBAPI.Service.ClassImplement;
using BaiThiWEBAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors();
builder.Services.AddScoped<IServiceCRUD<Customer>, ServiceCustomerCRUD>();
builder.Services.AddScoped<IServiceCRUD<Order>, ServiceOrderCRUD>();

builder.Services.AddScoped<DatabaseContext>();
// Add services to the container.
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseAuthorization();
app.UseCors(builder => builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .SetIsOriginAllowed((host) => true)
                .AllowCredentials()
            );
app.MapControllers();

app.Run();
