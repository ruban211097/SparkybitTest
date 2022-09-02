using Api.Auth;
using Infrastructure;
using Messsaging;

var builder = WebApplication.CreateBuilder(args);
Logger.Init();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddMessagingLayer();
builder.Services.AddJwtAuth();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
