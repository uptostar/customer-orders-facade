using System.Text.Json.Serialization;
using CustomerOrders.Common.Extensions;
using CustomerOrders.Controllers.Interfaces;
using CustomerOrders.Facades.Interfaces;
using CustomerOrders.Facades;
using CustomerOrders.Middlewares;
using CustomerOrders.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(option =>
{
   option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddHttpClient();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();

builder.Services.AddRouting(options =>
{
   options.LowercaseUrls = true;
   options.LowercaseQueryStrings = true;
   options.AppendTrailingSlash = true;
});

builder.Services.AddExternalServices();
builder.Services.AddInternalServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   app.UseDeveloperExceptionPage();
   app.UseSwagger();
   app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseHealthChecks("/health");

app.UseRouting();
app.MapControllers();

app.UseMiddleware<RequestLatencyLoggingMiddleware>();

app.Run();