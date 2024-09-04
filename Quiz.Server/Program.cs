//using Microsoft.AspNetCore.Hosting;
//using Microsoft.EntityFrameworkCore;
//using Quiz.Server.Models;

//var builder = WebApplication.CreateBuilder(args);





//builder.Services.AddControllers();

//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();


//var provider = builder.Services.BuildServiceProvider();
//var config = provider.GetRequiredService<IConfiguration>();
//builder.Services.AddDbContext<QuizContext>(item => item.UseSqlServer(config.GetConnectionString("dbcs")));




//var app = builder.Build();

//app.UseDefaultFiles();
//app.UseStaticFiles();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.MapFallbackToFile("/index.html");

//app.Run();


//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowReactApp",
//        builder =>
//        {
//            builder.WithOrigins("https://localhost:5173") // Your React app URL
//                   .AllowAnyHeader()
//                   .AllowAnyMethod();
//        });
//});





//namespace ElearningQuizSystem.Api
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }

//    internal class Startup
//    {
//    }
//}




////using Microsoft.EntityFrameworkCore;
////using Microsoft.IdentityModel.Tokens;
////using Quiz.Server.Models;
////using System.Text;

////var builder = WebApplication.CreateBuilder(args);

////// Add services to the container.
////builder.Services.AddControllers();

////// Configure CORS
////builder.Services.AddCors(options =>
////{
////    options.AddPolicy("AllowReactApp",
////        builder =>
////        {
////            builder.WithOrigins("https://localhost:5173") // Your React app URL
////                   .AllowAnyHeader()
////                   .AllowAnyMethod();
////        });
////});

////// Configure JWT Authentication
//////builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//////    .AddJwtBearer(options =>
//////    {
//////        var jwtKey = builder.Configuration["Jwt:Key"];
//////        var jwtIssuer = builder.Configuration["Jwt:Issuer"];

//////        if (string.IsNullOrEmpty(jwtKey))
//////        {
//////            throw new ArgumentNullException("Jwt:Key", "The JWT key is not configured.");
//////        }

//////        options.TokenValidationParameters = new TokenValidationParameters
//////        {
//////            ValidateIssuer = true,
//////            ValidateAudience = true,
//////            ValidateLifetime = true,
//////            ValidateIssuerSigningKey = true,
//////            ValidIssuer = jwtIssuer,
//////            ValidAudience = jwtIssuer,
//////            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
//////        };
//////    });

////// Configure the database context
////builder.Services.AddDbContext<QuizContext>(options =>
////    options.UseSqlServer(builder.Configuration.GetConnectionString("dbcs")));

////// Configure Swagger/OpenAPI
////builder.Services.AddEndpointsApiExplorer();
////builder.Services.AddSwaggerGen();

////var app = builder.Build();

////// Apply CORS policy
////app.UseCors("AllowReactApp");

////// Configure the HTTP request pipeline.
////if (app.Environment.IsDevelopment())
////{
////    app.UseSwagger();
////    app.UseSwaggerUI();
////}

////app.UseHttpsRedirection();
////app.UseAuthentication();
////app.UseAuthorization();

////app.MapControllers();

////app.MapFallbackToFile("/index.html");

////app.Run();
///

using Microsoft.EntityFrameworkCore;
using Quiz.Server.Models;
using Quiz.Server.Services;

///
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration;
builder.Services.AddDbContext<QuizContext>(options =>
    options.UseSqlServer(config.GetConnectionString("dbcs")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policyBuilder =>
        {
            policyBuilder.WithOrigins("https://localhost:5173")
                         .AllowAnyHeader()
                         .AllowAnyMethod();
        });
});
builder.Services.AddScoped<AuthenticationService>();


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp"); // Add this line to enable CORS

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
