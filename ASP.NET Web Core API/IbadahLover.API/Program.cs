using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using IbadahLover.Application;
using IbadahLover.Infrastructure;
using IbadahLover.Persistence;
using Microsoft.OpenApi.Models;
using IbadahLover.API.Middleware;
using Scalar.AspNetCore;
using IbadahLover.Identity;
using System.Drawing.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
//AddSwaggerDoc(builder.Services); //using openapi documentation not swagger's one

// Add services to the container.

//------------------ BELOW is the code to get the connection string from Azure Key Vault for when deployed to Azure
var KeyVaultUrl = new Uri(builder.Configuration.GetSection("KeyVaultUrl").Value!);
var AzureCredential = new DefaultAzureCredential();
builder.Configuration.AddAzureKeyVault(KeyVaultUrl, AzureCredential);

AddSwaggerDoc(builder.Services);

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
builder.Services.CongfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi(opt =>
{
    opt.AddDocumentTransformer((document, context, CancellationToken) =>
    {
        document.Info.Title = "IbadahLover API";
        document.Info.Contact = new OpenApiContact()
        {
            Name = "Amir",
            Email = "programirbe@gmail.com"
        };

        return Task.CompletedTask;
    });
});


builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", // for angular frontend access to this api
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IbadahLover API v1"));
    app.MapScalarApiReference();
}

app.UseAuthentication();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();
//app.UseAuthentication();
app.UseRouting(); // ??? just follow tutorial don't know what it does
app.UseAuthorization();

app.UseCors("CorsPolicy");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapControllers(); TO KNOW! if UseEndpoints from above has issue use this instead

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
    services.AddSwaggerGen(c =>
    {
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme. 
                            Enter 'Bearer' [space] and then your token in the text input below.
                            Example: 'Bearer 12345abcdef'",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,
                },
                new List<string>()
            }
        });

        c.SwaggerDoc("v1", new OpenApiInfo { Title = "IbadahLover API", Version = "v1" });
    });
}

//void AddSwaggerDoc(IServiceCollection services)
//{
//    services.AddSwaggerGen(c =>
//    {
//        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//        {
//            Description = @"JWT Authorization header using the Bearer scheme. 
//                            Enter 'Bearer' [space] and then your token in the text input below.
//                            Example: 'Bearer 12345abcdef'",
//            Name = "Authorization",
//            In = ParameterLocation.Header,
//            Type = SecuritySchemeType.ApiKey,
//            Scheme = "Bearer"
//        });

//        c.AddSecurityRequirement(new OpenApiSecurityRequirement()
//        {
//            {
//                new OpenApiSecurityScheme
//                {
//                    Reference = new OpenApiReference
//                    {
//                        Type = ReferenceType.SecurityScheme,
//                        Id = "Bearer"
//                    },
//                    Scheme = "oauth2",
//                    Name = "Bearer",
//                    In = ParameterLocation.Header,
//                },
//                new List<string>()
//            }
//        });

//        c.SwaggerDoc("v1", new OpenApiInfo
//        {
//            Version = "v1",
//            Title = "IbadahLover API",
//        });
//    });
//}