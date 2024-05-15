using API.AutoMapper;
using Asp.Versioning;
using Core.CandidateApplicationServices;
using Core.QuestionServices;
using Microsoft.Azure.Cosmos;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//registration of services to DI container
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<ICandidateApplicationService, CandidateApplicationService>();

//registration autoMapper service to DI container
builder.Services.AddAutoMapper(typeof(AppAutoMapper));


// Add cosmos service to the container.
builder.Services.AddSingleton((provider) =>
{
    var endpointUri = builder.Configuration["CosmosDbSettings:EndpointUri"];
    var primaryKey = builder.Configuration["CosmosDbSettings:PrimaryKey"];
    var databaseName = builder.Configuration["CosmosDbSettings:DatabaseName"];

    var cosmosClientOptions = new CosmosClientOptions
    {
        ApplicationName = databaseName,
        ConnectionMode = ConnectionMode.Gateway,
    };
    var loggerFactory = LoggerFactory.Create(builder =>
    {
        builder.AddConsole();
    });
    var cosmosClient = new CosmosClient(endpointUri, primaryKey, cosmosClientOptions);
    return cosmosClient;
});

//Added API versioning
var DefaultApiVersion = new ApiVersion(1, 0);
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = DefaultApiVersion;
    options.AssumeDefaultVersionWhenUnspecified = false;
    options.ReportApiVersions = true;
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
    options.DefaultApiVersion = DefaultApiVersion;
}).EnableApiVersionBinding();

//Adding some custom swagger description
builder.Services.AddSwaggerGen(c =>
{
    // Set the Swagger document properties
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Capital Placement API Service",
        Version = "v1",
        Description = "Capital Placement Backend APIs",
        Contact = new OpenApiContact
        {
            Name = "Capital Placement ",
            Email = "" //TODO:Use an actual email
        }
    });
});



builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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

app.UseAuthorization();

app.MapControllers();

app.Run();
