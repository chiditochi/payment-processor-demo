
using Microsoft.AspNetCore.Mvc;
using Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPaymentService, PaymentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();



app.MapPost("/pay", ([FromBody]PaymentDto paylaod, IPaymentService paymentService) =>
{
    string result = paymentService.MakePayment(paylaod);
    return Results.Ok(result);   
})
.WithName("Pay");

app.Run();

