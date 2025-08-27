using CoreLibrary;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<Calculator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/add", (int a, int b, Calculator calc) =>
{
    return Results.Ok(new { result = calc.Add(a, b) });
});

app.MapGet("/multiply", (int a, int b, Calculator calc) =>
{
    return Results.Ok(new { result = calc.Multiply(a, b) });
});

app.Run();
