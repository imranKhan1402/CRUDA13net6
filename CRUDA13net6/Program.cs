using Manager.Interface;
using Manager.Repository;
using Microsoft.EntityFrameworkCore;
using Model.Context;
using Newtonsoft.Json.Serialization;
using Service.Interface;
using Service.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Ineject DB

builder.Services.AddDbContext<CardsDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("CardsDbConnection")));

//builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICardManager, CardManager>();
builder.Services.AddScoped<ITAPIManager, TAPIManager>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


builder.Services.AddCors((setup)=>
{
    setup.AddPolicy("default", (options) =>
    {
        options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});


//Json Return serialization
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("default");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
