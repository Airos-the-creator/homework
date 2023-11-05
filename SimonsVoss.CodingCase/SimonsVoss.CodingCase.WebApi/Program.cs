using Newtonsoft.Json;
using SimonsVoss.CodingCase.Data;
using SimonsVoss.CodingCase.Logic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IQueryLogic, QueryLogic>();
builder.Services.AddSingleton<IDataRepository>(sp =>
{
    var dataAsText = File.ReadAllText(@"resources/data.json");
    var dataRepository = JsonConvert.DeserializeObject<DataRepository>(dataAsText) ?? new DataRepository();
    dataRepository.Initialize();
    return dataRepository;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200",
                                              "https://localhost:7159/")
                          .AllowAnyMethod();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();

