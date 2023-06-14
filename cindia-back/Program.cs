using Amazon;
using cindia_back.DbContext;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using cindia_back;
using cindia_back.Repository;
using Amazon.Runtime;
using Amazon.Extensions.NETCore.Setup;
using Amazon.Textract;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var mapperConfig = new MapperConfiguration(configure =>
{
    configure.AddProfile<MappingProfile>();
});
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var awsCredentials = new BasicAWSCredentials(
    builder.Configuration["AWSCredentials:AccessKey"],
    builder.Configuration["AWSCredentials:SecretKey"]
);
builder.Services.AddAWSService<IAmazonTextract>(new AWSOptions()
{
    Region = RegionEndpoint.USEast1
});
builder.Services.AddSingleton<AWSCredentials>(sp => 
     new BasicAWSCredentials("AKIA6I7OWIV4HP3V262C", "e85CiNxYhmmZ77Ureu74Ud9mlCkQtAQPtp9b44FM")
    );
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

builder.Services.AddAWSService<IAmazonService>();


builder.Services.AddScoped<ICasierRepository, CasierRepository>();
builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
builder.Services.AddScoped<ISectionRepository, SectionRepository>();




builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();