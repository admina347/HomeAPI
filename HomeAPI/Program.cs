using HomeAPI.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
//builder.Configuration.AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: false);
//Config
//builder.Configuration.AddJsonFile("HomeOptions.json", optional: true, reloadOnChange: false);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Config
builder.Configuration.AddJsonFile("HomeOptions.json");

builder.Services.Configure<HomeOptions>
        (builder.Configuration.GetSection("HomeOptions"));

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
