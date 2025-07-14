using Microsoft.EntityFrameworkCore;
using TKS_intern.Data;
using TKS_intern.Repositories.Implements;
using TKS_intern.Repositories.Interfaces;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TKS_internContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TKS_internContext") ?? throw new InvalidOperationException("Connection string 'TKS_internContext' not found.")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program)); // hoặc typeof(DonViTinhProfile).Assembly


builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cấu hình CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowFrontendLocalhost7033",
        policy =>
        {
            policy.WithOrigins("https://localhost:7033")
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowFrontendLocalhost7033");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
