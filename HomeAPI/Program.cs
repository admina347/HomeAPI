using AutoMapper;
using HomeApi.Data;
using HomeApi.Data.Repos;
using HomeAPI;
using HomeAPI.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//БД
builder.Services.AddDbContext<HomeApiContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// регистрация сервиса репозитория для взаимодействия с базой данных
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

//builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<AddDeviceValidator>());
//Config
builder.Configuration.AddJsonFile("HomeOptions.json");

builder.Services.Configure<HomeOptions>
        (builder.Configuration.GetSection("HomeOptions"));


// Подключаем автомаппинг
var mapperConfig = new MapperConfiguration((v) => 
{
    v.AddProfile(new MappingProfile());
}
);
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


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
