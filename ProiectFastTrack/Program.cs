using ProiectFastTrack.Extension;
using ProiectFastTrack.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var connString = builder.Configuration.GetConnectionString("SqlDbConnectionString");
var custom = builder.Configuration["MyCustomField"].ToString();

// Add services to the container.
builder.Services.AddDataAccessLayer(connString);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<InvalidIdExceptionFilter>();
    options.Filters.Add<DuplicatedIdExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o => AddSwaggerDocumentation(o));
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

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}
