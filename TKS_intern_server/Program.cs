using Microsoft.EntityFrameworkCore;
using TKS_intern_server.Data;
using TKS_intern_server.Mappers;
using TKS_intern_server.Repositories.Implements;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_shared.Repositories.Implements;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<TKS_internContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TKS_internContext") ?? throw new InvalidOperationException("Connection string 'TKS_internContext' not found.")));

// Add services to the container.
builder.Services.AddAutoMapper(typeof(DonViTinhProfile));
builder.Services.AddAutoMapper(typeof(SanPhamProfile));
builder.Services.AddAutoMapper(typeof(LoaiSanPhamProfile));
builder.Services.AddAutoMapper(typeof(NhaCungCapProfile));
builder.Services.AddAutoMapper(typeof(KhoProfile));
builder.Services.AddAutoMapper(typeof(KhoUserProfile));
builder.Services.AddAutoMapper(typeof(PhieuNhapKhoProfile));


builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
builder.Services.AddScoped<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddScoped<IKhoRepository, KhoRepository>();
builder.Services.AddScoped<IKhoUserRepository, KhoUserRepository>();
builder.Services.AddScoped<IPhieuNhapKhoRepository, PhieuNhapKhoRepository>();
builder.Services.AddScoped<IChiTietPhieuNhapKhoRepository, ChiTietPhieuNhapKhoRepository>();
builder.Services.AddScoped<IPhieuXuatKhoRepository, PhieuXuatKhoRepository>();




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
