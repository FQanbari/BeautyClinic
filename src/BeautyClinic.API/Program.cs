using BeautyClinic.API.Endpoints.Internal;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpoints<Program>(builder.Configuration);

// add validator
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// add swagger
app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
app.UseEndpoints<Program>();

app.Run();
