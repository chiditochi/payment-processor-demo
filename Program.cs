using Cyberspace.Model;
using Cyberspace.Model.Validators;
using Cyberspace.Service.Payment;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Cyberspace Payment API",
        Version = "v1",
        Description = "A simple payment processing API demo"
    });
});

builder.Services.AddScoped<IPaymentService, PaymentService>();
// Add FluentValidation and register a single validator.
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddScoped<IValidator<PaymentDto>, PaymentDtoValidator>();

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.MapPost("/pay", async (IValidator<PaymentDto> validator,[FromBody]PaymentDto payload, IPaymentService paymentService) =>
{
    var validationResult = await validator.ValidateAsync(payload);
    if (!validationResult.IsValid)
    {
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    string result = paymentService.MakePayment(payload);
    return Results.Ok(result);   
})
.WithName("Pay");

app.Run();

