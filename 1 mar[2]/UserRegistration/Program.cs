using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using BusinessLayer.Interface;
using BusinessLayer.Service;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;
using RepositoryLayer.Helper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
//using StackExchange.Redis;
//using RabbitMQ.Client;
//using Microsoft.Extensions.Configuration;


var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("Application Starting...");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Configure NLog
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    // Add controllers
    builder.Services.AddControllers();

    // Add Swagger
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // Configure Dependency Injection
    builder.Services.AddScoped<IUserRegistrationBL, UserRegistrationBL>();
    builder.Services.AddScoped<IUserRegistrationRL, UserRegistrationRL>();
    builder.Services.AddScoped<JwtHelper>();
    builder.Services.AddScoped<ResetTokenHelper>();
    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));
    builder.Services.AddScoped<EmailService>();
    builder.Services.AddSingleton<RabbitMQProducer>();
    builder.Services.AddSingleton<RabbitMQConsumer>();

    // Configure Database Context
    var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
    builder.Services.AddDbContext<UserDbContext>(options => options.UseSqlServer(connectionString));

    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

    //Add Redis
    builder.Services.AddStackExchangeRedisCache(options =>
    {
        options.Configuration = "localhost:6379"; 
        options.InstanceName = "UserRegistration_";
    });

    // Add RabbitMQ
    //builder.Services.AddSingleton<RabbitMQProducer>();
    //builder.Services.AddSingleton<RabbitMQConsumer>();
    // Add SMTP Configuration
    builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SMTP"));


    var app = builder.Build();


    // Middleware
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    logger.Error(ex, "Application stopped due to an exception.");
    throw;
}
finally
{
    LogManager.Shutdown();
}
