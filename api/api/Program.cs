using api;
using api.API.Hubs;
using api.API.Middlewares.Policy;
using api.BLL.MappingProfiles;
using api.DAL.Context;
using api.DAL.Entities;
using api.Shared.Attributes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);



// ----- Database ------ //
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSQL"));
})
    .AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();



// ----- Adding Authentication ----- //
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// ----- Adding Jwt Bearer ----- //
.AddJwtBearer(options => {
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters() {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWTKey:ValidAudience"],
        ValidIssuer = builder.Configuration["JWTKey:ValidIssuer"],
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTKey:Secret"]))
    };
});

// ----- Adding DI ----- //
builder.Services.AddInjektables();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);


// ----- Response compression for optimal ----- //
builder.Services.AddResponseCompression(options => {
    options.EnableForHttps = true;
    options.Providers.Add<GzipCompressionProvider>();
});


// ----- Add Mapper Profiles ----- //
builder.Services.AddAutoMapper(options => {
    options.AddProfile<TicketProfile>();
    options.AddProfile<UserProfile>();
    options.AddProfile<ProjectProfile>();
    options.AddProfile<ProjectUserProfile>();
});


// ----- Logging ----- //
builder.Services.AddLogging();


// ----- JSON SerializerOptions ----- //
builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});



// ----- Swagger ----- //
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger => {
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
});

// ----- CORS policy ----- //
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAnyOrigin", policy => {
        policy.WithOrigins(new string[] { "http://localhost:3000" })
        .AllowAnyMethod()
        .AllowCredentials()
        .AllowAnyHeader();
    });
});



// ----- Authorization ----- //
builder.Services.AddAuthorization(options => {
    options.DefaultPolicy =  new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
    options.AddPolicy("UserInProject", policy => {
        policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
        policy.RequireAuthenticatedUser();
        policy.AddRequirements(new UserInProjectRequirement());
    });

});

// ----- Signlar R----- //
builder.Services.AddSignalRCore();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();


app.UseAuthorization();

app.UseAuthentication();

app.MapControllers();

app.MapHub<NotificationHub>("/api/notification");

app.Run();
