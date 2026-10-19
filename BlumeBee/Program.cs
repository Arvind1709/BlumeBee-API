using BlumeBee.Services;
using BlumeBee.Data;
using BlumeBee.IRepository;
using BlumeBee.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

using System.Reflection;
using BlumeBee.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<DynamicCrudService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddDbContext<AppDbContext>(options =>
//  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddSingleton<PostgresDbHelper>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connString = config.GetConnectionString("PostgresConnection");
    return new PostgresDbHelper(connString);
});
//builder.Services.AddScoped<IStudentRepository, StudentRepository>();
//builder.Services.AddScoped<ICenterRepository, CenterRepository>();
//builder.Services.AddScoped<IAcademicSessionRepository, AcademicSessionRepository>();
//builder.Services.AddScoped<IMasterGenderRepository, MasterGenderRepository>();
//builder.Services.AddScoped<IMasterProgramRepository, MasterProgramRepository>();
//builder.Services.AddScoped<ILeadRepository, LeadRepository>();
//builder.Services.AddScoped<IMasterLeadSourceRepository, MasterLeadSourceRepository>();
//builder.Services.AddScoped<IMasterClassRepository, MasterClassRepository>();
//builder.Services.AddScoped<IMasterStaffRoleRepository, MasterStaffRoleRepository>();
//builder.Services.AddScoped<IMasterLeadStatusRepository, MasterLeadStatusRepository>();
//builder.Services.AddScoped<IMasterPaymentStatusRepository, MasterPaymentStatusRepository>();
//builder.Services.AddScoped<IMasterAttendanceCodeRepository, MasterAttendanceCodeRepository>();
//builder.Services.AddScoped<IMasterCommunicationTypeRepository, MasterCommunicationTypeRepository>();
//builder.Services.AddScoped<IMasterCommunicationTypeRepository, MasterCommunicationTypeRepository>();





//builder.Services.AddScoped<IVisitorLogRepository, VisitorLogRepository>();
//builder.Services.AddScoped<IParentRepository, ParentRepository>();
//builder.Services.AddScoped<IStudentAttendanceRepository, StudentAttendanceRepository>();
//builder.Services.AddScoped<IStaffRepository, StaffRepository>();
//builder.Services.AddScoped<IStaffAttendanceRepository, StaffAttendanceRepository>();





//builder.Services.AddScoped<IOrderRepository, OrderRepository>();
//builder.Services.AddScoped<IOrderService, OrderService>();



// -----------------------------------//Repositories


var repositoryAssembly = typeof(IMasterCommunicationTypeRepository).Assembly;

var assemblyTypes = repositoryAssembly.GetTypes();

var repositoryInterfaces = assemblyTypes
    .Where(t => t.IsInterface
        && t.Namespace == "BlumeBee.IRepository"
        && t.Name.EndsWith("Repository"));

foreach (var repositoryInterface in repositoryInterfaces)
{
    var implementationName = repositoryInterface.Name.Substring(1);

    var implementation = assemblyTypes.FirstOrDefault(t =>
        t.IsClass
        && !t.IsAbstract
        && t.Name == implementationName
        && t.Namespace == "BlumeBee.Repositories");
      //  && t.Namespace == "BlumeBee.Repository");

    if (implementation != null)
    {
        builder.Services.AddScoped(repositoryInterface, implementation);
    }
}

// -----------------------------------//




// Register ALL discount types
builder.Services.AddScoped<IDiscount, PercentageDiscount>();
builder.Services.AddScoped<IDiscount, FlatDiscount>();
builder.Services.AddScoped<IDiscount, FestivalDiscount>();
builder.Services.AddScoped<IDiscount, PremiumUserDiscount>();

//Start of JWT Authentication configuration
// ... existing registrations

var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = jwtConfig["Key"];

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["Issuer"],
        ValidAudience = jwtConfig["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
    };
});
///////////////////////////////////
// Configure Swagger to support JWT bearer auth
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BlumeBee API", Version = "v1" });

    // Define the BearerAuth scheme that's in use
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token.\n\nExample: \"Bearer eyJhbGci...\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});


//////////////////////////////////
builder.Services.AddAuthorization();

// register a token service (see below)
builder.Services.AddScoped<ITokenService, TokenService>();
//for angular project

builder.Services.AddCors(options =>
{
    options.AddPolicy("AngularClient", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:4200",
                "http://localhost:8030",
                "https://lurch-mosaic-anatomist.ngrok-free.dev"
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// END Of JWT Authentication configuration
var app = builder.Build();
//for angular project
app.UseCors("AngularClient");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthentication(); // <- must come before UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();
