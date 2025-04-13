using System.Text.Json.Serialization;
using CustomerOrders.Common.Extensions;
using CustomerOrders.Common.Filters;
using CustomerOrders.Middlewares;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(option =>
{
   option.Filters.Add<ExternalServiceExceptionFilter>();
   option.Filters.Add<GlobalExceptionFilter>();
}).AddJsonOptions(option =>
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