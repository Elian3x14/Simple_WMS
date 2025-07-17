using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TKS_intern_server.Data;
using TKS_intern_server.Mappers;
using TKS_intern_server.Repositories.Implements;
using TKS_intern_server.Repositories.Interfaces;
using TKS_intern_server.Services.Implements;
using TKS_intern_server.Services.Interfaces;
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
builder.Services.AddAutoMapper(typeof(ChiTietPhieuXuatKhoProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);


// Repositories
builder.Services.AddScoped<IDonViTinhRepository, DonViTinhRepository>();
builder.Services.AddScoped<ILoaiSanPhamRepository, LoaiSanPhamRepository>();
builder.Services.AddScoped<ISanPhamRepository, SanPhamRepository>();
builder.Services.AddScoped<INhaCungCapRepository, NhaCungCapRepository>();
builder.Services.AddScoped<IKhoRepository, KhoRepository>();
builder.Services.AddScoped<IKhoUserRepository, KhoUserRepository>();
builder.Services.AddScoped<IPhieuNhapKhoRepository, PhieuNhapKhoRepository>();
builder.Services.AddScoped<IChiTietPhieuNhapKhoRepository, ChiTietPhieuNhapKhoRepository>();
builder.Services.AddScoped<IPhieuXuatKhoRepository, PhieuXuatKhoRepository>();
builder.Services.AddScoped<IChiTietPhieuXuatKhoRepository, ChiTietPhieuXuatKhoRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
// Services
builder.Services.AddScoped<ITokenService, TokenService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtKey = builder.Configuration["JwtSettings:Key"];
if (string.IsNullOrEmpty(jwtKey))
{
    throw new InvalidOperationException("JWT Key is not configured properly.");
}

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(jwtKey)
            )
        };
    });


builder.Services.AddAuthorization();


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

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
