using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using virtual_ex.ControllerServices;
using virtual_ex.Data;
using virtual_ex.MiddleWare;
using virtual_ex.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"],
                ClockSkew = TimeSpan.Zero, // THIS IS TO PREVENT JWT BY DEFAULT FROM AUTOMATICALLY ADDING EXTRA 5 MINS TO EXPIRATION TIME
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            };
        }
    );


builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
    );




builder.Services.AddIdentityCore<UserModel>(options =>
    {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequiredLength = 6;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredUniqueChars = 0;

        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = false;

        // User Settings
        options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;

    })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<ApplicationDBContext>()
        .AddSignInManager<SignInManager<UserModel>>() // Add SignInManager support
        .AddUserManager<UserManager<UserModel>>()
        .AddRoleManager<RoleManager<IdentityRole>>();



builder.Services.AddIdentityApiEndpoints<UserModel>()
    .AddEntityFrameworkStores<ApplicationDBContext>();



builder.Services.AddScoped<UserJwtValidityMiddleWare>();

builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddSingleton<IPictureAndVideoUploadService, PictureAndVideoUploadService>();





builder.Services.AddControllers()
    //+++++++++  THIS CONFIG IS ADDED TO HANDLE THE JSON SERIALIZATION ERROR OF MANY TO MANY RELATIONSHIPS TRYING TO GO INTO ENDLESS CYCLE OF REFERENCING ONE ANOTHER +++++
    .AddJsonOptions( options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });


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

app.UseHttpsRedirection();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
